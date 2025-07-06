namespace EquadisRJP.Domain.Entities;

public partial class CommercialOffer : EntityBase
{

    public string? Title { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public int? DiscountValuePercentage { get; set; }

    public int? SupplierId { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
