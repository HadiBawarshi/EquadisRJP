using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Commands
{
    public record UnsubscribeFromOfferCommand(int RetailerId, int OfferId) : IRequest<Result>;

}
