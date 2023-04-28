using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RefTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExecutionDate",
                table: "DocumentTypes");

            migrationBuilder.AddColumn<string>(
                name: "ExecutionPeriod",
                table: "DocumentTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExecutionPeriod",
                table: "DocumentTypes");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExecutionDate",
                table: "DocumentTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
