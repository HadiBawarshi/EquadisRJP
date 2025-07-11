
using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;

namespace EquadisRJP.Application.Services
{
    public class AuditService : IAuditService
    {
        private readonly IAuditLogRepository _repo;
        private readonly IUnitOfWork _uow;

        public AuditService(IAuditLogRepository auditRepository, IUnitOfWork uow)
        {
            _repo = auditRepository;
            _uow = uow;
        }

        public async Task<Result> LogAsync(string actorId, string action, string entityType, int entityId, string? data = null)
        {
            var audit = AuditLog.Create(actorId, action, entityType, entityId, data);

            await _repo.AddAsync(audit);
            await _uow.SaveChangesAsync();

            return Result.Success();
        }
    }
}
