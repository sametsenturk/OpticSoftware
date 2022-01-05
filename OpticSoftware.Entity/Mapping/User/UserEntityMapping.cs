using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpticSoftware.Entity.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Entity.Mapping.User
{
    public class UserEntityMapping : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.ID).UseIdentityAlwaysColumn();
            builder.Property(x => x.Username).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(255).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.Language).IsRequired();
        }
    }
}
