using EquadisRJP.Domain.Entities;

namespace EquadisRJP.Domain.Repositories
{
    public interface ISupplierRepository : IAsyncRepository<Supplier>
    {

        Task<IReadOnlyList<Supplier>> GetSuppliersByRetailerAsync(int retailerId, CancellationToken ct = default);

        Task<int?> GetSupplierIdByUserIdAsync(string userId);


    }
}
