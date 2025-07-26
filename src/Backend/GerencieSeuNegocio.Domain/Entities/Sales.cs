using GerencieSeuNegocio.Domain.Enums;

namespace GerencieSeuNegocio.Domain.Entities
{
    public class Sales : EntityBase
    {
        public int BusinessId { get; set; }
        public int? CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public SalesStatusType Status { get; set; } = SalesStatusType.Pending;
        public PaymentMethodType PaymentMethod { get; set; } = PaymentMethodType.Undefined;
    }
}
