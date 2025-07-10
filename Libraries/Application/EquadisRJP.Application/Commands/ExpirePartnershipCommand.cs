using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Commands
{
    public record ExpirePartnershipCommand(int PartnershipId) : IRequest<Result>;

}
