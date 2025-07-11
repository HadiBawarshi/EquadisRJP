using EquadisRJP.Domain.Entities;

namespace EquadisRJP.Domain.Repositories
{
    public interface IOfferRepository : IAsyncRepository<CommercialOffer>
    {
        Task<IReadOnlyList<CommercialOffer>> GetActiveOffersOfSupplierAsync(int supplierId, CancellationToken ct = default);
    }
}
