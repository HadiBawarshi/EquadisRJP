using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Repositories;
using EquadisRJP.Infrastructure.Data;

namespace EquadisRJP.Infrastructure.Repositories
{
    public class AuditLogRepository : RepositoryBase<AuditLog>, IAuditLogRepository
    {
        public AuditLogRepository(EquadisRJPDbContext dbContext) : base(dbContext)
        {
        }
    }
}
