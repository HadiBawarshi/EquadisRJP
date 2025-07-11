namespace EquadisRJP.Application.Dtos.AuditEvent
{
    public class OffersAuditDto
    {
        public OffersAuditDto(int? supplierId, int? retailerId, int? oldStatusId, int? newStatusId, DateTime? occurredAtUtc)
        {
            SupplierId = supplierId;
            RetailerId = retailerId;
            OccurredAtUtc = occurredAtUtc;
        }
        public int? OfferId { get; init; }
        public int? SupplierId { get; init; }
        public int? RetailerId { get; init; }
        public DateTime? OccurredAtUtc { get; init; }
    }

}
