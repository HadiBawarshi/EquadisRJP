namespace EquadisRJP.Application.Dtos
{
    public class PartnershipDto
    {
        public int Id { get; init; }
        public SupplierDto Supplier { get; init; }
        public RetailerDto Retailer { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime? ExpiryDate { get; init; }
    }
}
