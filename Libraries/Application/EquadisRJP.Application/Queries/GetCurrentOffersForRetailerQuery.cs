using EquadisRJP.Application.Dtos;
using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Queries
{
    public record GetCurrentOffersForRetailerQuery(int RetailerId) : IRequest<Result<List<RetailerOfferDto>>>;

}
