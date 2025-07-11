namespace EquadisRJP.Application.Common
{
    public interface ICurrentParty
    {
        int? SupplierId { get; }
        int? RetailerId { get; }
    }
}
