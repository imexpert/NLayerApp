using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).UseIdentityColumn();
            builder.Property(s => s.Name).IsRequired().HasMaxLength(200);
            builder.Property(s => s.Stock).IsRequired();
            builder.Property(s => s.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.ToTable("Products");

            builder.HasOne(s => s.Category).WithMany(s => s.Products).HasForeignKey(s => s.CategoryId);
        }
    }
}
