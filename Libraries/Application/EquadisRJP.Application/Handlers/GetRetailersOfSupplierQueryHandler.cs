using AutoMapper;
using EquadisRJP.Application.Dtos;
using EquadisRJP.Application.Queries;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;

namespace EquadisRJP.Application.Handlers
{
    public class GetRetailersOfSupplierHandler : IRequestHandler<GetRetailersOfSupplierQuery, Result<List<RetailerDto>>>
    {
        private readonly IRetailerRepository _repo;
        private readonly IMapper _mapper;

        public GetRetailersOfSupplierHandler(IRetailerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<List<RetailerDto>>> Handle(GetRetailersOfSupplierQuery q, CancellationToken ct)
        {
            var list = await _repo.GetRetailersBySupplierAsync(q.SupplierId, ct);
            var dto = _mapper.Map<List<RetailerDto>>(list);
            return Result.Success(dto);
        }
    }
}
