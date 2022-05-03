using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Data.Migrations
{
    public partial class test_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Review",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "RunningTime",
                table: "Movies",
                newName: "TrailerLink");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Movies",
                newName: "RatingMPAA");

            migrationBuilder.RenameColumn(
                name: "Producer",
                table: "Movies",
                newName: "Runtime");

            migrationBuilder.RenameColumn(
                name: "Casts",
                table: "Movies",
                newName: "PosterLink");

            migrationBuilder.AlterColumn<string>(
                name: "Synopsis",
                table: "Movies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrailerLink",
                table: "Movies",
                newName: "RunningTime");

            migrationBuilder.RenameColumn(
                name: "Runtime",
                table: "Movies",
                newName: "Producer");

            migrationBuilder.RenameColumn(
                name: "RatingMPAA",
                table: "Movies",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "PosterLink",
                table: "Movies",
                newName: "Casts");

            migrationBuilder.AlterColumn<string>(
                name: "Synopsis",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "Movies",
                type: "TEXT",
                nullable: true);
        }
    }
}
