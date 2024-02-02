﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registration.Data;

#nullable disable

namespace Registration.Migrations
{
    [DbContext(typeof(RegistrationDbContext))]
    [Migration("20240126182843_Seeding Data For Companies and Users")]
    partial class SeedingDataForCompaniesandUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Registration.Models.Domain.Branch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Registration.Models.Domain.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a0481244-7096-452c-8a26-1dd46d3ebe06"),
                            BranchId = new Guid("6b13fc40-ca47-1067-b31d-00dd010662da"),
                            Name = "CompanyName1"
                        },
                        new
                        {
                            Id = new Guid("a8ba4c30-7513-41eb-854b-7325b5efd316"),
                            BranchId = new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"),
                            Name = "CompanyName2"
                        },
                        new
                        {
                            Id = new Guid("dc68dd36-3724-4499-9275-5cd0d57071c2"),
                            BranchId = new Guid("6b05fc40-ca47-1067-b31d-00dd010662da"),
                            Name = "CompanyName3"
                        });
                });

            modelBuilder.Entity("Registration.Models.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae88b444-4e3d-4085-9487-5af928251e95"),
                            CompanyId = new Guid("a0481244-7096-452c-8a26-1dd46d3ebe06"),
                            Email = "Username1@gmail.com",
                            FirstName = "FirstName1",
                            LastName = "LastName1",
                            Password = "Password1",
                            Username = "Username1"
                        },
                        new
                        {
                            Id = new Guid("e667decc-a5a8-46f1-a500-566001c4bbb2"),
                            CompanyId = new Guid("a8ba4c30-7513-41eb-854b-7325b5efd316"),
                            Email = "Username2@gmail.com",
                            FirstName = "FirstName2",
                            LastName = "LastName2",
                            Password = "Password2",
                            Username = "Username2"
                        },
                        new
                        {
                            Id = new Guid("de861852-adc7-41aa-86f2-c6e4bd502eab"),
                            CompanyId = new Guid("dc68dd36-3724-4499-9275-5cd0d57071c2"),
                            Email = "Username3@gmail.com",
                            FirstName = "FirstName3",
                            LastName = "LastName3",
                            Password = "Password3",
                            Username = "Username3"
                        });
                });

            modelBuilder.Entity("Registration.Models.Domain.Company", b =>
                {
                    b.HasOne("Registration.Models.Domain.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("Registration.Models.Domain.User", b =>
                {
                    b.HasOne("Registration.Models.Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}
