using MiniMuhasebem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Domain.Entities
{
    public class Income : AuditableEntity
    {
        public DateTime Date { get; set; }
        public decimal Cash { get; set; }
        public decimal CreditCard1 { get; set; }
        public decimal? CreditCard2 { get; set; }
        public decimal? TotalIncome { get; set; }


        public ICollection<MonthEnd> MonthEnds { get; set; }
    }

}

