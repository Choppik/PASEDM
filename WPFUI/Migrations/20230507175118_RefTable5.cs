using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RefTable5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Senders_Cards_CardID",
                table: "Senders");

            migrationBuilder.DropForeignKey(
                name: "FK_Senders_Users_UserDTOID",
                table: "Senders");

            migrationBuilder.DropIndex(
                name: "IX_Senders_CardID",
                table: "Senders");

            migrationBuilder.DropColumn(
                name: "CardID",
                table: "Senders");

            migrationBuilder.RenameColumn(
                name: "UserDTOID",
                table: "Senders",
                newName: "RecipientsID");

            migrationBuilder.RenameIndex(
                name: "IX_Senders_UserDTOID",
                table: "Senders",
                newName: "IX_Senders_RecipientsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Senders_Recipients_RecipientsID",
                table: "Senders",
                column: "RecipientsID",
                principalTable: "Recipients",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Senders_Recipients_RecipientsID",
                table: "Senders");

            migrationBuilder.RenameColumn(
                name: "RecipientsID",
                table: "Senders",
                newName: "UserDTOID");

            migrationBuilder.RenameIndex(
                name: "IX_Senders_RecipientsID",
                table: "Senders",
                newName: "IX_Senders_UserDTOID");

            migrationBuilder.AddColumn<int>(
                name: "CardID",
                table: "Senders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Senders_CardID",
                table: "Senders",
                column: "CardID");

            migrationBuilder.AddForeignKey(
                name: "FK_Senders_Cards_CardID",
                table: "Senders",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Senders_Users_UserDTOID",
                table: "Senders",
                column: "UserDTOID",
                principalTable: "Users",
                principalColumn: "ID");
        }
    }
}
