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

            modelBuilder.Entity("PASEDM.Data.DTOs.AccessRightsDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AccessRights")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("AccessRightsValue")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("AccessRights");
                });

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

                    b.Property<DateTime>("DateOfFormation")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DocumentID")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("NameCard")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumberCard")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int?>("RecipientID")
                        .HasColumnType("int");

                    b.Property<int?>("TaskID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CaseID");

                    b.HasIndex("DocumentID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("RecipientID");

                    b.HasIndex("TaskID");

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

                    b.Property<string>("NumberCase")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

            modelBuilder.Entity("PASEDM.Data.DTOs.DocStagesDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DocStagesValue")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<string>("NameDocStage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("DocStages");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.DocumentDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateCreateDoc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DocStagesID")
                        .HasColumnType("int");

                    b.Property<int?>("DocumentTypesID")
                        .HasColumnType("int");

                    b.Property<string>("NameDoc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("RegistrationNumber")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<int?>("SecrecyStampsID")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("TermID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DocStagesID");

                    b.HasIndex("DocumentTypesID");

                    b.HasIndex("SecrecyStampsID");

                    b.HasIndex("TermID");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.DocumentTypesDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

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

                    b.Property<int?>("AccessRightsID")
                        .HasColumnType("int");

                    b.Property<int?>("DivisionID")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberEmployee")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccessRightsID");

                    b.HasIndex("DivisionID");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.MoveCardDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CardID")
                        .HasColumnType("int");

                    b.Property<int?>("TypeUserID")
                        .HasColumnType("int");

                    b.Property<int>("Viewed")
                        .HasMaxLength(1)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CardID");

                    b.HasIndex("TypeUserID");

                    b.ToTable("MoveCards");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.MoveDocumentDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("DocumentID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DocumentID");

                    b.HasIndex("UserID");

                    b.ToTable("MoveDocuments");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.RecipientDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Recipients");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.RoleDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("NameRole")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SignificanceRole")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.SecrecyStampDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("SecrecyStamp")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SecrecyStampValue")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SecrecyStamps");
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

                    b.Property<int?>("TaskStagesID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TaskStagesID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.TaskStagesDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("TaskStages")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TaskStagesValue")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("TaskStages");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.TermDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("NameTerm")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Term")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Deadlines");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.TypeUserDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("TypeUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TypeUserValue")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("TypeUsers");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.UserDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RecordConfirmation")
                        .HasMaxLength(1)
                        .HasColumnType("int");

                    b.Property<int?>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.CardDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.CaseDTO", "Case")
                        .WithMany("Cards")
                        .HasForeignKey("CaseID");

                    b.HasOne("PASEDM.Data.DTOs.DocumentDTO", "Document")
                        .WithMany("Cards")
                        .HasForeignKey("DocumentID");

                    b.HasOne("PASEDM.Data.DTOs.EmployeeDTO", "Employee")
                        .WithMany("Cards")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("PASEDM.Data.DTOs.RecipientDTO", "Recipient")
                        .WithMany("Cards")
                        .HasForeignKey("RecipientID");

                    b.HasOne("PASEDM.Data.DTOs.TaskDTO", "Task")
                        .WithMany("Cards")
                        .HasForeignKey("TaskID");

                    b.HasOne("PASEDM.Data.DTOs.UserDTO", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserID");

                    b.Navigation("Case");

                    b.Navigation("Document");

                    b.Navigation("Employee");

                    b.Navigation("Recipient");

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.DocumentDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.DocStagesDTO", "DocStages")
                        .WithMany("Documents")
                        .HasForeignKey("DocStagesID");

                    b.HasOne("PASEDM.Data.DTOs.DocumentTypesDTO", "DocumentTypes")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentTypesID");

                    b.HasOne("PASEDM.Data.DTOs.SecrecyStampDTO", "SecrecyStamps")
                        .WithMany("Documents")
                        .HasForeignKey("SecrecyStampsID");

                    b.HasOne("PASEDM.Data.DTOs.TermDTO", "Term")
                        .WithMany("Documents")
                        .HasForeignKey("TermID");

                    b.Navigation("DocStages");

                    b.Navigation("DocumentTypes");

                    b.Navigation("SecrecyStamps");

                    b.Navigation("Term");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.EmployeeDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.AccessRightsDTO", "AccessRights")
                        .WithMany("Staff")
                        .HasForeignKey("AccessRightsID");

                    b.HasOne("PASEDM.Data.DTOs.DivisionDTO", "Division")
                        .WithMany("Employee")
                        .HasForeignKey("DivisionID");

                    b.Navigation("AccessRights");

                    b.Navigation("Division");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.MoveCardDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.CardDTO", "Card")
                        .WithMany("MoveCards")
                        .HasForeignKey("CardID");

                    b.HasOne("PASEDM.Data.DTOs.TypeUserDTO", "TypeUser")
                        .WithMany("MoveCards")
                        .HasForeignKey("TypeUserID");

                    b.Navigation("Card");

                    b.Navigation("TypeUser");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.MoveDocumentDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.DocumentDTO", "Document")
                        .WithMany("MoveDocuments")
                        .HasForeignKey("DocumentID");

                    b.HasOne("PASEDM.Data.DTOs.UserDTO", "User")
                        .WithMany("MoveDocuments")
                        .HasForeignKey("UserID");

                    b.Navigation("Document");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.RecipientDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.UserDTO", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.TaskDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.TaskStagesDTO", "TaskStages")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskStagesID");

                    b.Navigation("TaskStages");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.UserDTO", b =>
                {
                    b.HasOne("PASEDM.Data.DTOs.EmployeeDTO", "Employee")
                        .WithMany("Users")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("PASEDM.Data.DTOs.RoleDTO", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID");

                    b.Navigation("Employee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.AccessRightsDTO", b =>
                {
                    b.Navigation("Staff");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.CardDTO", b =>
                {
                    b.Navigation("MoveCards");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.CaseDTO", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.DivisionDTO", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.DocStagesDTO", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.DocumentDTO", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("MoveDocuments");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.DocumentTypesDTO", b =>
                {
                    b.Navigation("Documents");
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

            modelBuilder.Entity("PASEDM.Data.DTOs.RoleDTO", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.SecrecyStampDTO", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.TaskDTO", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.TaskStagesDTO", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.TermDTO", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.TypeUserDTO", b =>
                {
                    b.Navigation("MoveCards");
                });

            modelBuilder.Entity("PASEDM.Data.DTOs.UserDTO", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("MoveDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}
