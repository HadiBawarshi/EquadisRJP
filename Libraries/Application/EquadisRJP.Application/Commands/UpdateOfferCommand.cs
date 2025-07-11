using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Commands
{
    public record UpdateOfferCommand(
     int OfferId,
     string? Title,
     DateTime ValidFrom,
     DateTime ValidTo,
     int DiscountValuePercentage,
     bool Archive) : IRequest<Result>;
}
