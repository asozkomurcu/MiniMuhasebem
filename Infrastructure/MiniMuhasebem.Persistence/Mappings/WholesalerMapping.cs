using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMuhasebem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Persistence.Mappings
{
    public class WholesalerMapping : BaseEntityMapping<Wholesaler>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Wholesaler> builder)
        {
            builder.Property(x => x.WholesalerName)
                .IsRequired()
                .HasColumnName("WHOLESALER_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(2);


            builder.ToTable("WHOLESALERS");


        }
    }
}
