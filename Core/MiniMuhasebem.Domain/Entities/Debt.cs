﻿using MiniMuhasebem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Domain.Entities
{
    public class Debt : AuditableEntity
    {
        public int? WholesalerId { get; set; }
        public decimal OrderDebt { get; set; }
        public decimal? TotalDebt { get; set; }

        public Wholesaler Wholesaler { get; set; }
        public ICollection<MonthEnd> MonthEnds { get; set; }
    }
}
