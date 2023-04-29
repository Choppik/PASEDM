using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class AddDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberRecipient",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DateOfFormationDocument",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DocumentRegistrationNumber",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Staff",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "ConditionTask",
                table: "Tasks",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Admittance",
                table: "Staff",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DocumentID",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegistrationNumber = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    DateCreateDoc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConditionDoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DocumentID",
                table: "Cards",
                column: "DocumentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Documents_DocumentID",
                table: "Cards",
                column: "DocumentID",
                principalTable: "Documents",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Documents_DocumentID",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Cards_DocumentID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ConditionTask",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Admittance",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "DocumentID",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Staff",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "NumberRecipient",
                table: "Recipients",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Cards",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Cards",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
