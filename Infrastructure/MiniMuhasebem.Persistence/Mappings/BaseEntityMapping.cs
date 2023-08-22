using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MiniMuhasebem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Persistence.Mappings
{
    public abstract class BaseEntityMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public abstract void ConfigureDerivedEntityMapping(EntityTypeBuilder<T> builder);

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .HasColumnOrder(1);

            //Intercepter
            ConfigureDerivedEntityMapping(builder);

            builder.Property(x => x.IsDeleted)
                .HasColumnName("IS_DELETED")
                .HasDefaultValueSql("0")
                .HasColumnOrder(30);
        }
    }
}
