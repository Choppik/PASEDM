using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RefTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStages_TaskStagesDTOID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tasks_TasksID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskStagesDTOID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskStagesDTOID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ConditionDoc",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "TasksID",
                table: "Tasks",
                newName: "TaskStagesID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TasksID",
                table: "Tasks",
                newName: "IX_Tasks_TaskStagesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStages_TaskStagesID",
                table: "Tasks",
                column: "TaskStagesID",
                principalTable: "TaskStages",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStages_TaskStagesID",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TaskStagesID",
                table: "Tasks",
                newName: "TasksID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TaskStagesID",
                table: "Tasks",
                newName: "IX_Tasks_TasksID");

            migrationBuilder.AddColumn<int>(
                name: "TaskStagesDTOID",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionDoc",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskStagesDTOID",
                table: "Tasks",
                column: "TaskStagesDTOID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStages_TaskStagesDTOID",
                table: "Tasks",
                column: "TaskStagesDTOID",
                principalTable: "TaskStages",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tasks_TasksID",
                table: "Tasks",
                column: "TasksID",
                principalTable: "Tasks",
                principalColumn: "ID");
        }
    }
}
