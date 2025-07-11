namespace EquadisRJP.Domain.Entities;

public partial class Partnership : EntityBase
{

    public int? RetailerId { get; set; }

    public int? SupplierId { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public virtual Retailer? Retailer { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
