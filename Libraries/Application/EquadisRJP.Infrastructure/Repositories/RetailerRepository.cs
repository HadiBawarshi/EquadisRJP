using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Repositories;
using EquadisRJP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static EquadisRJP.Domain.Entities.Partnership;

namespace EquadisRJP.Infrastructure.Repositories
{
    public class RetailerRepository : RepositoryBase<Retailer>, IRetailerRepository
    {
        public RetailerRepository(EquadisRJPDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<IReadOnlyList<Retailer>> GetRetailersBySupplierAsync(int supplierId, CancellationToken ct = default)
        {
            return await _dbContext.Partnerships
                .Where(p => p.SupplierId == supplierId &&
                 p.StatusId == (int)PartnershipStatus.Active)
                .Select(p => p.Retailer!)
                .AsNoTracking()
                .ToListAsync(ct);
        }


    }
}
