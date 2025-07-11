
namespace EquadisRJP.Domain.Entities
{
    public abstract class EntityBase : IEntityBase
    {

        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
