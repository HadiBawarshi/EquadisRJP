namespace EquadisRJP.Domain.Entities;

public partial class Supplier : EntityBase
{

    public string? CompanyName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public int? CountryId { get; set; }

    public string? UserId { get; set; }

    public virtual ICollection<CommercialOffer> CommercialOffers { get; set; } = new List<CommercialOffer>();

    public virtual Country? Country { get; set; }

    public virtual ICollection<Partnership> Partnerships { get; set; } = new List<Partnership>();
}
