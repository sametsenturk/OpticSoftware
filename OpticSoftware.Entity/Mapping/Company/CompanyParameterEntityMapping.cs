using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpticSoftware.Entity.Entities.Company;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Entity.Mapping.Company
{
    public class CompanyParameterEntityMapping : IEntityTypeConfiguration<CompanyParameterEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyParameterEntity> builder)
        {
            builder.Property(x => x.ID).UseIdentityAlwaysColumn();
            builder.Property(x => x.ParameterName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ParameterValue).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.CompanyID).IsRequired();

            builder.HasIndex(x => x.ParameterName);
            builder.HasIndex(x => x.CompanyID);
        }
    }
}
