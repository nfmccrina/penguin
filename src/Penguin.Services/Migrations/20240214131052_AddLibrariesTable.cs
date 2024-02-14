using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Penguin.Services.Migrations
{
    /// <inheritdoc />
    public partial class AddLibrariesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "Songs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Songs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Path = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_LibraryId",
                table: "Songs",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Libraries_LibraryId",
                table: "Songs",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Libraries_LibraryId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropIndex(
                name: "IX_Songs_LibraryId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Songs");
        }
    }
}
