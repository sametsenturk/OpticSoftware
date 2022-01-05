using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpticSoftware.Entity.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Entity.Mapping.User
{
    public class UserDetailEntityMapping : IEntityTypeConfiguration<UserDetailEntity>
    {
        public void Configure(EntityTypeBuilder<UserDetailEntity> builder)
        {
            builder.Property(x => x.ID).UseIdentityAlwaysColumn();
            builder.Property(x => x.Name).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(25).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Roles).HasMaxLength(50).IsRequired();
            builder.Property(x => x.UserType).IsRequired();

            builder.Property(x => x.UserID).IsRequired();
            builder.Property(x => x.CompanyID).IsRequired();

            builder.HasIndex(x => x.UserID);
        }
    }
}
