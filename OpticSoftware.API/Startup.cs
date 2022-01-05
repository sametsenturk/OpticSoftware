using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpticSoftware.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpticSoftware.Core;
using OpticSoftware.Entity.Entities;
using OpticSoftware.Entity.Entities.User;
using OpticSoftware.Entity.Entities.Company;
using OpticSoftware.Security.Abstract;
using OpticSoftware.Security.Concrate;
using AutoMapper;
using OpticSoftware.API.Profiles.User;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OpticSoftware.BLL.Operation.UserOperations;
using OpticSoftware.DAL.Abstract.Company;
using OpticSoftware.DAL.Concrate.Company;
using OpticSoftware.DAL.Abstract.User;
using OpticSoftware.DAL.Concrate.User;
using OpticSoftware.DAL.Abstract;
using OpticSoftware.DAL.Concrate;
using OpticSoftware.Authentication;
using OpticSoftware.Entity.Entities.Product;
using OpticSoftware.DAL.Abstract.Product;
using OpticSoftware.DAL.Concrate.Product;
using OpticSoftware.BLL.Operation.SystemOperations;
using OpticSoftware.BLL.Operation.ProductOperations;
using OpticSoftware.API.Profiles.Product;

namespace OpticSoftware.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<OpticDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("LocalConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRepository<SystemParameterEntity>, Repository<SystemParameterEntity>>();

            #region User 
            services.AddScoped<IRepository<UserEntity>, Repository<UserEntity>>();
            services.AddScoped<IRepository<UserDetailEntity>, Repository<UserDetailEntity>>();
            #endregion

            #region Company
            services.AddScoped<IRepository<CompanyEntity>, Repository<CompanyEntity>>();
            services.AddScoped<IRepository<CompanyParameterEntity>, Repository<CompanyParameterEntity>>();
            #endregion

            #region Product
            services.AddScoped<IRepository<ProductEntity>, Repository<ProductEntity>>();
            services.AddScoped<IRepository<ProductCategoryEntity>, Repository<ProductCategoryEntity>>();
            #endregion

            services.AddSingleton<IHash, SHA512Hash>();
            services.AddSingleton<JWTHelper>();


            services.AddScoped<ICompanyParameterService, CompanyParameterService>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDetailService, UserDetailService>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();


            services.AddScoped<IUserDetailService, UserDetailService>();


            services.AddScoped<ISystemParameterService, SystemParameterService>();            

            services.AddScoped<SystemParameterOperations, SystemParameterOperations>();
            services.AddScoped<AuthenticationOperationValidator, AuthenticationOperationValidator>();
            services.AddScoped<UserOperations.AuthenticationOperations, UserOperations.AuthenticationOperations>();


            services.AddScoped<ProductCategoryOperationValidator, ProductCategoryOperationValidator>();
            services.AddScoped<ProductCategoryOperations, ProductCategoryOperations>();


            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("JWTSecret").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile(provider.GetService<IHash>()));
                cfg.AddProfile(new ProductProfile());
            }).CreateMapper());

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
