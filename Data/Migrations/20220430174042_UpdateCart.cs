using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Data.Migrations
{
    public partial class UpdateCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShowTime_ShowTimeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_ShowTime_ShowTimesId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Theater_TheatersId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShowTimeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShowTimeId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TheatersId",
                table: "Ticket",
                newName: "TheatersID");

            migrationBuilder.RenameColumn(
                name: "ShowTimesId",
                table: "Ticket",
                newName: "ShowTimesID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_TheatersId",
                table: "Ticket",
                newName: "IX_Ticket_TheatersID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_ShowTimesId",
                table: "Ticket",
                newName: "IX_Ticket_ShowTimesID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Theater",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShowTime",
                newName: "ID");

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

            migrationBuilder.AddColumn<int>(
                name: "SeatNumber",
                table: "Ticket",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Ticket",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ItemID = table.Column<string>(type: "TEXT", nullable: false),
                    CartID = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TicketID = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "IX_Ticket_UserId",
                table: "Ticket",
                column: "UserId");

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
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_ShowTime_ShowTimesID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Theater_TheatersID",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "TheatersID",
                table: "Ticket",
                newName: "TheatersId");

            migrationBuilder.RenameColumn(
                name: "ShowTimesID",
                table: "Ticket",
                newName: "ShowTimesId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_TheatersID",
                table: "Ticket",
                newName: "IX_Ticket_TheatersId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_ShowTimesID",
                table: "Ticket",
                newName: "IX_Ticket_ShowTimesId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Theater",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ShowTime",
                newName: "Id");

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

            migrationBuilder.AddColumn<int>(
                name: "ShowTimeId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShowTimeId",
                table: "AspNetUsers",
                column: "ShowTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShowTime_ShowTimeId",
                table: "AspNetUsers",
                column: "ShowTimeId",
                principalTable: "ShowTime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MoviePromotion_MoviePromotionId",
                table: "Movies",
                column: "MoviePromotionId",
                principalTable: "MoviePromotion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_ShowTime_ShowTimesId",
                table: "Ticket",
                column: "ShowTimesId",
                principalTable: "ShowTime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Theater_TheatersId",
                table: "Ticket",
                column: "TheatersId",
                principalTable: "Theater",
                principalColumn: "Id");
        }
    }
}
