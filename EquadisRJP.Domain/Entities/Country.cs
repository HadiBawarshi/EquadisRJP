namespace EquadisRJP.Domain.Entities;

public partial class Country : EntityBase
{

    public string? Title { get; set; }

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
