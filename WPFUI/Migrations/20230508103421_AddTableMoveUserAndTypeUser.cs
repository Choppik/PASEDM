using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PASEDM.Migrations
{
    /// <inheritdoc />
    public partial class AddTableMoveUserAndTypeUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Cards_CardID",
                table: "Recipients");

            migrationBuilder.DropTable(
                name: "Senders");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_CardID",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "CardID",
                table: "Recipients");

            migrationBuilder.AddColumn<int>(
                name: "RecipientID",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeUsers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeUserValue = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MoveUsers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeUserID = table.Column<int>(type: "int", nullable: true),
                    CardID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MoveUsers_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MoveUsers_TypeUsers_TypeUserID",
                        column: x => x.TypeUserID,
                        principalTable: "TypeUsers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_RecipientID",
                table: "Cards",
                column: "RecipientID");

            migrationBuilder.CreateIndex(
                name: "IX_MoveUsers_CardID",
                table: "MoveUsers",
                column: "CardID");

            migrationBuilder.CreateIndex(
                name: "IX_MoveUsers_TypeUserID",
                table: "MoveUsers",
                column: "TypeUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Recipients_RecipientID",
                table: "Cards",
                column: "RecipientID",
                principalTable: "Recipients",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Recipients_RecipientID",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "MoveUsers");

            migrationBuilder.DropTable(
                name: "TypeUsers");

            migrationBuilder.DropIndex(
                name: "IX_Cards_RecipientID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "RecipientID",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "CardID",
                table: "Recipients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Senders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Senders_Recipients_RecipientID",
                        column: x => x.RecipientID,
                        principalTable: "Recipients",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_CardID",
                table: "Recipients",
                column: "CardID");

            migrationBuilder.CreateIndex(
                name: "IX_Senders_RecipientID",
                table: "Senders",
                column: "RecipientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Cards_CardID",
                table: "Recipients",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "ID");
        }
    }
}
