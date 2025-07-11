using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Commands
{
    public record ExpirePartnershipCommand(int SupplierId, int PartnershipId) : IRequest<Result>;

}
