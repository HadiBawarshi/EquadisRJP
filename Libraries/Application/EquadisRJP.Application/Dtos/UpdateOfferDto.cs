namespace EquadisRJP.Application.Dtos
{
    public class UpdateOfferDto
    {
        public int OfferId { get; set; }
        public string Title { get; set; } = default!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int DiscountValuePercentage { get; set; }
        public bool Archive { get; set; }

    }
}
