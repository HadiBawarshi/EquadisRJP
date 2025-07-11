using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Commands
{
    public record SubscribeToOfferCommand(int RetailerId, int OfferId) : IRequest<Result>;

}
