using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Data.Migrations
{
    public partial class UpdateCart4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTime_Theater_TheaterID",
                table: "ShowTime");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Ticket",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Theater",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TheaterID",
                table: "ShowTime",
                newName: "TheaterId");

            migrationBuilder.RenameIndex(
                name: "IX_ShowTime_TheaterID",
                table: "ShowTime",
                newName: "IX_ShowTime_TheaterId");

            migrationBuilder.RenameColumn(
                name: "MoviePromotionID",
                table: "Movies",
                newName: "MoviePromotionId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_MoviePromotionID",
                table: "Movies",
                newName: "IX_Movies_MoviePromotionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "MoviePromotion",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionId",
                table: "Movies",
                column: "MoviePromotionId",
                principalTable: "MoviePromotion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTime_Theater_TheaterId",
                table: "ShowTime",
                column: "TheaterId",
                principalTable: "Theater",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTime_Theater_TheaterId",
                table: "ShowTime");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ticket",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Theater",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "TheaterId",
                table: "ShowTime",
                newName: "TheaterID");

            migrationBuilder.RenameIndex(
                name: "IX_ShowTime_TheaterId",
                table: "ShowTime",
                newName: "IX_ShowTime_TheaterID");

            migrationBuilder.RenameColumn(
                name: "MoviePromotionId",
                table: "Movies",
                newName: "MoviePromotionID");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_MoviePromotionId",
                table: "Movies",
                newName: "IX_Movies_MoviePromotionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MoviePromotion",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionID",
                table: "Movies",
                column: "MoviePromotionID",
                principalTable: "MoviePromotion",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTime_Theater_TheaterID",
                table: "ShowTime",
                column: "TheaterID",
                principalTable: "Theater",
                principalColumn: "ID");
        }
    }
}
