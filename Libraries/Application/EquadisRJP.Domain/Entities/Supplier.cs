namespace EquadisRJP.Domain.Entities;

public partial class Supplier : EntityBase
{
    public Supplier()
    {
    }

    private Supplier(string? companyName, int? countryId, string? userId)
    {
        CompanyName = companyName;
        CountryId = countryId;
        UserId = userId;
    }

    public string? CompanyName { get; set; }


    public int? CountryId { get; set; }

    public string? UserId { get; set; }

    public virtual ICollection<CommercialOffer> CommercialOffers { get; set; } = new List<CommercialOffer>();

    public virtual Country? Country { get; set; }

    public virtual ICollection<Partnership> Partnerships { get; set; } = new List<Partnership>();

    public static Supplier Create(string? companyName, int? countryId, string? userId)
    {
        return new Supplier(companyName, countryId, userId);
    }
}
