using EquadisRJP.Domain.DomainExceptions;

namespace EquadisRJP.Domain.Entities;

public partial class Partnership : EntityBase
{
    public Partnership()
    {
    }

    private Partnership(int supplierId, int retailerId, DateTime startDate, DateTime? expiryDate)
    {
        SupplierId = supplierId;
        RetailerId = retailerId;
        StartDate = startDate;
        ExpiryDate = expiryDate;
        StatusId = (int)PartnershipStatus.Active;
    }


    public enum PartnershipStatus
    {
        Pending = 1,
        Active,
        Expired
    }


    public int? RetailerId { get; set; }

    public int? SupplierId { get; set; }

    public DateTime StartDate { get; private set; }

    public DateTime? ExpiryDate { get; set; }

    public int? StatusId { get; private set; }

    public virtual Retailer? Retailer { get; set; }

    public virtual Supplier? Supplier { get; set; }

    public static Partnership Create(int supplierId, int retailerId, DateTime startDate, DateTime? expiryDate)

    {
        return new Partnership(supplierId, retailerId, startDate, expiryDate);
    }


    public static Partnership Start(int supplierId, int retailerId, DateTime startDate, DateTime? expiryDate)
    {
        if (supplierId <= 0 || retailerId <= 0)
            throw new ArgumentException("Supplier and Retailer IDs must be valid.");

        if (expiryDate.HasValue && expiryDate <= startDate)
            throw new ArgumentException("Expiry date must be after start date.");

        return new Partnership(supplierId, retailerId, startDate, expiryDate);
    }
    // Business Rule: Expire
    public void Expire()
    {
        StatusId = (int)PartnershipStatus.Expired;
        ModifiedDate = DateTime.UtcNow;
    }

    // Business Rule: Renew
    public void Renew(DateTime newExpiryDate)
    {
        if (StatusId != (int)PartnershipStatus.Expired)
            throw new PartnershipExpiredException("Only expired partnerships can be renewed.");

        if (newExpiryDate <= DateTime.UtcNow)
            throw new ArgumentException("New expiry date must be in the future.");

        ExpiryDate = newExpiryDate;
        StatusId = (int)PartnershipStatus.Active;
        ModifiedDate = DateTime.UtcNow;
    }

    public bool IsActive() => StatusId == (int)PartnershipStatus.Active &&
                              (!ExpiryDate.HasValue || ExpiryDate > DateTime.UtcNow);

}
