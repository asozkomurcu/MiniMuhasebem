using MiniMuhasebem.Domain.Entities;

namespace MiniMuhasebem.Application.Models.RequestModels.PaymentRM
{
    public class CreatePaymentVM
    {
        public int WholesalerId { get; set; }
        public decimal OrderPayment { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
