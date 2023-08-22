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
    public class PaymentMapping : AuditableEntityMapping<Payment>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(x => x.WholesalerId)
                .IsRequired(false)
                .HasColumnName("WHOLESALER_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.OrderPayment)
                .IsRequired()
                .HasColumnName("ORDER_PAYMENT")
                .HasColumnOrder(3);

            builder.Property(x => x.TotalPayment)
                .IsRequired(false)
                .HasColumnName("TOTAL_PAYMENT")
                .HasColumnOrder(4);

            builder.Property(x => x.PaymentType)
                .IsRequired()
                .HasColumnName("PAYMENT_TYPE")
                .HasColumnOrder(5);

            builder.HasOne(x => x.Wholesaler)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.WholesalerId)
                .HasConstraintName("PEYMENT_WHOLESALER_WHOLESALER_ID");

            builder.ToTable("PAYMENTS");
        }
    }
}
