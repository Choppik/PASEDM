using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RefTable13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_DocumentTypes_DocumentTypesID",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_DocumentTypesID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DocumentTypesID",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypesID",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypesID",
                table: "Documents",
                column: "DocumentTypesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypesID",
                table: "Documents",
                column: "DocumentTypesID",
                principalTable: "DocumentTypes",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypesID",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentTypesID",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentTypesID",
                table: "Documents");

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypesID",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DocumentTypesID",
                table: "Cards",
                column: "DocumentTypesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_DocumentTypes_DocumentTypesID",
                table: "Cards",
                column: "DocumentTypesID",
                principalTable: "DocumentTypes",
                principalColumn: "ID");
        }
    }
}
