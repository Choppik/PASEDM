using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class RefTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfFormation",
                table: "Cards");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfReceipt",
                table: "Recipients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfReceipt",
                table: "Recipients");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfFormation",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
