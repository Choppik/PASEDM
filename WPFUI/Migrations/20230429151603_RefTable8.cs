using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RefTable8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_DocumentTypes_TypeDocumentID",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_TypeDocumentID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "TypeDocumentID",
                table: "Cards");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_DocumentTypes_DocumentTypesID",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_DocumentTypesID",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "TypeDocumentID",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TypeDocumentID",
                table: "Cards",
                column: "TypeDocumentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_DocumentTypes_TypeDocumentID",
                table: "Cards",
                column: "TypeDocumentID",
                principalTable: "DocumentTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
