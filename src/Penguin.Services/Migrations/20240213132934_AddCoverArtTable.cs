/*

Copyright (C) 2024 Nathan McCrina

This file is part of Penguin.
   
Penguin is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or (at
your option) any later version.

Penguin is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Penguin.  If not, see <https://www.gnu.org/licenses/>.

*/

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Penguin.Services.Migrations
{
    /// <inheritdoc />
    public partial class AddCoverArtTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Songs",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "CoverArtId",
                table: "Songs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoverArtId",
                table: "Artists",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CoverArt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverArt", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_CoverArtId",
                table: "Songs",
                column: "CoverArtId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_CoverArtId",
                table: "Artists",
                column: "CoverArtId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_CoverArtId",
                table: "Albums",
                column: "CoverArtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_CoverArt_CoverArtId",
                table: "Albums",
                column: "CoverArtId",
                principalTable: "CoverArt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_CoverArt_CoverArtId",
                table: "Artists",
                column: "CoverArtId",
                principalTable: "CoverArt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_CoverArt_CoverArtId",
                table: "Songs",
                column: "CoverArtId",
                principalTable: "CoverArt",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_CoverArt_CoverArtId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_CoverArt_CoverArtId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_CoverArt_CoverArtId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "CoverArt");

            migrationBuilder.DropIndex(
                name: "IX_Songs_CoverArtId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Artists_CoverArtId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Albums_CoverArtId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "CoverArtId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "CoverArtId",
                table: "Artists");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Songs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
