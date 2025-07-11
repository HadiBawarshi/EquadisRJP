namespace EquadisRJP.Domain.Entities
{
    public class AuditLog : EntityBase
    {
        public AuditLog()
        {
        }

        public AuditLog(string? actorId, string? action, string? entityType, int? entityId, string? data)
        {
            ActorId = actorId;
            Action = action;
            EntityType = entityType;
            EntityId = entityId;
            Data = data;
        }

        public string? ActorId { get; private set; } = null!;
        public string? Action { get; private set; } = null!;
        public string? EntityType { get; private set; } = null!;
        public int? EntityId { get; private set; }
        public string? Data { get; private set; }


        public static AuditLog Create(string? actorId, string? action, string? entityType, int? entityId, string? data)
        {
            return new AuditLog(actorId, action, entityType, entityId, data);
        }
    }
}
