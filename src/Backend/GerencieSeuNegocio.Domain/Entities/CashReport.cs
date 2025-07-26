using GerencieSeuNegocio.Domain.Enums;

namespace GerencieSeuNegocio.Domain.Entities
{
    public class CashReport : EntityBase
    {
        public int BusinessId { get; set; }
        public string? Description { get; set; }
        public CashType Type { get; set; } = CashType.Undefined;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
