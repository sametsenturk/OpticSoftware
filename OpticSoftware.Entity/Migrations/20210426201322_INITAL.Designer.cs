﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OpticSoftware.Entity.Context;

namespace OpticSoftware.Entity.Migrations
{
    [DbContext(typeof(OpticDBContext))]
    [Migration("20210426201322_INITAL")]
    partial class INITAL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("OpticSoftware.Entity.Entities.Company.CompanyEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("SMSCount")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("OpticSoftware.Entity.Entities.Company.CompanyParameterEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<long>("CompanyID")
                        .HasColumnType("bigint");

                    b.Property<string>("ParameterName")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ParameterValue")
                        .IsRequired()
                        .HasColumnType("character varying(1000)")
                        .HasMaxLength(1000);

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("ParameterName");

                    b.ToTable("CompanyParameters");
                });

            modelBuilder.Entity("OpticSoftware.Entity.Entities.SystemParameterEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("ParameterName")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ParameterValue")
                        .IsRequired()
                        .HasColumnType("character varying(1000)")
                        .HasMaxLength(1000);

                    b.HasKey("ID");

                    b.HasIndex("ParameterName");

                    b.ToTable("SystemParameters");
                });

            modelBuilder.Entity("OpticSoftware.Entity.Entities.User.UserDetailEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<long>("CompanyID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.Property<int>("UserType")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("UserID");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("OpticSoftware.Entity.Entities.User.UserEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OpticSoftware.Entity.Entities.Company.CompanyParameterEntity", b =>
                {
                    b.HasOne("OpticSoftware.Entity.Entities.Company.CompanyEntity", "Company")
                        .WithMany("CompanyParameters")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpticSoftware.Entity.Entities.User.UserDetailEntity", b =>
                {
                    b.HasOne("OpticSoftware.Entity.Entities.Company.CompanyEntity", "Company")
                        .WithMany("UserDetails")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpticSoftware.Entity.Entities.User.UserEntity", "User")
                        .WithMany("UserDetails")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}