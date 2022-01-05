using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpticSoftware.Entity.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Entity.Mapping.Product
{   
    public class ProductCategoryEntityMapping : IEntityTypeConfiguration<ProductCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            builder.Property(x => x.ID).UseIdentityAlwaysColumn();
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.CompanyID).IsRequired();

            builder.HasIndex(x => x.ID);
        }
    }
}
