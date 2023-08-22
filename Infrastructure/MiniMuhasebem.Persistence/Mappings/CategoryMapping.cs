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
    public class CategoryMapping : AuditableEntityMapping<Category>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName)
                .IsRequired()
                .HasColumnType("nvarchar(100)")
                .HasColumnName("CATEGORY_NAME")
                .HasColumnOrder(2);

            builder.ToTable("CATEGORIES");
        }
    }
}
