using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Data.Migrations
{
    public partial class UpdateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Theater",
                type: "INTEGER",
                nullable: true);

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
                name: "IX_Theater_BookingId",
                table: "Theater",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_BookingId",
                table: "ShowTime",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_BookingId",
                table: "Movies",
                column: "BookingId");

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
                name: "FK_Theater_Booking_BookingId",
                table: "Theater",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Booking_BookingId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTime_Booking_BookingId",
                table: "ShowTime");

            migrationBuilder.DropForeignKey(
                name: "FK_Theater_Booking_BookingId",
                table: "Theater");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Theater_BookingId",
                table: "Theater");

            migrationBuilder.DropIndex(
                name: "IX_ShowTime_BookingId",
                table: "ShowTime");

            migrationBuilder.DropIndex(
                name: "IX_Movies_BookingId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Theater");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "ShowTime");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Movies");
        }
    }
}
