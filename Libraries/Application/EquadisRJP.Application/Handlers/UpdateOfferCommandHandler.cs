using EquadisRJP.Application.Commands;
using EquadisRJP.Domain.Errors;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;

namespace EquadisRJP.Application.Handlers
{
    public sealed class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand, Result>
    {
        private readonly IOfferRepository _repo;
        private readonly IUnitOfWork _uow;

        public UpdateOfferCommandHandler(IOfferRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Result> Handle(UpdateOfferCommand rq, CancellationToken ct)
        {
            var offer = await _repo.GetByIdAsync(rq.OfferId, ct);
            if (offer is null)
                return Result.Failure(DomainErrors.Offer.NotFound);

            if (offer.SupplierId != rq.SupplierId)
                return Result.Failure(DomainErrors.Offer.NotFound);


            if (rq.Archive)
                offer.Archive();
            else
                offer.Update(rq.Title, rq.ValidFrom, rq.ValidTo, rq.DiscountValuePercentage);

            await _uow.SaveChangesAsync(ct);
            return Result.Success();
        }
    }
}
