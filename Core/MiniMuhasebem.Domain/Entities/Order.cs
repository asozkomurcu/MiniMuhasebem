﻿using MiniMuhasebem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public int? WholesalerId { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal? TotalOrderPrice { get; set; }

        public Wholesaler Wholesaler { get; set; }
        public ICollection<MonthEnd> MonthEnds { get; set; }


    }
}
