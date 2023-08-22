using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MiniMuhasebem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Persistence.Mappings
{
    public class MonthEndMapping : BaseEntityMapping<MonthEnd>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<MonthEnd> builder)
        {
            builder.Property(x => x.RaporOlustur)
                .IsRequired()
                .HasColumnName("RAPOR_OLUSTUR")
                .HasColumnOrder(2);

            builder.Property(x => x.IncomeId)
                .IsRequired()
                .HasColumnName("INCOME_ID")
                .HasColumnOrder(3);

            builder.Property(x => x.TotalIncome)
                .IsRequired()
                .HasColumnName("TOTAL_INCOME")
                .HasColumnType("decimal")
                .HasColumnOrder(3);

            builder.Property(x => x.OrderId)
                .IsRequired()
                .HasColumnName("ORDER_ID")
                .HasColumnOrder(4);

            builder.Property(x => x.TotalOrderPrice)
                .IsRequired()
                .HasColumnName("TOTAL_ORDER_PRICE")
                .HasColumnType("decimal")
                .HasColumnOrder(4);

            builder.Property(x => x.PaymentId)
                .IsRequired()
                .HasColumnName("PAYMENT_ID")
                .HasColumnOrder(5);

            builder.Property(x => x.TotalPayment)
                .IsRequired()
                .HasColumnName("TOTAL_PAYMENT")
                .HasColumnType("decimal")
                .HasColumnOrder(5);

            builder.Property(x => x.DebtId)
                .IsRequired()
                .HasColumnName("DEBT_ID")
                .HasColumnOrder(7);

            builder.Property(x => x.TotalDebt)
                .IsRequired()
                .HasColumnName("TOTAL_DEBT")
                .HasColumnType("decimal")
                .HasColumnOrder(7);

            builder.Property(x => x.Month)
                .IsRequired()
                .HasColumnName("MONTH")
                .HasColumnOrder(8);

            builder.Property(x => x.TotalPrice)
                .IsRequired()
                .HasColumnName("TOTAL_PRICE")
                .HasColumnType("decimal")
                .HasColumnOrder(9);

            builder.Property(x => x.TransferPrice)
                .IsRequired()
                .HasColumnName("TRANSFER_PRICE")
                .HasColumnType("decimal")
                .HasColumnOrder(10);

            builder.HasOne(x => x.Income)
                .WithMany(x => x.MonthEnds)
                .HasForeignKey(x => x.IncomeId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("MONTHENDS_INCOME_INCOME_ID");

            builder.HasOne(x => x.Order)
                .WithMany(x => x.MonthEnds)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("MONTHENDS_ORDER_ORDER_ID");

            builder.HasOne(x => x.Payment)
                .WithMany(x => x.MonthEnds)
                .HasForeignKey(x => x.PaymentId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("MONTHENDS_PAYMENT_PAYMENT_ID");

            builder.HasOne(x => x.Debt)
                .WithMany(x => x.MonthEnds)
                .HasForeignKey(x => x.DebtId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("MONTHENDS_DEBT_DEBT_ID");

            builder.ToTable("MONTHS_END");
        }
    }
}
