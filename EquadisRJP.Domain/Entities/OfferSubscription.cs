namespace EquadisRJP.Domain.Entities;

public partial class OfferSubscription : EntityBase
{

    public int? RetailerId { get; set; }

    public int? CommercialOfferId { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public virtual CommercialOffer? CommercialOffer { get; set; }

    public virtual Retailer? Retailer { get; set; }
}
