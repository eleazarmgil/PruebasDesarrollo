using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCABPagaloTodoMS.Infrastructure.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleDeOpcion_OpcionDePago_opcionDePagoId",
                table: "DetalleDeOpcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Conciliacion_conciliacionId",
                table: "Pago");

            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Servicio_servicioId",
                table: "Pago");

            migrationBuilder.DropIndex(
                name: "IX_Pago_servicioId",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "cedula",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "servicioId",
                table: "Pago");

            migrationBuilder.RenameColumn(
                name: "nombre_completo",
                table: "Pago",
                newName: "fecha");

            migrationBuilder.RenameColumn(
                name: "conciliacionId",
                table: "Pago",
                newName: "ServicioEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Pago_conciliacionId",
                table: "Pago",
                newName: "IX_Pago_ServicioEntityId");

            migrationBuilder.RenameColumn(
                name: "opcionDePagoId",
                table: "DetalleDeOpcion",
                newName: "OpcionDePagoEntityId");

            migrationBuilder.RenameColumn(
                name: "descripcion",
                table: "DetalleDeOpcion",
                newName: "tipo_dato");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleDeOpcion_opcionDePagoId",
                table: "DetalleDeOpcion",
                newName: "IX_DetalleDeOpcion_OpcionDePagoEntityId");

            migrationBuilder.AddColumn<Guid>(
                name: "ConciliacionEntityId",
                table: "Pago",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServicioEntityId",
                table: "OpcionDePago",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cant_caracteres",
                table: "DetalleDeOpcion",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "formato",
                table: "DetalleDeOpcion",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pago_ConciliacionEntityId",
                table: "Pago",
                column: "ConciliacionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcionDePago_ServicioEntityId",
                table: "OpcionDePago",
                column: "ServicioEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleDeOpcion_OpcionDePago_OpcionDePagoEntityId",
                table: "DetalleDeOpcion",
                column: "OpcionDePagoEntityId",
                principalTable: "OpcionDePago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpcionDePago_Servicio_ServicioEntityId",
                table: "OpcionDePago",
                column: "ServicioEntityId",
                principalTable: "Servicio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Conciliacion_ConciliacionEntityId",
                table: "Pago",
                column: "ConciliacionEntityId",
                principalTable: "Conciliacion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Servicio_ServicioEntityId",
                table: "Pago",
                column: "ServicioEntityId",
                principalTable: "Servicio",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleDeOpcion_OpcionDePago_OpcionDePagoEntityId",
                table: "DetalleDeOpcion");

            migrationBuilder.DropForeignKey(
                name: "FK_OpcionDePago_Servicio_ServicioEntityId",
                table: "OpcionDePago");

            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Conciliacion_ConciliacionEntityId",
                table: "Pago");

            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Servicio_ServicioEntityId",
                table: "Pago");

            migrationBuilder.DropIndex(
                name: "IX_Pago_ConciliacionEntityId",
                table: "Pago");

            migrationBuilder.DropIndex(
                name: "IX_OpcionDePago_ServicioEntityId",
                table: "OpcionDePago");

            migrationBuilder.DropColumn(
                name: "ConciliacionEntityId",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "ServicioEntityId",
                table: "OpcionDePago");

            migrationBuilder.DropColumn(
                name: "cant_caracteres",
                table: "DetalleDeOpcion");

            migrationBuilder.DropColumn(
                name: "formato",
                table: "DetalleDeOpcion");

            migrationBuilder.RenameColumn(
                name: "fecha",
                table: "Pago",
                newName: "nombre_completo");

            migrationBuilder.RenameColumn(
                name: "ServicioEntityId",
                table: "Pago",
                newName: "conciliacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Pago_ServicioEntityId",
                table: "Pago",
                newName: "IX_Pago_conciliacionId");

            migrationBuilder.RenameColumn(
                name: "tipo_dato",
                table: "DetalleDeOpcion",
                newName: "descripcion");

            migrationBuilder.RenameColumn(
                name: "OpcionDePagoEntityId",
                table: "DetalleDeOpcion",
                newName: "opcionDePagoId");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleDeOpcion_OpcionDePagoEntityId",
                table: "DetalleDeOpcion",
                newName: "IX_DetalleDeOpcion_opcionDePagoId");

            migrationBuilder.AddColumn<int>(
                name: "cedula",
                table: "Usuario",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "servicioId",
                table: "Pago",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pago_servicioId",
                table: "Pago",
                column: "servicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleDeOpcion_OpcionDePago_opcionDePagoId",
                table: "DetalleDeOpcion",
                column: "opcionDePagoId",
                principalTable: "OpcionDePago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Conciliacion_conciliacionId",
                table: "Pago",
                column: "conciliacionId",
                principalTable: "Conciliacion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Servicio_servicioId",
                table: "Pago",
                column: "servicioId",
                principalTable: "Servicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
