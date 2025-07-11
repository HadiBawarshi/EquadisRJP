using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Repositories;
using EquadisRJP.Infrastructure.Data;

namespace EquadisRJP.Infrastructure.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository

    {
        public SupplierRepository(EquadisRJPDbContext dbContext) : base(dbContext)
        {
        }

    }
}
