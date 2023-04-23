using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RefTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Documents_DocumentID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DocumentsID",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "View",
                table: "Documents",
                newName: "TypeDocument");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentID",
                table: "Cards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Documents_DocumentID",
                table: "Cards",
                column: "DocumentID",
                principalTable: "Documents",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Documents_DocumentID",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "TypeDocument",
                table: "Documents",
                newName: "View");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentID",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentsID",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Documents_DocumentID",
                table: "Cards",
                column: "DocumentID",
                principalTable: "Documents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
