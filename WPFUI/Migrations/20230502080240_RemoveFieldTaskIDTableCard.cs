using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFieldTaskIDTableCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Tasks_TaskID",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_TaskID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "TaskID",
                table: "Cards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskID",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TaskID",
                table: "Cards",
                column: "TaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Tasks_TaskID",
                table: "Cards",
                column: "TaskID",
                principalTable: "Tasks",
                principalColumn: "ID");
        }
    }
}
