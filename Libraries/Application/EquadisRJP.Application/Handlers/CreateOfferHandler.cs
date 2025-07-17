using EquadisRJP.Application.Commands;
using EquadisRJP.Application.Services;
using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Errors;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;
using System.Text.Json;

namespace EquadisRJP.Application.Handlers
{
    public sealed class CreateOfferHandler : IRequestHandler<CreateOfferCommand, Result<int>>
    {
        private readonly IOfferRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly IAuditService _auditLogger;

        public CreateOfferHandler(IOfferRepository repo, IUnitOfWork uow, IAuditService auditLogger)
        {
            _repo = repo;
            _uow = uow;
            _auditLogger = auditLogger;
        }

        public async Task<Result<int>> Handle(CreateOfferCommand rq, CancellationToken ct)
        {

            if (rq.DiscountValuePercentage < 1)
                return Result.Failure<int>(DomainErrors.Offer.InvalidDiscountValue);
            var offer = CommercialOffer.Create(
                rq.Title, rq.ValidFrom, rq.ValidTo,
                rq.DiscountValuePercentage, rq.SupplierId);

            await _repo.AddAsync(offer, ct);
            await _uow.SaveChangesAsync(ct);


            await _auditLogger.LogAsync(
                rq.SupplierId.ToString(),
                "Create-CommercialOffer",
                nameof(CommercialOffer),
                offer.Id,
                JsonSerializer.Serialize(offer));

            return Result.Success(offer.Id);
        }
    }
}
