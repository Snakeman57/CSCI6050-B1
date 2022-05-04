using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Data.Migrations
{
    public partial class UpdateCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FavTheater",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MoviePromotion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Promotion = table.Column<string>(type: "TEXT", nullable: true),
                    PromoCode = table.Column<string>(type: "TEXT", nullable: true),
                    PromoDeal = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePromotion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Roles = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theater",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    TheaterCapacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theater", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Casts = table.Column<string>(type: "TEXT", nullable: false),
                    Director = table.Column<string>(type: "TEXT", nullable: false),
                    Producer = table.Column<string>(type: "TEXT", nullable: false),
                    Synopsis = table.Column<string>(type: "TEXT", nullable: false),
                    Review = table.Column<string>(type: "TEXT", nullable: true),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    RunningTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    MoviePromotionId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_MoviePromotion_MoviePromotionId",
                        column: x => x.MoviePromotionId,
                        principalTable: "MoviePromotion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShowTime",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeStart = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TimeEnd = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: true),
                    TheaterID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTime", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShowTime_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShowTime_Theater_TheaterID",
                        column: x => x.TheaterID,
                        principalTable: "Theater",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    showTimeID = table.Column<int>(type: "INTEGER", nullable: true),
                    seatNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Row = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ticket_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_ShowTime_showTimeID",
                        column: x => x.showTimeID,
                        principalTable: "ShowTime",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MoviePromotionId",
                table: "Movies",
                column: "MoviePromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_MovieId",
                table: "ShowTime",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_TheaterID",
                table: "ShowTime",
                column: "TheaterID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_showTimeID",
                table: "Ticket",
                column: "showTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Roles_RoleId",
                table: "AspNetUsers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Roles_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "ShowTime");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Theater");

            migrationBuilder.DropTable(
                name: "MoviePromotion");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavTheater",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");
        }
    }
}
