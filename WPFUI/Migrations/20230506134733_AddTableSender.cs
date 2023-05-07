using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class AddTableSender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Recipients_RecipientID",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Users_UserID",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Tasks_TaskID",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Cards_RecipientID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DateOfReceipt",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "RecipientID",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "TaskID",
                table: "Recipients",
                newName: "CardID");

            migrationBuilder.RenameIndex(
                name: "IX_Recipients_TaskID",
                table: "Recipients",
                newName: "IX_Recipients_CardID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Cards",
                newName: "TaskID");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_UserID",
                table: "Cards",
                newName: "IX_Cards_TaskID");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfFormation",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Senders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    CardID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Senders_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Senders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Senders_CardID",
                table: "Senders",
                column: "CardID");

            migrationBuilder.CreateIndex(
                name: "IX_Senders_UserID",
                table: "Senders",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Tasks_TaskID",
                table: "Cards",
                column: "TaskID",
                principalTable: "Tasks",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Cards_CardID",
                table: "Recipients",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Tasks_TaskID",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Cards_CardID",
                table: "Recipients");

            migrationBuilder.DropTable(
                name: "Senders");

            migrationBuilder.DropColumn(
                name: "DateOfFormation",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "CardID",
                table: "Recipients",
                newName: "TaskID");

            migrationBuilder.RenameIndex(
                name: "IX_Recipients_CardID",
                table: "Recipients",
                newName: "IX_Recipients_TaskID");

            migrationBuilder.RenameColumn(
                name: "TaskID",
                table: "Cards",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_TaskID",
                table: "Cards",
                newName: "IX_Cards_UserID");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfReceipt",
                table: "Recipients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RecipientID",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_RecipientID",
                table: "Cards",
                column: "RecipientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Recipients_RecipientID",
                table: "Cards",
                column: "RecipientID",
                principalTable: "Recipients",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Users_UserID",
                table: "Cards",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Tasks_TaskID",
                table: "Recipients",
                column: "TaskID",
                principalTable: "Tasks",
                principalColumn: "ID");
        }
    }
}
