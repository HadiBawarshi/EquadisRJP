namespace EquadisRJP.Domain.Entities;

public partial class StoreType : EntityBase
{

    public StoreType()
    {
    }

    private StoreType(string? title)
    {
        Title = title;
    }

    public string? Title { get; set; }

    public virtual ICollection<Retailer> Retailers { get; set; } = new List<Retailer>();

    public static StoreType Create(string? title)
    {
        return new StoreType(title);
    }
}
