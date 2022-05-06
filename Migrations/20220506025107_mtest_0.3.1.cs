using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWeb.Migrations
{
    public partial class mtest_031 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowTimeId",
                table: "Tickets");

            migrationBuilder.AddColumn<uint>(
                name: "ShowTimeIdID",
                table: "Tickets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Promotions",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Promotions",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowTimeIdID",
                table: "Tickets",
                column: "ShowTimeIdID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ShowTimes_ShowTimeIdID",
                table: "Tickets",
                column: "ShowTimeIdID",
                principalTable: "ShowTimes",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ShowTimes_ShowTimeIdID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ShowTimeIdID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ShowTimeIdID",
                table: "Tickets");

            migrationBuilder.AddColumn<uint>(
                name: "ShowTimeId",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Promotions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Promotions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
