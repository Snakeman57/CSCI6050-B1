using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Data.Migrations
{
    public partial class ReUpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Booking_BookingId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Booking_BookingId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTime_Booking_BookingId",
                table: "ShowTime");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTime_Movies_MovieId",
                table: "ShowTime");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTime_Theater_TheaterId",
                table: "ShowTime");

            migrationBuilder.DropForeignKey(
                name: "FK_Theater_Booking_BookingId",
                table: "Theater");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_ShowTime_BookingId",
                table: "ShowTime");

            migrationBuilder.DropIndex(
                name: "IX_ShowTime_TheaterId",
                table: "ShowTime");

            migrationBuilder.DropIndex(
                name: "IX_Movies_BookingId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BookingId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "ShowTime");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Theater",
                newName: "shownMovieID");

            migrationBuilder.RenameIndex(
                name: "IX_Theater_BookingId",
                table: "Theater",
                newName: "IX_Theater_shownMovieID");

            migrationBuilder.RenameColumn(
                name: "TheaterId",
                table: "ShowTime",
                newName: "theaterID");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "ShowTime",
                newName: "MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_ShowTime_MovieId",
                table: "ShowTime",
                newName: "IX_ShowTime_MovieID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movies",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Promotion",
                table: "MoviePromotion",
                newName: "PromoDescript");

            migrationBuilder.AlterColumn<int>(
                name: "theaterID",
                table: "ShowTime",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "ShowTime",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "ShowTime",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MoviesID = table.Column<int>(type: "INTEGER", nullable: true),
                    ShowTimesId = table.Column<int>(type: "INTEGER", nullable: true),
                    TheatersId = table.Column<int>(type: "INTEGER", nullable: true),
                    price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ticket_Movies_MoviesID",
                        column: x => x.MoviesID,
                        principalTable: "Movies",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Ticket_ShowTime_ShowTimesId",
                        column: x => x.ShowTimesId,
                        principalTable: "ShowTime",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_Theater_TheatersId",
                        column: x => x.TheatersId,
                        principalTable: "Theater",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_theaterID",
                table: "ShowTime",
                column: "theaterID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_MoviesID",
                table: "Ticket",
                column: "MoviesID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ShowTimesId",
                table: "Ticket",
                column: "ShowTimesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TheatersId",
                table: "Ticket",
                column: "TheatersId");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Theater_Movies_shownMovieID",
                table: "Theater",
                column: "shownMovieID",
                principalTable: "Movies",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowTime_Movies_MovieID",
                table: "ShowTime");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTime_Theater_theaterID",
                table: "ShowTime");

            migrationBuilder.DropForeignKey(
                name: "FK_Theater_Movies_shownMovieID",
                table: "Theater");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_ShowTime_theaterID",
                table: "ShowTime");

            migrationBuilder.DropColumn(
                name: "price",
                table: "ShowTime");

            migrationBuilder.RenameColumn(
                name: "shownMovieID",
                table: "Theater",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Theater_shownMovieID",
                table: "Theater",
                newName: "IX_Theater_BookingId");

            migrationBuilder.RenameColumn(
                name: "theaterID",
                table: "ShowTime",
                newName: "TheaterId");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "ShowTime",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ShowTime_MovieID",
                table: "ShowTime",
                newName: "IX_ShowTime_MovieId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Movies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PromoDescript",
                table: "MoviePromotion",
                newName: "Promotion");

            migrationBuilder.AlterColumn<int>(
                name: "TheaterId",
                table: "ShowTime",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "ShowTime",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "ShowTime",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_BookingId",
                table: "ShowTime",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_TheaterId",
                table: "ShowTime",
                column: "TheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_BookingId",
                table: "Movies",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BookingId",
                table: "AspNetUsers",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Booking_BookingId",
                table: "AspNetUsers",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Booking_BookingId",
                table: "Movies",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTime_Booking_BookingId",
                table: "ShowTime",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTime_Movies_MovieId",
                table: "ShowTime",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTime_Theater_TheaterId",
                table: "ShowTime",
                column: "TheaterId",
                principalTable: "Theater",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Theater_Booking_BookingId",
                table: "Theater",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");
        }
    }
}
