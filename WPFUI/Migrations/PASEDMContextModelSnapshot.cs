﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PASEDM.Data;

#nullable disable

namespace PASEDM.Migrations
{
    [DbContext(typeof(PASEDMContext))]
    partial class PASEDMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PASEDM.Data.DTOs.CardDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CaseID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateOfFormation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfFormationDocument")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentRegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("DocumentTypesID")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("NameCard")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<int>("NumberCard")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int?>("RecipientID")
                        .HasColumnType("int");

                    b.Property<string>("SecrecyStamp")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TaskID")
                        .HasColumnType("int");

                    b.Property<int>("TypeDocumentID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CaseID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("RecipientID");

                    b.HasIndex("TaskID");

                    b.HasIndex("TypeDocumentID");

                    b.HasIndex("UserID");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.CaseDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Desription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberCase")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.DivisionDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Division")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumberDivision")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.DocumentTypesDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.EmployeeDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("DivisionID")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumberEmployee")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DivisionID");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.RecipientDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("NumberRecipient")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int?>("TaskID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TaskID");

                    b.HasIndex("UserID");

                    b.ToTable("Recipients");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.TaskDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Contents")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("NameTask")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.UserDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Admin")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

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

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.CardDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.CaseDTO", "Case")
                        .WithMany("Cards")
                        .HasForeignKey("CaseID");

                    b.HasOne("PASEDM.Data.DTOs.EmployeeDTO", "Employee")
                        .WithMany("Cards")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("PASEDM.Data.DTOs.RecipientDTO", "Recipient")
                        .WithMany("Cards")
                        .HasForeignKey("RecipientID");

                    b.HasOne("PASEDM.Data.DTOs.TaskDTO", "Task")
                        .WithMany("Cards")
                        .HasForeignKey("TaskID");

                    b.HasOne("PASEDM.Data.DTOs.DocumentTypesDTO", "TypeDocument")
                        .WithMany("Cards")
                        .HasForeignKey("TypeDocumentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PASEDM.Data.DTOs.UserDTO", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserID");

                    b.Navigation("Case");

                    b.Navigation("Employee");

                    b.Navigation("Recipient");

                    b.Navigation("Task");

                    b.Navigation("TypeDocument");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.EmployeeDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.DivisionDTO", "Division")
                        .WithMany("Employee")
                        .HasForeignKey("DivisionID");

                    b.Navigation("Division");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.RecipientDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.TaskDTO", "Task")
                        .WithMany("Recipients")
                        .HasForeignKey("TaskID");

                    b.HasOne("PASEDM.Data.DTOs.UserDTO", "User")
                        .WithMany("Recipients")
                        .HasForeignKey("UserID");

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.UserDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.EmployeeDTO", "Employee")
                        .WithMany("Users")
                        .HasForeignKey("EmployeeID");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.CaseDTO", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.DivisionDTO", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.DocumentTypesDTO", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.EmployeeDTO", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.RecipientDTO", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.TaskDTO", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Recipients");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.UserDTO", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Recipients");
                });
#pragma warning restore 612, 618
        }
    }
}
