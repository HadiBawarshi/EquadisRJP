namespace EquadisRJP.Domain.Entities;

public partial class Country : EntityBase
{
    public Country()
    {
    }

    private Country(string? title)
    {
        Title = title;
    }

    public string? Title { get; private set; }

    public virtual ICollection<Supplier> Suppliers { get; private set; } = new List<Supplier>();

    public static Country Create(string? title)
    {
        return new Country(title);
    }
}
