using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Repositories;
using EquadisRJP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EquadisRJP.Infrastructure.Repositories
{
    public class SubscriptionRepository : RepositoryBase<OfferSubscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(EquadisRJPDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ExistsAsync(int retailerId, int offerId, CancellationToken ct = default)
     => await _dbContext.OfferSubscriptions
         .AnyAsync(s => s.RetailerId == retailerId &&
                        s.CommercialOfferId == offerId &&
                        s.StatusId == (int)OfferSubscription.SubscriptionStatus.Active, ct);

        public async Task<OfferSubscription?> GetAsync(int retailerId, int offerId, CancellationToken ct = default)
            => await _dbContext.OfferSubscriptions
                .FirstOrDefaultAsync(s => s.RetailerId == retailerId &&
                                          s.CommercialOfferId == offerId &&
                                          s.StatusId == (int)OfferSubscription.SubscriptionStatus.Active, ct);
    }
}
