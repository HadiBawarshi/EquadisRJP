using EquadisRJP.Domain.Entities;

namespace EquadisRJP.Domain.Repositories
{
    public interface ISubscriptionRepository : IAsyncRepository<OfferSubscription>
    {
        Task<bool> ExistsAsync(int retailerId, int offerId, CancellationToken ct = default);
        Task<OfferSubscription?> GetAsync(int retailerId, int offerId, CancellationToken ct = default);
    }
}
