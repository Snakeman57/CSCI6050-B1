using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Data.Migrations
{
    public partial class RegisterComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowTimeId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Theater",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    TheaterCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Row = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theater", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShowTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: true),
                    TheaterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowTime_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShowTime_Theater_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theater",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShowTimeId",
                table: "AspNetUsers",
                column: "ShowTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_MovieId",
                table: "ShowTime",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_TheaterId",
                table: "ShowTime",
                column: "TheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShowTime_ShowTimeId",
                table: "AspNetUsers",
                column: "ShowTimeId",
                principalTable: "ShowTime",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShowTime_ShowTimeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ShowTime");

            migrationBuilder.DropTable(
                name: "Theater");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShowTimeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShowTimeId",
                table: "AspNetUsers");
        }
    }
}
