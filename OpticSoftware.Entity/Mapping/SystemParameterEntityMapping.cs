using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpticSoftware.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Entity.Mapping
{
    public class SystemParameterEntityMapping : IEntityTypeConfiguration<SystemParameterEntity>
    {
        public void Configure(EntityTypeBuilder<SystemParameterEntity> builder)
        {
            builder.Property(x => x.ID).UseIdentityAlwaysColumn();
            builder.Property(x => x.ParameterName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ParameterValue).HasMaxLength(1000).IsRequired();

            builder.HasIndex(x => x.ParameterName);
        }
    }
}
