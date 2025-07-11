using EquadisRJP.Application.Dtos;
using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Queries
{
    public record GetActivePartnershipsQuery() : IRequest<Result<List<PartnershipDto>>>;

}
