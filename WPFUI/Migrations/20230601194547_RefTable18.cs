using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RefTable18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoveCards_TypeUsers_TypeCardID",
                table: "MoveCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeUsers",
                table: "TypeUsers");

            migrationBuilder.RenameTable(
                name: "TypeUsers",
                newName: "TypeCards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeCards",
                table: "TypeCards",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MoveCards_TypeCards_TypeCardID",
                table: "MoveCards",
                column: "TypeCardID",
                principalTable: "TypeCards",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoveCards_TypeCards_TypeCardID",
                table: "MoveCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeCards",
                table: "TypeCards");

            migrationBuilder.RenameTable(
                name: "TypeCards",
                newName: "TypeUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeUsers",
                table: "TypeUsers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MoveCards_TypeUsers_TypeCardID",
                table: "MoveCards",
                column: "TypeCardID",
                principalTable: "TypeUsers",
                principalColumn: "ID");
        }
    }
}
