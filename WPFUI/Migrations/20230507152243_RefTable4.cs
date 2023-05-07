using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RefTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Senders_Users_UserID",
                table: "Senders");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Senders",
                newName: "UserDTOID");

            migrationBuilder.RenameIndex(
                name: "IX_Senders_UserID",
                table: "Senders",
                newName: "IX_Senders_UserDTOID");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserID",
                table: "Cards",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Users_UserID",
                table: "Cards",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Senders_Users_UserDTOID",
                table: "Senders",
                column: "UserDTOID",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Users_UserID",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Senders_Users_UserDTOID",
                table: "Senders");

            migrationBuilder.DropIndex(
                name: "IX_Cards_UserID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "UserDTOID",
                table: "Senders",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Senders_UserDTOID",
                table: "Senders",
                newName: "IX_Senders_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Senders_Users_UserID",
                table: "Senders",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }
    }
}
