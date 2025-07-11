namespace EquadisRJP.Domain.Entities;

public partial class OfferSubscription : EntityBase
{

    public enum SubscriptionStatus
    {
        Active = 1,
        Inactive = 2
    }
    public OfferSubscription()
    {
    }

    private OfferSubscription(int? retailerId, int? commercialOfferId)
    {
        RetailerId = retailerId;
        CommercialOfferId = commercialOfferId;
        StatusId = (int)SubscriptionStatus.Active;


    }

    public int? RetailerId { get; set; }

    public int? CommercialOfferId { get; set; }

    public int StatusId { get; private set; }


    public virtual CommercialOffer? CommercialOffer { get; set; }

    public virtual Retailer? Retailer { get; set; }


    public static OfferSubscription Create(int? retailerId, int? commercialOfferId)
    {
        return new OfferSubscription(retailerId, commercialOfferId);
    }

    public void Unsubscribe()
    {
        if (StatusId == (int)SubscriptionStatus.Inactive)
            return; // Already inactive

        StatusId = (int)SubscriptionStatus.Inactive;
        ModifiedDate = DateTime.UtcNow;
    }


    public bool IsActive()
    {
        return StatusId == (int)SubscriptionStatus.Active;
    }
}
