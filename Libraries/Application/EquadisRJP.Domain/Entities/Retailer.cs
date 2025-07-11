namespace EquadisRJP.Domain.Entities;

public partial class Retailer : EntityBase
{
    public Retailer()
    {
    }

    private Retailer(string? storeName, int? storeTypeId, string? location, string? userId)
    {
        StoreName = storeName;
        StoreTypeId = storeTypeId;
        Location = location;
        UserId = userId;
    }

    public string? StoreName { get; set; }

    public int? StoreTypeId { get; set; }

    public string? Location { get; set; }

    public string? UserId { get; set; }

    public virtual ICollection<Partnership> Partnerships { get; set; } = new List<Partnership>();

    public virtual StoreType? StoreType { get; set; }

    public static Retailer Create(string? storeName, int? storeTypeId, string? location, string? userId)
    {
        return new Retailer(storeName, storeTypeId, location, userId);
    }
}
