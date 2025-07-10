using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Commands
{
    public record RenewPartnershipCommand(
     int PartnershipId,
     DateTime NewExpiryDate) : IRequest<Result>;
}
