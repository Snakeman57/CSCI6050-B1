using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Migrations
{
    public partial class mtest_017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketType_TypeName",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketType",
                table: "TicketType");

            migrationBuilder.RenameTable(
                name: "TicketType",
                newName: "TicketTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketTypes",
                table: "TicketTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowTimeId",
                table: "Tickets",
                column: "ShowTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ShowTimes_ShowTimeId",
                table: "Tickets",
                column: "ShowTimeId",
                principalTable: "ShowTimes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketTypes_TypeName",
                table: "Tickets",
                column: "TypeName",
                principalTable: "TicketTypes",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ShowTimes_ShowTimeId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketTypes_TypeName",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ShowTimeId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketTypes",
                table: "TicketTypes");

            migrationBuilder.RenameTable(
                name: "TicketTypes",
                newName: "TicketType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketType",
                table: "TicketType",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketType_TypeName",
                table: "Tickets",
                column: "TypeName",
                principalTable: "TicketType",
                principalColumn: "Name");
        }
    }
}
