using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Migrations
{
    public partial class mtest_018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "PaymentCard1ID",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<uint>(
                name: "PaymentCard2ID",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<uint>(
                name: "PaymentCard3ID",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentCards",
                columns: table => new
                {
                    ID = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardNumber = table.Column<uint>(type: "INTEGER", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AddrStreet1 = table.Column<string>(type: "TEXT", nullable: true),
                    AddrStreet2 = table.Column<string>(type: "TEXT", nullable: true),
                    AddrCity = table.Column<string>(type: "TEXT", nullable: true),
                    AddrState = table.Column<string>(type: "TEXT", nullable: true),
                    AddrZip = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCards", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PaymentCard1ID",
                table: "AspNetUsers",
                column: "PaymentCard1ID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PaymentCard2ID",
                table: "AspNetUsers",
                column: "PaymentCard2ID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PaymentCard3ID",
                table: "AspNetUsers",
                column: "PaymentCard3ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PaymentCards_PaymentCard1ID",
                table: "AspNetUsers",
                column: "PaymentCard1ID",
                principalTable: "PaymentCards",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PaymentCards_PaymentCard2ID",
                table: "AspNetUsers",
                column: "PaymentCard2ID",
                principalTable: "PaymentCards",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PaymentCards_PaymentCard3ID",
                table: "AspNetUsers",
                column: "PaymentCard3ID",
                principalTable: "PaymentCards",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PaymentCards_PaymentCard1ID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PaymentCards_PaymentCard2ID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PaymentCards_PaymentCard3ID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PaymentCards");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PaymentCard1ID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PaymentCard2ID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PaymentCard3ID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PaymentCard1ID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PaymentCard2ID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PaymentCard3ID",
                table: "AspNetUsers");
        }
    }
}
