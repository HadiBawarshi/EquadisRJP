using EquadisRJP.Application.Commands;
using EquadisRJP.Application.Services;
using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;
using System.Text.Json;

namespace EquadisRJP.Application.Handlers
{
    public class UnsubscribeFromOfferCommandHandler : IRequestHandler<UnsubscribeFromOfferCommand, Result>
    {
        private readonly ISubscriptionRepository _subsRepo;
        private readonly IUnitOfWork _uow;
        private readonly IAuditService _auditLogger;

        public UnsubscribeFromOfferCommandHandler(ISubscriptionRepository subsRepo, IUnitOfWork uow, IAuditService auditLogger)
        {
            _subsRepo = subsRepo;
            _uow = uow;
            _auditLogger = auditLogger;
        }

        public async Task<Result> Handle(UnsubscribeFromOfferCommand request, CancellationToken ct)
        {
            var subscription = await _subsRepo.GetAsync(request.RetailerId, request.OfferId, ct);
            if (subscription is null || !subscription.IsActive())
                return Result.Failure(Error.NotFound("Subscription.NotFound", "No active subscription found."));

            subscription.Unsubscribe();
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
