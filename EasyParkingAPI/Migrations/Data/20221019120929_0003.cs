using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyParkingAPI.Migrations.Data
{
    public partial class _0003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataVehiculoAlojado");

            migrationBuilder.DropTable(
                name: "RangoH");

            migrationBuilder.DropTable(
                name: "Jornada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataVehiculoAlojado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacidadDeAlojamiento = table.Column<int>(type: "int", nullable: false),
                    EstacionamientoId = table.Column<int>(type: "int", nullable: true),
                    Tarifa_Dia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tarifa_Hora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tarifa_Mes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tarifa_Semana = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoDeVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataVehiculoAlojado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataVehiculoAlojado_Estacionamientos_EstacionamientoId",
                        column: x => x.EstacionamientoId,
                        principalTable: "Estacionamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jornada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaDeLaSemana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstacionamientoId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesdeHora = table.Column<int>(type: "int", nullable: false),
                    DesdeMinuto = table.Column<int>(type: "int", nullable: false),
                    HastaHora = table.Column<int>(type: "int", nullable: false),
                    HastaMinuto = table.Column<int>(type: "int", nullable: false),
                    JornadaId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_DataVehiculoAlojado_EstacionamientoId",
                table: "DataVehiculoAlojado",
                column: "EstacionamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jornada_EstacionamientoId",
                table: "Jornada",
                column: "EstacionamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_RangoH_JornadaId",
                table: "RangoH",
                column: "JornadaId");
        }
    }
}
