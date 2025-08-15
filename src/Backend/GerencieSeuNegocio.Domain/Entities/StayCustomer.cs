namespace GerencieSeuNegocio.Domain.Entities
{
    public class StayCustomer : EntityBase
    {
        public int StayId { get; set; }
        public int CustomerId { get; set; }
        public bool IsPrimary { get; set; } = false;
    }
}
