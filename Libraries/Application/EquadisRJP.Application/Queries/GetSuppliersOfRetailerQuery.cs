using EquadisRJP.Application.Dtos;
using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Queries
{
    public record GetSuppliersOfRetailerQuery(int RetailerId) : IRequest<Result<List<SupplierDto>>>;
}
