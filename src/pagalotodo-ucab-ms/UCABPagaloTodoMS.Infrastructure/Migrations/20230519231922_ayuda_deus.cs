using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCABPagaloTodoMS.Infrastructure.Migrations
{
    public partial class ayuda_deus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetalleDeOpcionEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDeOpcionEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleDePagoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    detalle = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDePagoEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicioEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PagoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DetalleDePagoEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    monto = table.Column<double>(type: "double precision", nullable: true),
                    nombre_completo = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagoEntity_DetalleDePagoEntity_DetalleDePagoEntityId",
                        column: x => x.DetalleDePagoEntityId,
                        principalTable: "DetalleDePagoEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpcionDePagoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PagoEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    DetalleDeOpcionEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    estatus = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcionDePagoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcionDePagoEntity_DetalleDeOpcionEntity_DetalleDeOpcionEnt~",
                        column: x => x.DetalleDeOpcionEntityId,
                        principalTable: "DetalleDeOpcionEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpcionDePagoEntity_PagoEntity_PagoEntityId",
                        column: x => x.PagoEntityId,
                        principalTable: "PagoEntity",
                        principalColumn: "Id");
                });

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
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    PagoEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    ci = table.Column<int>(type: "integer", nullable: true),
                    servicioId = table.Column<Guid>(type: "uuid", nullable: true),
                    opcion_de_pagoId = table.Column<Guid>(type: "uuid", nullable: true),
                    rif = table.Column<int>(type: "integer", nullable: true),
                    nombre_empresa = table.Column<string>(type: "text", nullable: true),
                    estado = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_OpcionDePagoEntity_opcion_de_pagoId",
                        column: x => x.opcion_de_pagoId,
                        principalTable: "OpcionDePagoEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_PagoEntity_PagoEntityId",
                        column: x => x.PagoEntityId,
                        principalTable: "PagoEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_ServicioEntity_servicioId",
                        column: x => x.servicioId,
                        principalTable: "ServicioEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpcionDePagoEntity_DetalleDeOpcionEntityId",
                table: "OpcionDePagoEntity",
                column: "DetalleDeOpcionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcionDePagoEntity_PagoEntityId",
                table: "OpcionDePagoEntity",
                column: "PagoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoEntity_DetalleDePagoEntityId",
                table: "PagoEntity",
                column: "DetalleDePagoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_opcion_de_pagoId",
                table: "Usuario",
                column: "opcion_de_pagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PagoEntityId",
                table: "Usuario",
                column: "PagoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_servicioId",
                table: "Usuario",
                column: "servicioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "OpcionDePagoEntity");

            migrationBuilder.DropTable(
                name: "ServicioEntity");

            migrationBuilder.DropTable(
                name: "DetalleDeOpcionEntity");

            migrationBuilder.DropTable(
                name: "PagoEntity");

            migrationBuilder.DropTable(
                name: "DetalleDePagoEntity");
        }
    }
}
