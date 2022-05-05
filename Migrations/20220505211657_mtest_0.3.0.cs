using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Migrations
{
    public partial class mtest_030 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Promotions_MoviePromotionID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTimes_Movies_MovieIdID",
                table: "ShowTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTimes_Theaters_TheaterIdID",
                table: "ShowTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ShowTimes_ShowTimeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ShowTimeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MoviePromotionID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "PromoDeal",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "MoviePromotionID",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "PromoDescript",
                table: "Promotions",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "PromoCode",
                table: "Promotions",
                newName: "Description");

            migrationBuilder.AlterColumn<uint>(
                name: "TheaterIdID",
                table: "ShowTimes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u,
                oldClrType: typeof(uint),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<uint>(
                name: "MovieIdID",
                table: "ShowTimes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u,
                oldClrType: typeof(uint),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Artifacts",
                table: "Promotions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Promotions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Deal",
                table: "Promotions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Promotions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Promotions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTimes_Movies_MovieIdID",
                table: "ShowTimes",
                column: "MovieIdID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTimes_Theaters_TheaterIdID",
                table: "ShowTimes",
                column: "TheaterIdID",
                principalTable: "Theaters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowTimes_Movies_MovieIdID",
                table: "ShowTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTimes_Theaters_TheaterIdID",
                table: "ShowTimes");

            migrationBuilder.DropColumn(
                name: "Artifacts",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Deal",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Promotions",
                newName: "PromoDescript");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Promotions",
                newName: "PromoCode");

            migrationBuilder.AlterColumn<uint>(
                name: "TheaterIdID",
                table: "ShowTimes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(uint),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<uint>(
                name: "MovieIdID",
                table: "ShowTimes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(uint),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "PromoDeal",
                table: "Promotions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MoviePromotionID",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowTimeId",
                table: "Tickets",
                column: "ShowTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MoviePromotionID",
                table: "Movies",
                column: "MoviePromotionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Promotions_MoviePromotionID",
                table: "Movies",
                column: "MoviePromotionID",
                principalTable: "Promotions",
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
                name: "FK_Tickets_ShowTimes_ShowTimeId",
                table: "Tickets",
                column: "ShowTimeId",
                principalTable: "ShowTimes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
