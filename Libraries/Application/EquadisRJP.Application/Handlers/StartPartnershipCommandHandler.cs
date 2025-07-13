using EquadisRJP.Application.Commands;
using EquadisRJP.Application.Dtos.AuditEvent;
using EquadisRJP.Application.Services;
using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Errors;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;
using System.Text.Json;

namespace EquadisRJP.Application.Handlers
{
    public class StartPartnershipCommandHandler : IRequestHandler<StartPartnershipCommand, Result>
    {

        private readonly IPartnershipRepository _repository;
        private readonly IUnitOfWork _uow;
        private readonly IAuditService _auditLogger;

        public StartPartnershipCommandHandler(IPartnershipRepository repository, IUnitOfWork uow, IAuditService auditLogger)
        {
            _repository = repository;
            _uow = uow;
            _auditLogger = auditLogger;
        }

        public async Task<Result> Handle(StartPartnershipCommand rq, CancellationToken ct)
        {

            if (!await _repository.RetailerExist(rq.RetailerId))
                return Result.Failure(DomainErrors.Retailer.NotFound);

            if (await _repository.ExistsActiveAsync(rq.SupplierId, rq.RetailerId))
                return Result.Failure(DomainErrors.Partnership.AlreadyExists);

            var partnership = Partnership.Start(rq.SupplierId, rq.RetailerId, rq.ExpiryDate);

            await _repository.AddAsync(partnership, ct);
            await _uow.SaveChangesAsync(ct);

            PartnershipAuditDto auditDto = new PartnershipAuditDto(rq.SupplierId, partnership.RetailerId, null, null, occurredAtUtc: DateTime.UtcNow);

            await _auditLogger.LogAsync(
                rq.SupplierId.ToString(),
                "Start-Partnership",
                nameof(Partnership),
                partnership.Id,
                JsonSerializer.Serialize(auditDto)
            );
            return Result.Success();
        }
    }
}

