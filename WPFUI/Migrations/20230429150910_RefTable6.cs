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
            migrationBuilder.DropColumn(
                name: "ExecutionPeriod",
                table: "DocumentTypes");

            migrationBuilder.AddColumn<int>(
                name: "TermID",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Deadlines",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTerm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Term = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deadlines", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TermID",
                table: "Documents",
                column: "TermID");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Deadlines_TermID",
                table: "Documents",
                column: "TermID",
                principalTable: "Deadlines",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Deadlines_TermID",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "Deadlines");

            migrationBuilder.DropIndex(
                name: "IX_Documents_TermID",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "TermID",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "ExecutionPeriod",
                table: "DocumentTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
