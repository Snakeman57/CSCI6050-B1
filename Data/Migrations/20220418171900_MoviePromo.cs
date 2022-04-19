using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Data.Migrations
{
    public partial class MoviePromo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MoviePromotionId",
                table: "Movies",
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

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MoviePromotionId",
                table: "Movies",
                column: "MoviePromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionId",
                table: "Movies",
                column: "MoviePromotionId",
                principalTable: "MoviePromotion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "MoviePromotion");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MoviePromotionId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MoviePromotionId",
                table: "Movies");
        }
    }
}
