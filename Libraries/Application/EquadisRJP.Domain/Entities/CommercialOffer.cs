namespace EquadisRJP.Domain.Entities;

public partial class CommercialOffer : EntityBase
{
    public CommercialOffer()
    {
    }

    private CommercialOffer(string? title, DateTime? validFrom, DateTime? validTo, int? discountValuePercentage, int supplierId)
    {
        Title = title;
        ValidFrom = validFrom;
        ValidTo = validTo;
        DiscountValuePercentage = discountValuePercentage;
        SupplierId = supplierId;
        StatusId = (int)OfferStatus.Active;
    }

    public enum OfferStatus
    {
        Active = 1,
        Archived = 2
    }

    public string? Title { get; private set; }

    public DateTime? ValidFrom { get; private set; }

    public DateTime? ValidTo { get; private set; }

    public int? DiscountValuePercentage { get; private set; }

    public int SupplierId { get; private set; }

    public int StatusId { get; private set; }


    public virtual Supplier? Supplier { get; private set; }

    public void SetValidityDate(DateTime from, DateTime to)
    {
        ValidFrom = from;
        ValidTo = to;
    }

    public static CommercialOffer Create(string? title, DateTime? validFrom, DateTime? validTo, int? discount, int supplierId)
    {

        if (validFrom >= validTo)
            throw new ArgumentException("ValidFrom must be earlier than ValidTo.");

        if (discount <= 0 || discount > 100)
            throw new ArgumentException("Discount must be between 1 and 100.");

        if (supplierId <= 0)
            throw new ArgumentException("SupplierId must be a positive value.");


        return new(title, validFrom, validTo, discount, supplierId);

    }


    public void Update(string? title, DateTime from, DateTime to, int discount)
    {
        if (from >= to)
            throw new ArgumentException("ValidFrom must be earlier than ValidTo.");

        if (discount <= 0 || discount > 100)
            throw new ArgumentException("discount must be between 1 and 100.");


        Title = title ?? Title;
        ValidFrom = from;
        ValidTo = to;
        DiscountValuePercentage = discount;
        ModifiedDate = DateTime.UtcNow;

        // Reactivate if timeframe is now valid
        if (StatusId == (int)OfferStatus.Archived && IsCurrent())
            StatusId = (int)OfferStatus.Active;
    }

    public void Archive()
    {
        if (StatusId == (int)OfferStatus.Archived) return;

        StatusId = (int)OfferStatus.Archived;
        ModifiedDate = DateTime.UtcNow;
    }

    public bool IsCurrent()
    {
        if (StatusId != (int)OfferStatus.Active) return false;
        if (ValidFrom is null || ValidTo is null) return false;

        var now = DateTime.UtcNow;
        return ValidFrom <= now && ValidTo >= now;
    }


}
