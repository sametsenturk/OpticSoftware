using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpticSoftware.Entity.Entities.Company;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Entity.Mapping.Company
{
    public class CompanyEntityMapping : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder.Property(x => x.ID).UseIdentityAlwaysColumn();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ExpireDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.SMSCount).IsRequired();

            builder.HasIndex(x => x.ID);
        }
    }
}
