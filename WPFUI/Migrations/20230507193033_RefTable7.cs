using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RefTable7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Senders_Recipients_RecipientsID",
                table: "Senders");

            migrationBuilder.DropIndex(
                name: "IX_Senders_RecipientsID",
                table: "Senders");

            migrationBuilder.DropColumn(
                name: "RecipientsID",
                table: "Senders");

            migrationBuilder.CreateIndex(
                name: "IX_Senders_RecipientID",
                table: "Senders",
                column: "RecipientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Senders_Recipients_RecipientID",
                table: "Senders",
                column: "RecipientID",
                principalTable: "Recipients",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Senders_Recipients_RecipientID",
                table: "Senders");

            migrationBuilder.DropIndex(
                name: "IX_Senders_RecipientID",
                table: "Senders");

            migrationBuilder.AddColumn<int>(
                name: "RecipientsID",
                table: "Senders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Senders_RecipientsID",
                table: "Senders",
                column: "RecipientsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Senders_Recipients_RecipientsID",
                table: "Senders",
                column: "RecipientsID",
                principalTable: "Recipients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
