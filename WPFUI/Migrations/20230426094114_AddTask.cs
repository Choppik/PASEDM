using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class AddTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Documents_DocumentID",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropColumn(
                name: "GenericTask",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "TermOfExecution",
                table: "Recipients");

            migrationBuilder.RenameColumn(
                name: "DocumentID",
                table: "Cards",
                newName: "TaskID");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_DocumentID",
                table: "Cards",
                newName: "IX_Cards_TaskID");

            migrationBuilder.AddColumn<string>(
                name: "Admin",
                table: "Users",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Staff",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TaskID",
                table: "Recipients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfFormationDocument",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DocumentRegistrationNumber",
                table: "Cards",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypesID",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Cards",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NameCard",
                table: "Cards",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeDocumentID",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTask = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_TaskID",
                table: "Recipients",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TypeDocumentID",
                table: "Cards",
                column: "TypeDocumentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_DocumentTypes_TypeDocumentID",
                table: "Cards",
                column: "TypeDocumentID",
                principalTable: "DocumentTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Tasks_TaskID",
                table: "Cards",
                column: "TaskID",
                principalTable: "Tasks",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Tasks_TaskID",
                table: "Recipients",
                column: "TaskID",
                principalTable: "Tasks",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_DocumentTypes_TypeDocumentID",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Tasks_TaskID",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Tasks_TaskID",
                table: "Recipients");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_TaskID",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Cards_TypeDocumentID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "TaskID",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "DateOfFormationDocument",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DocumentRegistrationNumber",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DocumentTypesID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "File",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "NameCard",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "TypeDocumentID",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "TaskID",
                table: "Cards",
                newName: "DocumentID");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_TaskID",
                table: "Cards",
                newName: "IX_Cards_DocumentID");

            migrationBuilder.AddColumn<string>(
                name: "GenericTask",
                table: "Recipients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "TermOfExecution",
                table: "Recipients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfFormation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegistrationNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    TypeDocument = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Documents_DocumentID",
                table: "Cards",
                column: "DocumentID",
                principalTable: "Documents",
                principalColumn: "ID");
        }
    }
}
