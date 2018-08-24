using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Author = table.Column<string>(maxLength: 50, nullable: false),
                    Publisher = table.Column<string>(maxLength: 50, nullable: false),
                    NumberOfBooks = table.Column<int>(nullable: false),
                    WikipediaLink = table.Column<string>(nullable: false),
                    ImageLink = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(maxLength: 50, nullable: false),
                    NumberInSeries = table.Column<int>(nullable: false),
                    Read = table.Column<bool>(nullable: false),
                    CurrentlyReading = table.Column<bool>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    WikipediaLink = table.Column<string>(nullable: false),
                    ImageLink = table.Column<string>(nullable: false),
                    SerieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_SerieId",
                table: "Books",
                column: "SerieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Serie");
        }
    }
}
