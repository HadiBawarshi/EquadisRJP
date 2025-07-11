using AutoMapper;
using EquadisRJP.Application.Dtos;
using EquadisRJP.Application.Queries;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;

namespace EquadisRJP.Application.Handlers
{
    public class GetCurrentOffersForRetailerQueryHandler : IRequestHandler<GetCurrentOffersForRetailerQuery, Result<List<RetailerOfferDto>>>
    {
        private readonly IOfferRepository _repo;
        private readonly IMapper _mapper;

        public GetCurrentOffersForRetailerQueryHandler(IOfferRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Result<List<RetailerOfferDto>>> Handle(GetCurrentOffersForRetailerQuery q, CancellationToken ct)
        {
            var list = await _repo.GetAvailableOffersForRetailerAsync(q.RetailerId, ct);
            var dto = _mapper.Map<List<RetailerOfferDto>>(list);

            return Result.Success(dto);
        }
    }
}
