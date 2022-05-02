using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Data.Migrations
{
    public partial class UpdateCart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTime_Movies_MovieID",
                table: "ShowTime");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTime_Theater_theaterID",
                table: "ShowTime");

            migrationBuilder.DropForeignKey(
                name: "FK_Theater_Movies_shownMovieID",
                table: "Theater");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Movies_MoviesID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_ShowTime_ShowTimesID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Theater_TheatersID",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Theater",
                table: "Theater");

            migrationBuilder.DropIndex(
                name: "IX_Theater_shownMovieID",
                table: "Theater");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowTime",
                table: "ShowTime");

            migrationBuilder.DropIndex(
                name: "IX_ShowTime_MovieID",
                table: "ShowTime");

            migrationBuilder.DropIndex(
                name: "IX_ShowTime_theaterID",
                table: "ShowTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviePromotion",
                table: "MoviePromotion");

            migrationBuilder.DropColumn(
                name: "shownMovieID",
                table: "Theater");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "ShowTime");

            migrationBuilder.DropColumn(
                name: "price",
                table: "ShowTime");

            migrationBuilder.DropColumn(
                name: "theaterID",
                table: "ShowTime");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "Theater",
                newName: "Theaters");

            migrationBuilder.RenameTable(
                name: "ShowTime",
                newName: "ShowTimes");

            migrationBuilder.RenameTable(
                name: "MoviePromotion",
                newName: "Promotions");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_UserId",
                table: "Tickets",
                newName: "IX_Tickets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_TheatersID",
                table: "Tickets",
                newName: "IX_Tickets_TheatersID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_ShowTimesID",
                table: "Tickets",
                newName: "IX_Tickets_ShowTimesID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_MoviesID",
                table: "Tickets",
                newName: "IX_Tickets_MoviesID");

            migrationBuilder.AddColumn<int>(
                name: "TheaterID",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Tickets",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "MoviesID",
                table: "ShowTimes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TheatersID",
                table: "ShowTimes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Theaters",
                table: "Theaters",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowTimes",
                table: "ShowTimes",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ShowTimesID = table.Column<int>(type: "INTEGER", nullable: true),
                    movieTicketID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_ShowTimes_ShowTimesID",
                        column: x => x.ShowTimesID,
                        principalTable: "ShowTimes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Items_Tickets_movieTicketID",
                        column: x => x.movieTicketID,
                        principalTable: "Tickets",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_TheaterID",
                table: "Movies",
                column: "TheaterID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_MoviesID",
                table: "ShowTimes",
                column: "MoviesID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_TheatersID",
                table: "ShowTimes",
                column: "TheatersID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_movieTicketID",
                table: "Items",
                column: "movieTicketID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShowTimesID",
                table: "Items",
                column: "ShowTimesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Promotions_MoviePromotionID",
                table: "Movies",
                column: "MoviePromotionID",
                principalTable: "Promotions",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Theaters_TheaterID",
                table: "Movies",
                column: "TheaterID",
                principalTable: "Theaters",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTimes_Movies_MoviesID",
                table: "ShowTimes",
                column: "MoviesID",
                principalTable: "Movies",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTimes_Theaters_TheatersID",
                table: "ShowTimes",
                column: "TheatersID",
                principalTable: "Theaters",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Movies_MoviesID",
                table: "Tickets",
                column: "MoviesID",
                principalTable: "Movies",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ShowTimes_ShowTimesID",
                table: "Tickets",
                column: "ShowTimesID",
                principalTable: "ShowTimes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Theaters_TheatersID",
                table: "Tickets",
                column: "TheatersID",
                principalTable: "Theaters",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Promotions_MoviePromotionID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Theaters_TheaterID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTimes_Movies_MoviesID",
                table: "ShowTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTimes_Theaters_TheatersID",
                table: "ShowTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_UserId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Movies_MoviesID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ShowTimes_ShowTimesID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Theaters_TheatersID",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Movies_TheaterID",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Theaters",
                table: "Theaters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowTimes",
                table: "ShowTimes");

            migrationBuilder.DropIndex(
                name: "IX_ShowTimes_MoviesID",
                table: "ShowTimes");

            migrationBuilder.DropIndex(
                name: "IX_ShowTimes_TheatersID",
                table: "ShowTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "TheaterID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MoviesID",
                table: "ShowTimes");

            migrationBuilder.DropColumn(
                name: "TheatersID",
                table: "ShowTimes");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "Theaters",
                newName: "Theater");

            migrationBuilder.RenameTable(
                name: "ShowTimes",
                newName: "ShowTime");

            migrationBuilder.RenameTable(
                name: "Promotions",
                newName: "MoviePromotion");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserId",
                table: "Ticket",
                newName: "IX_Ticket_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TheatersID",
                table: "Ticket",
                newName: "IX_Ticket_TheatersID");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ShowTimesID",
                table: "Ticket",
                newName: "IX_Ticket_ShowTimesID");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_MoviesID",
                table: "Ticket",
                newName: "IX_Ticket_MoviesID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Ticket",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "shownMovieID",
                table: "Theater",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "ShowTime",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "ShowTime",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "theaterID",
                table: "ShowTime",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Theater",
                table: "Theater",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowTime",
                table: "ShowTime",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviePromotion",
                table: "MoviePromotion",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ItemID = table.Column<string>(type: "TEXT", nullable: false),
                    TicketID = table.Column<int>(type: "INTEGER", nullable: false),
                    CartID = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_CartItems_Ticket_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Ticket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Theater_shownMovieID",
                table: "Theater",
                column: "shownMovieID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_MovieID",
                table: "ShowTime",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_theaterID",
                table: "ShowTime",
                column: "theaterID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_TicketID",
                table: "CartItems",
                column: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionID",
                table: "Movies",
                column: "MoviePromotionID",
                principalTable: "MoviePromotion",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTime_Movies_MovieID",
                table: "ShowTime",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTime_Theater_theaterID",
                table: "ShowTime",
                column: "theaterID",
                principalTable: "Theater",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Theater_Movies_shownMovieID",
                table: "Theater",
                column: "shownMovieID",
                principalTable: "Movies",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Movies_MoviesID",
                table: "Ticket",
                column: "MoviesID",
                principalTable: "Movies",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_ShowTime_ShowTimesID",
                table: "Ticket",
                column: "ShowTimesID",
                principalTable: "ShowTime",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Theater_TheatersID",
                table: "Ticket",
                column: "TheatersID",
                principalTable: "Theater",
                principalColumn: "ID");
        }
    }
}
