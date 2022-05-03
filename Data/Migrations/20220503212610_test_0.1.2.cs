using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Data.Migrations
{
    public partial class test_012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "ShowTimes");

            migrationBuilder.DropColumn(
                name: "TheaterId",
                table: "ShowTimes");

            migrationBuilder.DropColumn(
                name: "ShowTimeId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Tickets",
                newName: "TypeName");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_UserIdId");

            migrationBuilder.AddColumn<uint>(
                name: "MovieIdID",
                table: "ShowTimes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<uint>(
                name: "TheaterIdID",
                table: "ShowTimes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<uint>(
                name: "ShowTimeIdID",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TicketType",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketType", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TypeName",
                table: "Tickets",
                column: "TypeName");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_MovieIdID",
                table: "ShowTimes",
                column: "MovieIdID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_TheaterIdID",
                table: "ShowTimes",
                column: "TheaterIdID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShowTimeIdID",
                table: "Orders",
                column: "ShowTimeIdID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserIdId",
                table: "Orders",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShowTimes_ShowTimeIdID",
                table: "Orders",
                column: "ShowTimeIdID",
                principalTable: "ShowTimes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTimes_Movies_MovieIdID",
                table: "ShowTimes",
                column: "MovieIdID",
                principalTable: "Movies",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTimes_Theaters_TheaterIdID",
                table: "ShowTimes",
                column: "TheaterIdID",
                principalTable: "Theaters",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketType_TypeName",
                table: "Tickets",
                column: "TypeName",
                principalTable: "TicketType",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserIdId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShowTimes_ShowTimeIdID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTimes_Movies_MovieIdID",
                table: "ShowTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTimes_Theaters_TheaterIdID",
                table: "ShowTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketType_TypeName",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketType");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TypeName",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_ShowTimes_MovieIdID",
                table: "ShowTimes");

            migrationBuilder.DropIndex(
                name: "IX_ShowTimes_TheaterIdID",
                table: "ShowTimes");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShowTimeIdID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MovieIdID",
                table: "ShowTimes");

            migrationBuilder.DropColumn(
                name: "TheaterIdID",
                table: "ShowTimes");

            migrationBuilder.DropColumn(
                name: "ShowTimeIdID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "Tickets",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserIdId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AddColumn<uint>(
                name: "MovieId",
                table: "ShowTimes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "TheaterId",
                table: "ShowTimes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "ShowTimeId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
