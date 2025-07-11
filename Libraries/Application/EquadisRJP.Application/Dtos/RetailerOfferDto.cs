namespace EquadisRJP.Application.Dtos
{
    public record RetailerOfferDto(
     int Id,
     string Title,
     DateTime ValidFrom,
     DateTime ValidTo,
     int DiscountValuePercentage,
     int SupplierId);
}
