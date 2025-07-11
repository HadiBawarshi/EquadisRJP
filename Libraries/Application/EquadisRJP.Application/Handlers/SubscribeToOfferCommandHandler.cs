using EquadisRJP.Application.Commands;
using EquadisRJP.Application.Services;
using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;
using System.Text.Json;

namespace EquadisRJP.Application.Handlers
{
    public class SubscribeToOfferCommandHandler : IRequestHandler<SubscribeToOfferCommand, Result>
    {
        private readonly ISubscriptionRepository _subsRepo;
        private readonly IOfferRepository _offerRepo;
        private readonly IPartnershipRepository _partnershipRepo;
        private readonly IUnitOfWork _uow;
        private readonly IAuditService _auditLogger;

        public SubscribeToOfferCommandHandler(ISubscriptionRepository subsRepo, IOfferRepository offerRepo, IPartnershipRepository partnershipRepo, IUnitOfWork uow, IAuditService auditLogger)
        {
            _subsRepo = subsRepo;
            _offerRepo = offerRepo;
            _partnershipRepo = partnershipRepo;
            _uow = uow;
            _auditLogger = auditLogger;
        }


        public async Task<Result> Handle(SubscribeToOfferCommand request, CancellationToken ct)
        {
            var offer = await _offerRepo.GetByIdAsync(request.OfferId, ct);
            if (offer == null || !offer.IsCurrent())
                return Result.Failure(Error.Validation("Offer.Invalid", "The offer is not currently active."));

            var hasPartnership = await _partnershipRepo.HasActivePartnershipAsync(request.RetailerId, offer.SupplierId);
            if (!hasPartnership)
                return Result.Failure(Error.Validation("Partnership.Missing", "Retailer is not partnered with the supplier."));

            var alreadySubscribed = await _subsRepo.ExistsAsync(request.RetailerId, request.OfferId, ct);
            if (alreadySubscribed)
                return Result.Failure(Error.Conflict("Subscription.Exists", "Already subscribed."));

            var subscription = OfferSubscription.Create(request.RetailerId, request.OfferId);
            await _subsRepo.AddAsync(subscription, ct);
            await _uow.SaveChangesAsync(ct);


            await _auditLogger.LogAsync(
                request.RetailerId.ToString(),
                "Subscribe-To-Offer",
                nameof(OfferSubscription),
                subscription.Id,
                JsonSerializer.Serialize(subscription)
            );
            return Result.Success();
        }
    }
}
