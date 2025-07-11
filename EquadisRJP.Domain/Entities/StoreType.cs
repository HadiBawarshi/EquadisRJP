namespace EquadisRJP.Domain.Entities;

public partial class StoreType : EntityBase
{

    public string? Title { get; set; }

    public virtual ICollection<Retailer> Retailers { get; set; } = new List<Retailer>();
}
