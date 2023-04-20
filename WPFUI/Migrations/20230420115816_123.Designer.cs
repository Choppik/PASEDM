﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PASEDM.Data;

#nullable disable

namespace PASEDM.Migrations
{
    [DbContext(typeof(PASEDMContext))]
    [Migration("20230420115816_123")]
    partial class _123
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PASEDM.Data.DTOs.DivisionDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Division")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.EmployeeDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DivisionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.UserDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.EmployeeDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.DivisionDTO", "Division")
                        .WithMany("Employee")
                        .HasForeignKey("DivisionId");

                    b.Navigation("Division");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.UserDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.EmployeeDTO", "Employee")
                        .WithMany("Users")
                        .HasForeignKey("EmployeeID");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.DivisionDTO", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.EmployeeDTO", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
