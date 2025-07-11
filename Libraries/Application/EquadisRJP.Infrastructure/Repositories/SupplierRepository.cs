using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Repositories;
using EquadisRJP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static EquadisRJP.Domain.Entities.Partnership;

namespace EquadisRJP.Infrastructure.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository

    {
        public SupplierRepository(EquadisRJPDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Supplier>> GetSuppliersByRetailerAsync(int retailerId, CancellationToken ct = default)
        {
            return await _dbContext.Partnerships
                      .Where(p => p.RetailerId == retailerId &&
                             p.StatusId == (int)PartnershipStatus.Active)
                      .Select(p => p.Supplier!)
                      .AsNoTracking()
                      .ToListAsync(ct);
        }
    }
}
