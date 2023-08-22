using MiniMuhasebem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Domain.Entities
{
    public class MonthEnd : BaseEntity
    {
        public string RaporOlustur { get; set; }
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


        public Income Income { get; set; }
        public Order Order { get; set; }
        public Payment Payment { get; set; }
        public Debt Debt { get; set; }

    }
}
