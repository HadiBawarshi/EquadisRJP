using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Repositories;
using EquadisRJP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
    }
}
