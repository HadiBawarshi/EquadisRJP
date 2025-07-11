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
    public class ExpirePartnershipCommandHandler : IRequestHandler<ExpirePartnershipCommand, Result>
    {
        private readonly IPartnershipRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly IAuditService _auditLogger;

        public ExpirePartnershipCommandHandler(IPartnershipRepository repo, IUnitOfWork uow, IAuditService auditLogger)
        {
            _repo = repo;
            _uow = uow;
            _auditLogger = auditLogger;
        }

        public async Task<Result> Handle(ExpirePartnershipCommand rq, CancellationToken ct)
        {
            var partnership = await _repo.GetByIdAsync(rq.PartnershipId, ct);
            if (partnership is null)
                return Result.Failure(DomainErrors.Partnership.NotFound);

            if (partnership.SupplierId != rq.SupplierId)
                return Result.Failure(DomainErrors.Partnership.NotFound);

            if (partnership.StatusId == (int)PartnershipStatus.Expired)
                return Result.Failure(DomainErrors.Partnership.AlreadyExpired);

            partnership.Expire();
            await _uow.SaveChangesAsync(ct);

            PartnershipAuditDto auditDto = new PartnershipAuditDto(rq.SupplierId, partnership.RetailerId, (int)PartnershipStatus.Active, (int)PartnershipStatus.Expired, DateTime.UtcNow);

            await _auditLogger.LogAsync(
                rq.SupplierId.ToString(),
                "Expire-Partnership",
                nameof(Partnership),
                partnership.Id,
                JsonSerializer.Serialize(auditDto)
            );

            return Result.Success();
        }
    }

}
