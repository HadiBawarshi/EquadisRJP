using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Repositories;
using EquadisRJP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static EquadisRJP.Domain.Entities.Partnership;

namespace EquadisRJP.Infrastructure.Repositories
{
    public class PartnershipRepository : RepositoryBase<Partnership>, IPartnershipRepository
    {
        public PartnershipRepository(EquadisRJPDbContext dbContext) : base(dbContext) { }

        public async Task<bool> ExistsActiveAsync(int supplierId, int retailerId)
        {
            return await _dbContext.Partnerships.AnyAsync(p =>
                p.SupplierId == supplierId &&
                p.RetailerId == retailerId &&
                p.StatusId == (int)Partnership.PartnershipStatus.Active);
        }

        public async Task<IReadOnlyList<Partnership>> GetActivePartnershipsAsync(CancellationToken ct = default)
        {
            return await _dbContext.Partnerships
             .Where(p => p.StatusId == (int)PartnershipStatus.Active &&
                   (!p.ExpiryDate.HasValue || p.ExpiryDate > DateTime.UtcNow))
             .Include(p => p.Supplier)
             .Include(p => p.Retailer)
             .ToListAsync(ct);
        }
    }
}
