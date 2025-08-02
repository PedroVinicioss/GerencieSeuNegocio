namespace GerencieSeuNegocio.Domain.Entities
{
    public class EntityBase
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; } = Guid.NewGuid();
        public bool Active { get; set; } = true;
        public DateTime CreatOn { get; set; } = DateTime.UtcNow;
    }
}
