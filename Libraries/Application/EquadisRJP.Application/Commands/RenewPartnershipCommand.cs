using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Commands
{
    public record RenewPartnershipCommand(
     int SupplierId,
     int PartnershipId,
     DateTime NewExpiryDate) : IRequest<Result>;
}
