namespace EquadisRJP.Application.Dtos.AuditEvent
{
    public class PartnershipAuditDto
    {
        public PartnershipAuditDto(int? supplierId, int? retailerId, int? oldStatusId, int? newStatusId, DateTime? occurredAtUtc)
        {
            SupplierId = supplierId;
            RetailerId = retailerId;
            OldStatusId = oldStatusId;
            NewStatusId = newStatusId;
            OccurredAtUtc = occurredAtUtc;
        }

        public int? SupplierId { get; init; }
        public int? RetailerId { get; init; }
        public int? OldStatusId { get; init; }
        public int? NewStatusId { get; init; }
        public DateTime? OccurredAtUtc { get; init; }
    }

}
