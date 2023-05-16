using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCABPagaloTodoMS.Infrastructure.Migrations
{
    public partial class pruebita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PagoEntityId",
                table: "Usuario",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "opcion_de_pagoId",
                table: "Usuario",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "servicioId",
                table: "Usuario",
                type: "uuid",
                nullable: true);

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
                name: "Servicio",
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
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DetalleDePagoEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    monto = table.Column<double>(type: "double precision", nullable: true),
                    nombre_completo = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pago_DetalleDePagoEntity_DetalleDePagoEntityId",
                        column: x => x.DetalleDePagoEntityId,
                        principalTable: "DetalleDePagoEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcionDePagoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PagoEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    DetalleDeOpcionEntityId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpcionDePagoEntity_Pago_PagoEntityId",
                        column: x => x.PagoEntityId,
                        principalTable: "Pago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_OpcionDePagoEntity_DetalleDeOpcionEntityId",
                table: "OpcionDePagoEntity",
                column: "DetalleDeOpcionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcionDePagoEntity_PagoEntityId",
                table: "OpcionDePagoEntity",
                column: "PagoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_DetalleDePagoEntityId",
                table: "Pago",
                column: "DetalleDePagoEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_OpcionDePagoEntity_opcion_de_pagoId",
                table: "Usuario",
                column: "opcion_de_pagoId",
                principalTable: "OpcionDePagoEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Pago_PagoEntityId",
                table: "Usuario",
                column: "PagoEntityId",
                principalTable: "Pago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Servicio_servicioId",
                table: "Usuario",
                column: "servicioId",
                principalTable: "Servicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_OpcionDePagoEntity_opcion_de_pagoId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Pago_PagoEntityId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Servicio_servicioId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "OpcionDePagoEntity");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "DetalleDeOpcionEntity");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "DetalleDePagoEntity");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_opcion_de_pagoId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PagoEntityId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_servicioId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PagoEntityId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "opcion_de_pagoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "servicioId",
                table: "Usuario");
        }
    }
}
