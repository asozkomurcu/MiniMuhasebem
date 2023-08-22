using MiniMuhasebem.Application.Models.Dtos.DebtDtos;
using MiniMuhasebem.Application.Models.Dtos.IncomeDtos;
using MiniMuhasebem.Application.Models.Dtos.PaymentDtos;
using MiniMuhasebem.Application.Models.Dtos.WholasalerDtos;

namespace MiniMuhasebem.Application.Models.Dtos.MonthEndDtos
{
    public class MonthEndDto
    {

        public int Id { get; set; }
        public int IncomeId { get; set; }
        public decimal TotalIncome { get; set; }
        public int OrderId { get; set; }
        public decimal TotalOrderPrice { get; set; }
        public int PaymentId { get; set; }
        public decimal TotalPayment { get; set; }
        public int DebtId { get; set; }
        public decimal TotalDebt { get; set; }
        public DateTime Month { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? TransferPrice { get; set; }

        public IncomeDto Income { get; set; }
        public WholesalerDto Wholasaler { get; set; }
        public PaymentDto Payment { get; set; }
        public DebtDto Debt { get; set; }

    }
}
