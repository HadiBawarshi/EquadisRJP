namespace EquadisRJP.Application.Dtos
{
    public class CreateOfferDto
    {
        public string Title { get; set; } = default!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int DiscountValuePercentage { get; set; }
    }
}
