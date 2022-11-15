using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyParkingAPI.Migrations.Data
{
    public partial class _0008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RangoH_Jornadas_JornadaId",
                table: "RangoH");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RangoH",
                table: "RangoH");

            migrationBuilder.RenameTable(
                name: "RangoH",
                newName: "RangoHs");

            migrationBuilder.RenameIndex(
                name: "IX_RangoH_JornadaId",
                table: "RangoHs",
                newName: "IX_RangoHs_JornadaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RangoHs",
                table: "RangoHs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RangoHs_Jornadas_JornadaId",
                table: "RangoHs",
                column: "JornadaId",
                principalTable: "Jornadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RangoHs_Jornadas_JornadaId",
                table: "RangoHs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RangoHs",
                table: "RangoHs");

            migrationBuilder.RenameTable(
                name: "RangoHs",
                newName: "RangoH");

            migrationBuilder.RenameIndex(
                name: "IX_RangoHs_JornadaId",
                table: "RangoH",
                newName: "IX_RangoH_JornadaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RangoH",
                table: "RangoH",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RangoH_Jornadas_JornadaId",
                table: "RangoH",
                column: "JornadaId",
                principalTable: "Jornadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
