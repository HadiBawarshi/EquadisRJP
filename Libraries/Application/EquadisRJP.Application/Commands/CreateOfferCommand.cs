using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Commands
{
    public record CreateOfferCommand(
     string Title,
     DateTime ValidFrom,
     DateTime ValidTo,
     int DiscountValuePercentage,
     int SupplierId) : IRequest<Result<int>>;
}
