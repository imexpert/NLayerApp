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
    public class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).UseIdentityColumn();
            builder.Property(s => s.Height).IsRequired();
            builder.Property(s => s.Width).IsRequired();
            builder.Property(s => s.Color).IsRequired().HasMaxLength(50);
            

            builder.ToTable("ProductFeatures");

            builder.HasOne(s => s.Product).WithOne(s => s.ProductFeature).HasForeignKey<ProductFeature>(s => s.ProductId);
        }
    }
}
