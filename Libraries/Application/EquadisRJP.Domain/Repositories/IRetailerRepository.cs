using EquadisRJP.Domain.Entities;

namespace EquadisRJP.Domain.Repositories
{
    public interface IRetailerRepository : IAsyncRepository<Retailer>
    {

        Task<IReadOnlyList<Retailer>> GetRetailersBySupplierAsync(int supplierId, CancellationToken ct = default);

        Task<int?> GetRetailerIdByUserIdAsync(string userId);

    }
}
