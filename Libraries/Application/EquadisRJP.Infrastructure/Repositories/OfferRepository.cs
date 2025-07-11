using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Repositories;
using EquadisRJP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EquadisRJP.Infrastructure.Repositories
{
    public class OfferRepository : RepositoryBase<CommercialOffer>, IOfferRepository
    {
        public OfferRepository(EquadisRJPDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<CommercialOffer>> GetActiveOffersOfSupplierAsync(int supplierId, CancellationToken ct = default)
        {
            var now = DateTime.UtcNow;
            return await _dbContext.CommercialOffers
                .Where(o => o.SupplierId == supplierId
                         && o.StatusId == (int)CommercialOffer.OfferStatus.Active
                         && o.ValidFrom <= now && o.ValidTo >= now)
                .AsNoTracking()
                .ToListAsync(ct);
        }


        public async Task<IReadOnlyList<CommercialOffer>> GetAvailableOffersForRetailerAsync(int retailerId, CancellationToken ct = default)
        {
            var now = DateTime.UtcNow;

            return await _dbContext.CommercialOffers
                .Where(o =>
                    o.StatusId == (int)CommercialOffer.OfferStatus.Active &&
                    o.ValidFrom <= now &&
                    o.ValidTo >= now &&
                    _dbContext.Partnerships.Any(p =>
                        p.RetailerId == retailerId &&
                        p.SupplierId == o.SupplierId &&
                        p.StatusId == (int)Partnership.PartnershipStatus.Active &&
                        (!p.ExpiryDate.HasValue || p.ExpiryDate > now)) &&
                   !_dbContext.OfferSubscriptions.Any(s =>
                   s.RetailerId == retailerId &&
                   s.CommercialOfferId == o.Id &&
                   s.StatusId == (int)OfferSubscription.SubscriptionStatus.Active))
                .AsNoTracking()
                .ToListAsync(ct);
        }
    }

}
