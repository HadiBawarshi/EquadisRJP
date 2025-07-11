using EquadisRJP.Domain.Primitives;

namespace EquadisRJP.Application.Services
{
    public interface IAuditService
    {
        Task<Result> LogAsync(string actorId, string action, string entityType, int entityId, string? data = null);

    }
}
