using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCABPagaloTodoMS.Infrastructure.Migrations
{
    public partial class prueba1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    cedula = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    usuario = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    correo = table.Column<string>(type: "text", nullable: true),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    apellido = table.Column<string>(type: "text", nullable: true),
                    preguntas_de_seguridad = table.Column<string>(type: "text", nullable: true),
                    preguntas_de_seguridad2 = table.Column<string>(type: "text", nullable: true),
                    respuesta_de_seguridad = table.Column<string>(type: "text", nullable: true),
                    respuesta_de_seguridad2 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpcionDePago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    estatus = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcionDePago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    rif = table.Column<int>(type: "integer", nullable: true),
                    nombre_empresa = table.Column<string>(type: "text", nullable: true),
                    estado = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    usuario = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    correo = table.Column<string>(type: "text", nullable: true),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    apellido = table.Column<string>(type: "text", nullable: true),
                    preguntas_de_seguridad = table.Column<string>(type: "text", nullable: true),
                    preguntas_de_seguridad2 = table.Column<string>(type: "text", nullable: true),
                    respuesta_de_seguridad = table.Column<string>(type: "text", nullable: true),
                    respuesta_de_seguridad2 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Valores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Apellido = table.Column<string>(type: "text", nullable: true),
                    Identificacion = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conciliacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AdministradorEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conciliacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conciliacion_Administrador_AdministradorEntityId",
                        column: x => x.AdministradorEntityId,
                        principalTable: "Administrador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleDeOpcion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    opcionDePagoEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDeOpcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleDeOpcion_OpcionDePago_opcionDePagoEntityId",
                        column: x => x.opcionDePagoEntityId,
                        principalTable: "OpcionDePago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicioEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    monto = table.Column<double>(type: "double precision", nullable: true),
                    prestadorEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicioEntity_Prestador_prestadorEntityId",
                        column: x => x.prestadorEntityId,
                        principalTable: "Prestador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    monto = table.Column<double>(type: "double precision", nullable: true),
                    nombre_completo = table.Column<DateOnly>(type: "date", nullable: true),
                    opcionDePagoEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConciliacionEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pago_Conciliacion_ConciliacionEntityId",
                        column: x => x.ConciliacionEntityId,
                        principalTable: "Conciliacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pago_OpcionDePago_opcionDePagoEntityId",
                        column: x => x.opcionDePagoEntityId,
                        principalTable: "OpcionDePago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumidor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ci = table.Column<int>(type: "integer", nullable: true),
                    pagoEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    usuario = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    correo = table.Column<string>(type: "text", nullable: true),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    apellido = table.Column<string>(type: "text", nullable: true),
                    preguntas_de_seguridad = table.Column<string>(type: "text", nullable: true),
                    preguntas_de_seguridad2 = table.Column<string>(type: "text", nullable: true),
                    respuesta_de_seguridad = table.Column<string>(type: "text", nullable: true),
                    respuesta_de_seguridad2 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumidor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumidor_Pago_pagoEntityId",
                        column: x => x.pagoEntityId,
                        principalTable: "Pago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleDePagoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    detalle = table.Column<string>(type: "text", nullable: true),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    pagoEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDePagoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleDePagoEntity_Pago_pagoEntityId",
                        column: x => x.pagoEntityId,
                        principalTable: "Pago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagoEntityServicioEntity",
                columns: table => new
                {
                    pagosId = table.Column<Guid>(type: "uuid", nullable: false),
                    servicioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoEntityServicioEntity", x => new { x.pagosId, x.servicioId });
                    table.ForeignKey(
                        name: "FK_PagoEntityServicioEntity_Pago_pagosId",
                        column: x => x.pagosId,
                        principalTable: "Pago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagoEntityServicioEntity_ServicioEntity_servicioId",
                        column: x => x.servicioId,
                        principalTable: "ServicioEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conciliacion_AdministradorEntityId",
                table: "Conciliacion",
                column: "AdministradorEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumidor_pagoEntityId",
                table: "Consumidor",
                column: "pagoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDeOpcion_opcionDePagoEntityId",
                table: "DetalleDeOpcion",
                column: "opcionDePagoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDePagoEntity_pagoEntityId",
                table: "DetalleDePagoEntity",
                column: "pagoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_ConciliacionEntityId",
                table: "Pago",
                column: "ConciliacionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_opcionDePagoEntityId",
                table: "Pago",
                column: "opcionDePagoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoEntityServicioEntity_servicioId",
                table: "PagoEntityServicioEntity",
                column: "servicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioEntity_prestadorEntityId",
                table: "ServicioEntity",
                column: "prestadorEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumidor");

            migrationBuilder.DropTable(
                name: "DetalleDeOpcion");

            migrationBuilder.DropTable(
                name: "DetalleDePagoEntity");

            migrationBuilder.DropTable(
                name: "PagoEntityServicioEntity");

            migrationBuilder.DropTable(
                name: "Valores");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "ServicioEntity");

            migrationBuilder.DropTable(
                name: "Conciliacion");

            migrationBuilder.DropTable(
                name: "OpcionDePago");

            migrationBuilder.DropTable(
                name: "Prestador");

            migrationBuilder.DropTable(
                name: "Administrador");
        }
    }
}
