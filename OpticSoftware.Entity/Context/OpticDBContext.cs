using Microsoft.EntityFrameworkCore;
using OpticSoftware.Entity.Entities;
using OpticSoftware.Entity.Entities.Company;
using OpticSoftware.Entity.Entities.Product;
using OpticSoftware.Entity.Entities.User;
using OpticSoftware.Entity.Mapping;
using OpticSoftware.Entity.Mapping.Company;
using OpticSoftware.Entity.Mapping.Product;
using OpticSoftware.Entity.Mapping.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Entity.Context
{
    public class OpticDBContext : DbContext
    {

        public OpticDBContext(DbContextOptions<OpticDBContext> dbContextOptions) : base(dbContextOptions)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        #region User 
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserDetailEntity> UserDetails { get; set; }
        #endregion


        #region Company
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<CompanyParameterEntity> CompanyParameters { get; set; }
        #endregion

        #region Product
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        #endregion

        public DbSet<SystemParameterEntity> SystemParameters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Company
            modelBuilder.ApplyConfiguration(new CompanyEntityMapping());
            modelBuilder.ApplyConfiguration(new CompanyParameterEntityMapping());
            #endregion

            #region User
            modelBuilder.ApplyConfiguration(new UserEntityMapping());
            modelBuilder.ApplyConfiguration(new UserDetailEntityMapping());
            #endregion

            #region Product
            modelBuilder.ApplyConfiguration(new ProductEntityMapping());
            modelBuilder.ApplyConfiguration(new ProductCategoryEntityMapping());
            #endregion

            modelBuilder.ApplyConfiguration(new SystemParameterEntityMapping());
        }

    }
}
