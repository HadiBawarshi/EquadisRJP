namespace EquadisRJP.Domain.Entities;

public partial class CommercialOffer : EntityBase
{
    public CommercialOffer()
    {
    }

    private CommercialOffer(string? title, DateTime? validFrom, DateTime? validTo, int? discountValuePercentage, int? supplierId)
    {
        Title = title;
        ValidFrom = validFrom;
        ValidTo = validTo;
        DiscountValuePercentage = discountValuePercentage;
        SupplierId = supplierId;
    }

    public string? Title { get; private set; }

    public DateTime? ValidFrom { get; private set; }

    public DateTime? ValidTo { get; private set; }

    public int? DiscountValuePercentage { get; private set; }

    public int? SupplierId { get; private set; }

    public virtual Supplier? Supplier { get; private set; }

    public void SetValidityDate(DateTime from, DateTime to)
    {
        ValidFrom = from;
        ValidTo = to;
    }

    public static CommercialOffer Create(string? title, DateTime? validFrom, DateTime? validTo, int? discountValuePercentage, int? supplierId)
    {
        return new CommercialOffer(title, validFrom, validTo, discountValuePercentage, supplierId);
    }
}
