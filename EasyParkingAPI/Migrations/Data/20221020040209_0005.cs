using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyParkingAPI.Migrations.Data
{
    public partial class _0005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataVehiculoAlojados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstacionamientoId = table.Column<int>(nullable: true),
                    TipoDeVehiculo = table.Column<string>(nullable: true),
                    CapacidadDeAlojamiento = table.Column<int>(nullable: false),
                    Tarifa_Hora = table.Column<decimal>(nullable: false),
                    Tarifa_Dia = table.Column<decimal>(nullable: false),
                    Tarifa_Semana = table.Column<decimal>(nullable: false),
                    Tarifa_Mes = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataVehiculoAlojados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataVehiculoAlojados_Estacionamientos_EstacionamientoId",
                        column: x => x.EstacionamientoId,
                        principalTable: "Estacionamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jornadas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstacionamientoId = table.Column<int>(nullable: true),
                    DiaDeLaSemana = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jornadas_Estacionamientos_EstacionamientoId",
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
                        name: "FK_RangoH_Jornadas_JornadaId",
                        column: x => x.JornadaId,
                        principalTable: "Jornadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataVehiculoAlojados_EstacionamientoId",
                table: "DataVehiculoAlojados",
                column: "EstacionamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jornadas_EstacionamientoId",
                table: "Jornadas",
                column: "EstacionamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_RangoH_JornadaId",
                table: "RangoH",
                column: "JornadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataVehiculoAlojados");

            migrationBuilder.DropTable(
                name: "RangoH");

            migrationBuilder.DropTable(
                name: "Jornadas");
        }
    }
}
