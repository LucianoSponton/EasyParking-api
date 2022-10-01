using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EasyParkingAPI.Migrations.Data
{
    public partial class _0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TipoDeDocumento = table.Column<int>(nullable: false),
                    NumeroDeDocumento = table.Column<string>(nullable: true),
                    FechaDeNacimiento = table.Column<DateTime>(nullable: false),
                    Link_Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estacionamientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    applicationUserId = table.Column<string>(nullable: true),
                    Imagen = table.Column<byte[]>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    TipoDeLugar = table.Column<string>(nullable: true),
                    MontoReserva = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estacionamientos_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataVehiculoAlojado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDeVehiculo = table.Column<string>(nullable: true),
                    CapacidadDeAlojamiento = table.Column<int>(nullable: false),
                    Tarifa_Hora = table.Column<decimal>(nullable: false),
                    Tarifa_Dia = table.Column<decimal>(nullable: false),
                    Tarifa_Semana = table.Column<decimal>(nullable: false),
                    Tarifa_Mes = table.Column<decimal>(nullable: false),
                    EstacionamientoId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_DataVehiculoAlojado_EstacionamientoId",
                table: "DataVehiculoAlojado",
                column: "EstacionamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamientos_UserId",
                table: "Estacionamientos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataVehiculoAlojado");

            migrationBuilder.DropTable(
                name: "Estacionamientos");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
