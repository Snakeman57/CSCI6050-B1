using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Data.Migrations
{
    public partial class UpdateCart3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionId",
                table: "Movies");

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

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Theater",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "TheaterID",
                table: "ShowTime",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MoviePromotionID",
                table: "Movies",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "MoviePromotion",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionID",
                table: "Movies",
                column: "MoviePromotionID",
                principalTable: "MoviePromotion",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionID",
                table: "Movies");

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

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Theater",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "TheaterID",
                table: "ShowTime",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MoviePromotionId",
                table: "Movies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "MoviePromotion",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionId",
                table: "Movies",
                column: "MoviePromotionId",
                principalTable: "MoviePromotion",
                principalColumn: "Id");
        }
    }
}
