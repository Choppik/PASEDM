using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class Add4Tadle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConditionTask",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Admittance",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "SecrecyStamp",
                table: "Documents");

            migrationBuilder.AddColumn<int>(
                name: "TaskStagesDTOID",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TasksID",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessRightsID",
                table: "Staff",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionDoc",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "DocStagesID",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecrecyStampsID",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccessRights",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessRights = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccessRightsValue = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRights", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DocStages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocStages = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocStagesValue = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocStages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SecrecyStamps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecrecyStamp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecrecyStampValue = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecrecyStamps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TaskStages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskStages = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaskStagesValue = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStages", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TasksID",
                table: "Tasks",
                column: "TasksID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskStagesDTOID",
                table: "Tasks",
                column: "TaskStagesDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_AccessRightsID",
                table: "Staff",
                column: "AccessRightsID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocStagesID",
                table: "Documents",
                column: "DocStagesID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_SecrecyStampsID",
                table: "Documents",
                column: "SecrecyStampsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocStages_DocStagesID",
                table: "Documents",
                column: "DocStagesID",
                principalTable: "DocStages",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_SecrecyStamps_SecrecyStampsID",
                table: "Documents",
                column: "SecrecyStampsID",
                principalTable: "SecrecyStamps",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_AccessRights_AccessRightsID",
                table: "Staff",
                column: "AccessRightsID",
                principalTable: "AccessRights",
                principalColumn: "ID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocStages_DocStagesID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_SecrecyStamps_SecrecyStampsID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_AccessRights_AccessRightsID",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStages_TaskStagesDTOID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tasks_TasksID",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "AccessRights");

            migrationBuilder.DropTable(
                name: "DocStages");

            migrationBuilder.DropTable(
                name: "SecrecyStamps");

            migrationBuilder.DropTable(
                name: "TaskStages");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TasksID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskStagesDTOID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Staff_AccessRightsID",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocStagesID",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_SecrecyStampsID",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "TaskStagesDTOID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TasksID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AccessRightsID",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "DocStagesID",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "SecrecyStampsID",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "ConditionTask",
                table: "Tasks",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Admittance",
                table: "Staff",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ConditionDoc",
                table: "Documents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SecrecyStamp",
                table: "Documents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
