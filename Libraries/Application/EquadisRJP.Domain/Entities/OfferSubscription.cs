namespace EquadisRJP.Domain.Entities;

public partial class OfferSubscription : EntityBase
{
    public OfferSubscription()
    {
    }

    private OfferSubscription(int? retailerId, int? commercialOfferId, DateTime? validFrom, DateTime? validTo)
    {
        RetailerId = retailerId;
        CommercialOfferId = commercialOfferId;
        ValidFrom = validFrom;
        ValidTo = validTo;

    }

    public int? RetailerId { get; set; }

    public int? CommercialOfferId { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public virtual CommercialOffer? CommercialOffer { get; set; }

    public virtual Retailer? Retailer { get; set; }


    public static OfferSubscription Create(int? retailerId, int? commercialOfferId, DateTime? validFrom, DateTime? validTo)
    {
        return new OfferSubscription(retailerId, commercialOfferId, validFrom, validTo);
    }
}
