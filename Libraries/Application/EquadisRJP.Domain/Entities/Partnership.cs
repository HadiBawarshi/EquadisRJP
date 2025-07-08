namespace EquadisRJP.Domain.Entities;

public partial class Partnership : EntityBase
{
    public Partnership()
    {
    }

    private Partnership(int? retailerId, int? supplierId, DateTime? expiryDate)
    {
        RetailerId = retailerId;
        SupplierId = supplierId;
        ExpiryDate = expiryDate;

    }

    public int? RetailerId { get; set; }

    public int? SupplierId { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public virtual Retailer? Retailer { get; set; }

    public virtual Supplier? Supplier { get; set; }


    public static Partnership Create(int? retailerId, int? supplierId, DateTime? expiryDate)
    {
        return new Partnership(retailerId, supplierId, expiryDate);
    }
}
