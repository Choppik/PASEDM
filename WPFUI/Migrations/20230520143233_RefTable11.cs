using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RefTable11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoveUsers_Cards_CardID",
                table: "MoveUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MoveUsers_TypeUsers_TypeUserID",
                table: "MoveUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoveUsers",
                table: "MoveUsers");

            migrationBuilder.RenameTable(
                name: "MoveUsers",
                newName: "MoveCards");

            migrationBuilder.RenameIndex(
                name: "IX_MoveUsers_TypeUserID",
                table: "MoveCards",
                newName: "IX_MoveCards_TypeUserID");

            migrationBuilder.RenameIndex(
                name: "IX_MoveUsers_CardID",
                table: "MoveCards",
                newName: "IX_MoveCards_CardID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoveCards",
                table: "MoveCards",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MoveCards_Cards_CardID",
                table: "MoveCards",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MoveCards_TypeUsers_TypeUserID",
                table: "MoveCards",
                column: "TypeUserID",
                principalTable: "TypeUsers",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoveCards_Cards_CardID",
                table: "MoveCards");

            migrationBuilder.DropForeignKey(
                name: "FK_MoveCards_TypeUsers_TypeUserID",
                table: "MoveCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoveCards",
                table: "MoveCards");

            migrationBuilder.RenameTable(
                name: "MoveCards",
                newName: "MoveUsers");

            migrationBuilder.RenameIndex(
                name: "IX_MoveCards_TypeUserID",
                table: "MoveUsers",
                newName: "IX_MoveUsers_TypeUserID");

            migrationBuilder.RenameIndex(
                name: "IX_MoveCards_CardID",
                table: "MoveUsers",
                newName: "IX_MoveUsers_CardID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoveUsers",
                table: "MoveUsers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MoveUsers_Cards_CardID",
                table: "MoveUsers",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MoveUsers_TypeUsers_TypeUserID",
                table: "MoveUsers",
                column: "TypeUserID",
                principalTable: "TypeUsers",
                principalColumn: "ID");
        }
    }
}
