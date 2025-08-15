using GerencieSeuNegocio.Domain.Enums;

namespace GerencieSeuNegocio.Domain.Entities
{
    public class Stay : EntityBase
    {
        public int BusinessId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalAmount { get; set; } = 0.0m;
        public StayStatusType Status { get; set; } = StayStatusType.Pending;
        public PaymentMethodType PaymentMethod { get; set; } = PaymentMethodType.Undefined;
    }
}
