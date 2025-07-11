using EquadisRJP.Application.Commands;
using EquadisRJP.Application.Dtos.AuditEvent;
using EquadisRJP.Application.Services;
using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Errors;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;
using System.Text.Json;
using static EquadisRJP.Domain.Entities.Partnership;

namespace EquadisRJP.Application.Handlers
{
    public class RenewPartnershipCommandHandler : IRequestHandler<RenewPartnershipCommand, Result>
    {
        private readonly IPartnershipRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly IAuditService _auditLogger;

        public RenewPartnershipCommandHandler(IPartnershipRepository repo, IUnitOfWork uow, IAuditService auditLogger)
        {
            _repo = repo;
            _uow = uow;
            _auditLogger = auditLogger;
        }

        public async Task<Result> Handle(RenewPartnershipCommand rq, CancellationToken ct)
        {
            var partnership = await _repo.GetByIdAsync(rq.PartnershipId, ct);
            if (partnership is null)
                return Result.Failure(DomainErrors.Partnership.NotFound);
            if (partnership.SupplierId != rq.SupplierId)
                return Result.Failure(DomainErrors.Partnership.NotFound);
            try
            {
                partnership.Renew(rq.NewExpiryDate);
            }
            catch (InvalidOperationException)
            {
                return Result.Failure(DomainErrors.Partnership.NotExpired);
            }
            PartnershipAuditDto auditDto = new PartnershipAuditDto(rq.SupplierId, partnership.RetailerId, (int)PartnershipStatus.Expired, (int)PartnershipStatus.Active, DateTime.UtcNow);

            await _auditLogger.LogAsync(
                rq.SupplierId.ToString(),
                "Renew-Partnership",
                nameof(Partnership),
                partnership.Id,
                JsonSerializer.Serialize(auditDto)
            );
            await _uow.SaveChangesAsync(ct);
            return Result.Success();
        }
    }

}
