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

        public async Task<IReadOnlyList<CommercialOffer>> GetActiveOffersOfSupplierAsync(
            int supplierId, CancellationToken ct = default)
        {
            var now = DateTime.UtcNow;
            return await _dbContext.CommercialOffers
                .Where(o => o.SupplierId == supplierId
                         && o.StatusId == (int)CommercialOffer.OfferStatus.Active
                         && o.ValidFrom <= now && o.ValidTo >= now)
                .AsNoTracking()
                .ToListAsync(ct);
        }
    }

}
