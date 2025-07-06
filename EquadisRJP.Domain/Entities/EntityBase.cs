
namespace EquadisRJP.Domain.Entities
{
    public class EntityBase : IEntityBase
    {
        //private readonly List<IDomainEvent> _domainEvents = [];

        //public List<IDomainEvent> DomainEvents => [.. _domainEvents];

        //public void ClearDomainEvents()
        //{
        //    _domainEvents.Clear();
        //}

        //public void Raise(IDomainEvent domainEvent)
        //{
        //    _domainEvents.Add(domainEvent);
        //}
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
