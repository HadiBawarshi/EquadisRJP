using EquadisRJP.Application.Commands;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;

namespace EquadisRJP.Application.Handlers
{
    public class UnsubscribeFromOfferCommandHandler : IRequestHandler<UnsubscribeFromOfferCommand, Result>
    {
        private readonly ISubscriptionRepository _subsRepo;
        private readonly IUnitOfWork _uow;

        public UnsubscribeFromOfferCommandHandler(ISubscriptionRepository subsRepo, IUnitOfWork uow)
        {
            _subsRepo = subsRepo;
            _uow = uow;
        }

        public async Task<Result> Handle(UnsubscribeFromOfferCommand request, CancellationToken ct)
        {
            var subscription = await _subsRepo.GetAsync(request.RetailerId, request.OfferId, ct);
            if (subscription is null || !subscription.IsActive())
                return Result.Failure(Error.NotFound("Subscription.NotFound", "No active subscription found."));

            subscription.Unsubscribe();
            await _uow.SaveChangesAsync(ct);

            return Result.Success();
        }
    }
}
