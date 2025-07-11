using AutoMapper;
using EquadisRJP.Application.Dtos;
using EquadisRJP.Application.Queries;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;

namespace EquadisRJP.Application.Handlers
{
    public class GetSuppliersOfRetailerQueryHandler : IRequestHandler<GetSuppliersOfRetailerQuery, Result<List<SupplierDto>>>
    {
        private readonly ISupplierRepository _repo;
        private readonly IMapper _mapper;

        public GetSuppliersOfRetailerQueryHandler(ISupplierRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<Result<List<SupplierDto>>> Handle(GetSuppliersOfRetailerQuery q, CancellationToken ct)
        {
            var list = await _repo.GetSuppliersByRetailerAsync(q.RetailerId, ct);
            var dto = _mapper.Map<List<SupplierDto>>(list);
            return Result.Success(dto);
        }
    }
}
