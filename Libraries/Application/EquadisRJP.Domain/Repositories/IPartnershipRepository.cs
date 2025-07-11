using EquadisRJP.Domain.Entities;

namespace EquadisRJP.Domain.Repositories
{
    public interface IPartnershipRepository : IAsyncRepository<Partnership>
    {
        Task<bool> ExistsActiveAsync(int supplierId, int retailerId);

        Task<IReadOnlyList<Partnership>> GetActivePartnershipsAsync(CancellationToken ct = default);

    }
}
