using AutoMapper;
using EquadisRJP.Application.Dtos;
using EquadisRJP.Application.Queries;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;

namespace EquadisRJP.Application.Handlers
{
    public class GetActivePartnershipsQueryHandler : IRequestHandler<GetActivePartnershipsQuery, Result<List<PartnershipDto>>>
    {
        private readonly IPartnershipRepository _repo;
        private readonly IMapper _mapper;

        public GetActivePartnershipsQueryHandler(IPartnershipRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<List<PartnershipDto>>> Handle(GetActivePartnershipsQuery q, CancellationToken ct)
        {
            var list = await _repo.GetActivePartnershipsAsync(ct);
            var dto = _mapper.Map<List<PartnershipDto>>(list);
            return Result.Success(dto);
        }
    }
}
