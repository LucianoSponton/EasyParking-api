using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyParkingAPI.Migrations.Data
{
    public partial class _0009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Inactivo",
                table: "Estacionamientos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inactivo",
                table: "Estacionamientos");
        }
    }
}
