namespace GerencieSeuNegocio.Domain.Entities
{
    public class Customer : EntityBase
    {
        public int BusinessId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Document { get; set; }
    }
}
