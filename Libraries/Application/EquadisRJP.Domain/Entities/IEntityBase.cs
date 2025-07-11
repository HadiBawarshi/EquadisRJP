namespace EquadisRJP.Domain.Entities
{
    public interface IEntityBase
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        //public bool? IsDeleted { get; set; }
    }
}
