using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RefTable6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Senders_Recipients_RecipientsID",
                table: "Senders");

            migrationBuilder.AlterColumn<int>(
                name: "RecipientsID",
                table: "Senders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipientID",
                table: "Senders",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Senders_Recipients_RecipientsID",
                table: "Senders",
                column: "RecipientsID",
                principalTable: "Recipients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Senders_Recipients_RecipientsID",
                table: "Senders");

            migrationBuilder.DropColumn(
                name: "RecipientID",
                table: "Senders");

            migrationBuilder.AlterColumn<int>(
                name: "RecipientsID",
                table: "Senders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Senders_Recipients_RecipientsID",
                table: "Senders",
                column: "RecipientsID",
                principalTable: "Recipients",
                principalColumn: "ID");
        }
    }
}
