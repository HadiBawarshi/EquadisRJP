namespace EquadisRJP.Domain.Entities;

public partial class Supplier : EntityBase
{
    public Supplier()
    {
    }

    private Supplier(string? companyName, string? phoneNumber, string? email, int? countryId, string? userId)
    {
        CompanyName = companyName;
        PhoneNumber = phoneNumber;
        Email = email;
        CountryId = countryId;
        UserId = userId;
    }

    public string? CompanyName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public int? CountryId { get; set; }

    public string? UserId { get; set; }

    public virtual ICollection<CommercialOffer> CommercialOffers { get; set; } = new List<CommercialOffer>();

    public virtual Country? Country { get; set; }

    public virtual ICollection<Partnership> Partnerships { get; set; } = new List<Partnership>();

    public static Supplier Create(string? companyName, string? phoneNumber, string? email, int? countryId, string? userId)
    {
        return new Supplier(companyName, phoneNumber, email, countryId, userId);
    }
}
