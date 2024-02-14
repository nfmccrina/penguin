using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Penguin.Services.Migrations
{
    /// <inheritdoc />
    public partial class AddCoverArtTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "CoverArt",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "CoverArt");
        }
    }
}
