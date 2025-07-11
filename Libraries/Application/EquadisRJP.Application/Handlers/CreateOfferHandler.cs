using EquadisRJP.Application.Commands;
using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;

namespace EquadisRJP.Application.Handlers
{
    public sealed class CreateOfferHandler : IRequestHandler<CreateOfferCommand, Result<int>>
    {
        private readonly IOfferRepository _repo;
        private readonly IUnitOfWork _uow;

        public CreateOfferHandler(IOfferRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Result<int>> Handle(CreateOfferCommand rq, CancellationToken ct)
        {
            var offer = CommercialOffer.Create(
                rq.Title, rq.ValidFrom, rq.ValidTo,
                rq.DiscountValuePercentage, rq.SupplierId);

            await _repo.AddAsync(offer, ct);
            await _uow.SaveChangesAsync(ct);

            return Result.Success(offer.Id);
        }
    }
}
