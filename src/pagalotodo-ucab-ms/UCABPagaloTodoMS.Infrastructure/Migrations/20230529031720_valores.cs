using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCABPagaloTodoMS.Infrastructure.Migrations
{
    public partial class valores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    correo = table.Column<string>(type: "text", nullable: true),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    apellido = table.Column<string>(type: "text", nullable: true),
                    preguntas_de_seguridad = table.Column<string>(type: "text", nullable: true),
                    preguntas_de_seguridad2 = table.Column<string>(type: "text", nullable: true),
                    respuesta_de_seguridad = table.Column<string>(type: "text", nullable: true),
                    respuesta_de_seguridad2 = table.Column<string>(type: "text", nullable: true),
                    estado = table.Column<bool>(type: "boolean", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    ci = table.Column<int>(type: "integer", nullable: true),
                    rif = table.Column<int>(type: "integer", nullable: true),
                    nombre_empresa = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conciliacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    administradorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conciliacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conciliacion_Usuario_administradorId",
                        column: x => x.administradorId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    monto = table.Column<double>(type: "double precision", nullable: true),
                    PrestadorEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicio_Usuario_PrestadorEntityId",
                        column: x => x.PrestadorEntityId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcionDePago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    estatus = table.Column<string>(type: "text", nullable: true),
                    ServicioEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcionDePago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcionDePago_Servicio_ServicioEntityId",
                        column: x => x.ServicioEntityId,
                        principalTable: "Servicio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetalleDeOpcion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    tipo_dato = table.Column<string>(type: "text", nullable: true),
                    cant_caracteres = table.Column<int>(type: "integer", nullable: true),
                    formato = table.Column<string>(type: "text", nullable: true),
                    OpcionDePagoEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDeOpcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleDeOpcion_OpcionDePago_OpcionDePagoEntityId",
                        column: x => x.OpcionDePagoEntityId,
                        principalTable: "OpcionDePago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    monto = table.Column<double>(type: "double precision", nullable: true),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    opcionDePagoId = table.Column<Guid>(type: "uuid", nullable: true),
                    ConsumidorId = table.Column<Guid>(type: "uuid", nullable: true),
                    ConciliacionEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    ServicioEntityId = table.Column<Guid>(type: "uuid", nullable: true),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pago_OpcionDePago_opcionDePagoId",
                        column: x => x.opcionDePagoId,
                        principalTable: "OpcionDePago",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pago_Servicio_ServicioEntityId",
                        column: x => x.ServicioEntityId,
                        principalTable: "Servicio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pago_Usuario_ConsumidorId",
                        column: x => x.ConsumidorId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetalleDePago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    detalle = table.Column<string>(type: "text", nullable: true),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    pagoid = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDePago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleDePago_Pago_pagoid",
                        column: x => x.pagoid,
                        principalTable: "Pago",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conciliacion_administradorId",
                table: "Conciliacion",
                column: "administradorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDeOpcion_OpcionDePagoEntityId",
                table: "DetalleDeOpcion",
                column: "OpcionDePagoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDePago_pagoid",
                table: "DetalleDePago",
                column: "pagoid");

            migrationBuilder.CreateIndex(
                name: "IX_OpcionDePago_ServicioEntityId",
                table: "OpcionDePago",
                column: "ServicioEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_ConciliacionEntityId",
                table: "Pago",
                column: "ConciliacionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_ConsumidorId",
                table: "Pago",
                column: "ConsumidorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_opcionDePagoId",
                table: "Pago",
                column: "opcionDePagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_ServicioEntityId",
                table: "Pago",
                column: "ServicioEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_PrestadorEntityId",
                table: "Servicio",
                column: "PrestadorEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleDeOpcion");

            migrationBuilder.DropTable(
                name: "DetalleDePago");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Conciliacion");

            migrationBuilder.DropTable(
                name: "OpcionDePago");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
