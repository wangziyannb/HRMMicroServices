﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Onboarding.Infrastructure.Data;

#nullable disable

namespace Onboarding.Infrastructure.Migrations
{
    [DbContext(typeof(OnboardingDbContext))]
    [Migration("20230502101145_init onboarding db")]
    partial class initonboardingdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Onboarding.Core.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeCategoryCode")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeRoleId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeStatusCode")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Middlename")
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("EmployeeCategoryCode");

                    b.HasIndex("EmployeeRoleId");

                    b.HasIndex("EmployeeStatusCode");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Onboarding.Core.Entities.EmployeeCategory", b =>
                {
                    b.Property<int>("LookupCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LookupCode"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("LookupCode");

                    b.ToTable("EmployeeCategories");
                });

            modelBuilder.Entity("Onboarding.Core.Entities.EmployeeRole", b =>
                {
                    b.Property<int>("LookupCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LookupCode"), 1L, 1);

                    b.Property<string>("ABBR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LookupCode");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("Onboarding.Core.Entities.EmployeeStatus", b =>
                {
                    b.Property<int>("LookupCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LookupCode"), 1L, 1);

                    b.Property<string>("ABBR")
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("LookupCode");

                    b.ToTable("EmployeeStatus");
                });

            modelBuilder.Entity("Onboarding.Core.Entities.Employee", b =>
                {
                    b.HasOne("Onboarding.Core.Entities.EmployeeCategory", "EmployeeCategory")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeCategoryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Onboarding.Core.Entities.EmployeeRole", "EmployeeRole")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Onboarding.Core.Entities.EmployeeStatus", "EmployeeStatus")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeStatusCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeCategory");

                    b.Navigation("EmployeeRole");

                    b.Navigation("EmployeeStatus");
                });

            modelBuilder.Entity("Onboarding.Core.Entities.EmployeeCategory", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Onboarding.Core.Entities.EmployeeRole", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Onboarding.Core.Entities.EmployeeStatus", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}