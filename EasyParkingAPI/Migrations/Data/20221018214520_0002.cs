using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyParkingAPI.Migrations.Data
{
    public partial class _0002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Estacionamientos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apodo",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FotoDePerfil",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sexo",
                table: "ApplicationUser",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Jornada",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstacionamientoId = table.Column<int>(nullable: true),
                    DiaDeLaSemana = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jornada_Estacionamientos_EstacionamientoId",
                        column: x => x.EstacionamientoId,
                        principalTable: "Estacionamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RangoH",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesdeHora = table.Column<int>(nullable: false),
                    DesdeMinuto = table.Column<int>(nullable: false),
                    HastaHora = table.Column<int>(nullable: false),
                    HastaMinuto = table.Column<int>(nullable: false),
                    JornadaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangoH", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RangoH_Jornada_JornadaId",
                        column: x => x.JornadaId,
                        principalTable: "Jornada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jornada_EstacionamientoId",
                table: "Jornada",
                column: "EstacionamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_RangoH_JornadaId",
                table: "RangoH",
                column: "JornadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RangoH");

            migrationBuilder.DropTable(
                name: "Jornada");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Estacionamientos");

            migrationBuilder.DropColumn(
                name: "Apodo",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "FotoDePerfil",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "ApplicationUser");
        }
    }
}
