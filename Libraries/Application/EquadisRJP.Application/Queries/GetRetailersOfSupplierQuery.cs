using EquadisRJP.Application.Dtos;
using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Queries
{
    public record GetRetailersOfSupplierQuery(int SupplierId) : IRequest<Result<List<RetailerDto>>>;
}
