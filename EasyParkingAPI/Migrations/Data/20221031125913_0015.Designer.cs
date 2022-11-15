﻿// <auto-generated />
using System;
using EasyParkingAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyParkingAPI.Migrations.Data
{
    [DbContext(typeof(DataContext))]
    [Migration("20221031125913_0015")]
    partial class _0015
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.DataVehiculoAlojado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapacidadDeAlojamiento")
                        .HasColumnType("int");

                    b.Property<int?>("EstacionamientoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Tarifa_Dia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tarifa_Hora")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tarifa_Mes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tarifa_Semana")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoDeVehiculo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstacionamientoId");

                    b.ToTable("DataVehiculoAlojados");
                });

            modelBuilder.Entity("Model.Estacionamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Imagen")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Inactivo")
                        .HasColumnType("bit");

                    b.Property<decimal>("MontoReserva")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PublicacionPausada")
                        .HasColumnType("bit");

                    b.Property<string>("TipoDeLugar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estacionamientos");
                });

            modelBuilder.Entity("Model.Jornada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaDeLaSemana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstacionamientoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstacionamientoId");

                    b.ToTable("Jornadas");
                });

            modelBuilder.Entity("Model.RangoH", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DesdeHora")
                        .HasColumnType("int");

                    b.Property<int>("DesdeMinuto")
                        .HasColumnType("int");

                    b.Property<int>("HastaHora")
                        .HasColumnType("int");

                    b.Property<int>("HastaMinuto")
                        .HasColumnType("int");

                    b.Property<int?>("JornadaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JornadaId");

                    b.ToTable("RangoHs");
                });

            modelBuilder.Entity("Model.DataVehiculoAlojado", b =>
                {
                    b.HasOne("Model.Estacionamiento", "Estacionamiento")
                        .WithMany("TiposDeVehiculosAdmitidos")
                        .HasForeignKey("EstacionamientoId");
                });

            modelBuilder.Entity("Model.Jornada", b =>
                {
                    b.HasOne("Model.Estacionamiento", "Estacionamiento")
                        .WithMany("Jornadas")
                        .HasForeignKey("EstacionamientoId");
                });

            modelBuilder.Entity("Model.RangoH", b =>
                {
                    b.HasOne("Model.Jornada", "Jornada")
                        .WithMany("Horarios")
                        .HasForeignKey("JornadaId");
                });
#pragma warning restore 612, 618
        }
    }
}
