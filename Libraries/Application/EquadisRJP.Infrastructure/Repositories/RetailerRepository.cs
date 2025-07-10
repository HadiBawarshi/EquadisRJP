using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Repositories;
using EquadisRJP.Infrastructure.Data;

namespace EquadisRJP.Infrastructure.Repositories
{
    public class RetailerRepository : RepositoryBase<Retailer>, IRetailerRepository
    {
        public RetailerRepository(EquadisRJPDbContext dbContext) : base(dbContext)
        {
        }
    }
}
