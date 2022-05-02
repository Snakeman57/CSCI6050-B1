using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Data.Migrations
{
    public partial class UpdateCart3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Movies_MoviesID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_MoviesID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "MoviesID",
                table: "Tickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoviesID",
                table: "Tickets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MoviesID",
                table: "Tickets",
                column: "MoviesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Movies_MoviesID",
                table: "Tickets",
                column: "MoviesID",
                principalTable: "Movies",
                principalColumn: "ID");
        }
    }
}
