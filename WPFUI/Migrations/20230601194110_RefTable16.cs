using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RefTable16 : Migration
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
                name: "FK_MoveCards_TypeUsers_TypeUserID",
                table: "MoveCards");

            migrationBuilder.DropTable(
                name: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Cards_RecipientID",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_UserID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DateCreateDoc",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "RecipientID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "TypeUserValue",
                table: "TypeUsers",
                newName: "TypeCardValue");

            migrationBuilder.RenameColumn(
                name: "TypeUser",
                table: "TypeUsers",
                newName: "TypeCard");

            migrationBuilder.RenameColumn(
                name: "TypeUserID",
                table: "MoveCards",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_MoveCards_TypeUserID",
                table: "MoveCards",
                newName: "IX_MoveCards_UserID");

            migrationBuilder.AddColumn<int>(
                name: "TypeCardID",
                table: "MoveCards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoveCards_TypeCardID",
                table: "MoveCards",
                column: "TypeCardID");

            migrationBuilder.AddForeignKey(
                name: "FK_MoveCards_TypeUsers_TypeCardID",
                table: "MoveCards",
                column: "TypeCardID",
                principalTable: "TypeUsers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MoveCards_Users_UserID",
                table: "MoveCards",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoveCards_TypeUsers_TypeCardID",
                table: "MoveCards");

            migrationBuilder.DropForeignKey(
                name: "FK_MoveCards_Users_UserID",
                table: "MoveCards");

            migrationBuilder.DropIndex(
                name: "IX_MoveCards_TypeCardID",
                table: "MoveCards");

            migrationBuilder.DropColumn(
                name: "TypeCardID",
                table: "MoveCards");

            migrationBuilder.RenameColumn(
                name: "TypeCardValue",
                table: "TypeUsers",
                newName: "TypeUserValue");

            migrationBuilder.RenameColumn(
                name: "TypeCard",
                table: "TypeUsers",
                newName: "TypeUser");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "MoveCards",
                newName: "TypeUserID");

            migrationBuilder.RenameIndex(
                name: "IX_MoveCards_UserID",
                table: "MoveCards",
                newName: "IX_MoveCards_TypeUserID");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreateDoc",
                table: "Documents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RecipientID",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recipients_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_RecipientID",
                table: "Cards",
                column: "RecipientID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserID",
                table: "Cards",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_UserID",
                table: "Recipients",
                column: "UserID");

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
                name: "FK_MoveCards_TypeUsers_TypeUserID",
                table: "MoveCards",
                column: "TypeUserID",
                principalTable: "TypeUsers",
                principalColumn: "ID");
        }
    }
}
