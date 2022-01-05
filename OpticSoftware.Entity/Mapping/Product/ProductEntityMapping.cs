using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpticSoftware.Entity.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Entity.Mapping.Product
{
    public class ProductEntityMapping : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(x => x.ID).UseIdentityAlwaysColumn();
            
            builder.Property(x => x.ImageUrl).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Model).HasMaxLength(30);
            builder.Property(x => x.Description).HasMaxLength(125);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.StockCount).HasDefaultValue(0).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.ProductCategoryID).IsRequired();
            
            builder.HasIndex(x => x.ID);
        }
    }
}
