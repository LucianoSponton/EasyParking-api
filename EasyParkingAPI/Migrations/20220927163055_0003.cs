using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyParkingAPI.Migrations
{
    public partial class _0003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apodo",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apodo",
                table: "AspNetUsers");
        }
    }
}
