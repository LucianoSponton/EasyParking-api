using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyParkingAPI.Migrations.Data
{
    public partial class _0010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PublicacionPausada",
                table: "Estacionamientos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicacionPausada",
                table: "Estacionamientos");
        }
    }
}
