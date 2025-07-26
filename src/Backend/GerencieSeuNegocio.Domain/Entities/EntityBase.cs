namespace GerencieSeuNegocio.Domain.Entities
{
    public class EntityBase
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
