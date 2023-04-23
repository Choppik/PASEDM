using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class AddAllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Divisions_DivisionId",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DivisionId",
                table: "Staff",
                newName: "DivisionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Staff",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_DivisionId",
                table: "Staff",
                newName: "IX_Staff_DivisionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Recipients",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Divisions",
                newName: "ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Recipients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberCase = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Desription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    View = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfFormation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberCard = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    DateOfFormation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecrecyStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DocumentsID = table.Column<int>(type: "int", nullable: true),
                    DocumentID = table.Column<int>(type: "int", nullable: false),
                    CaseID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    RecipientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cards_Cases_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Cases",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cards_Documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "Documents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Recipients_RecipientID",
                        column: x => x.RecipientID,
                        principalTable: "Recipients",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cards_Staff_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Staff",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_UserID",
                table: "Recipients",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CaseID",
                table: "Cards",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DocumentID",
                table: "Cards",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_EmployeeID",
                table: "Cards",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_RecipientID",
                table: "Cards",
                column: "RecipientID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserID",
                table: "Cards",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Users_UserID",
                table: "Recipients",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Divisions_DivisionID",
                table: "Staff",
                column: "DivisionID",
                principalTable: "Divisions",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Users_UserID",
                table: "Recipients");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Divisions_DivisionID",
                table: "Staff");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_UserID",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Recipients");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DivisionID",
                table: "Staff",
                newName: "DivisionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Staff",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_DivisionID",
                table: "Staff",
                newName: "IX_Staff_DivisionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Recipients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Divisions",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Divisions_DivisionId",
                table: "Staff",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id");
        }
    }
}
