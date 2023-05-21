﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UCABPagaloTodoMS.Infrastructure.Database;

#nullable disable

namespace UCABPagaloTodoMS.Infrastructure.Migrations
{
    [DbContext(typeof(UCABPagaloTodoDbContext))]
    [Migration("20230521080616_prueba1")]
    partial class prueba1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PagoEntityServicioEntity", b =>
                {
                    b.Property<Guid>("pagosId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("servicioId")
                        .HasColumnType("uuid");

                    b.HasKey("pagosId", "servicioId");

                    b.HasIndex("servicioId");

                    b.ToTable("PagoEntityServicioEntity");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.AdministradorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("apellido")
                        .HasColumnType("text");

                    b.Property<int?>("cedula")
                        .HasColumnType("integer");

                    b.Property<string>("correo")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("preguntas_de_seguridad")
                        .HasColumnType("text");

                    b.Property<string>("preguntas_de_seguridad2")
                        .HasColumnType("text");

                    b.Property<string>("respuesta_de_seguridad")
                        .HasColumnType("text");

                    b.Property<string>("respuesta_de_seguridad2")
                        .HasColumnType("text");

                    b.Property<string>("usuario")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.ConciliacionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AdministradorEntityId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("fecha")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AdministradorEntityId");

                    b.ToTable("Conciliacion");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.ConsumidorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("apellido")
                        .HasColumnType("text");

                    b.Property<int?>("ci")
                        .HasColumnType("integer");

                    b.Property<string>("correo")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<Guid>("pagoEntityId")
                        .HasColumnType("uuid");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("preguntas_de_seguridad")
                        .HasColumnType("text");

                    b.Property<string>("preguntas_de_seguridad2")
                        .HasColumnType("text");

                    b.Property<string>("respuesta_de_seguridad")
                        .HasColumnType("text");

                    b.Property<string>("respuesta_de_seguridad2")
                        .HasColumnType("text");

                    b.Property<string>("usuario")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("pagoEntityId");

                    b.ToTable("Consumidor");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.DetalleDeOpcionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("descripcion")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<Guid>("opcionDePagoEntityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("opcionDePagoEntityId");

                    b.ToTable("DetalleDeOpcion");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.DetalleDePagoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("detalle")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<Guid>("pagoEntityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("pagoEntityId");

                    b.ToTable("DetalleDePagoEntity");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.OpcionDePagoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<int?>("estatus")
                        .HasColumnType("integer");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OpcionDePago");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.PagoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConciliacionEntityId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<double?>("monto")
                        .HasColumnType("double precision");

                    b.Property<DateOnly?>("nombre_completo")
                        .HasColumnType("date");

                    b.Property<Guid>("opcionDePagoEntityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ConciliacionEntityId");

                    b.HasIndex("opcionDePagoEntityId");

                    b.ToTable("Pago");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.PrestadorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("apellido")
                        .HasColumnType("text");

                    b.Property<string>("correo")
                        .HasColumnType("text");

                    b.Property<bool?>("estado")
                        .HasColumnType("boolean");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<string>("nombre_empresa")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("preguntas_de_seguridad")
                        .HasColumnType("text");

                    b.Property<string>("preguntas_de_seguridad2")
                        .HasColumnType("text");

                    b.Property<string>("respuesta_de_seguridad")
                        .HasColumnType("text");

                    b.Property<string>("respuesta_de_seguridad2")
                        .HasColumnType("text");

                    b.Property<int?>("rif")
                        .HasColumnType("integer");

                    b.Property<string>("usuario")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Prestador");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.ServicioEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("descripcion")
                        .HasColumnType("text");

                    b.Property<double?>("monto")
                        .HasColumnType("double precision");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<Guid>("prestadorEntityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("prestadorEntityId");

                    b.ToTable("ServicioEntity");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.ValoresEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Apellido")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Valores");
                });

            modelBuilder.Entity("PagoEntityServicioEntity", b =>
                {
                    b.HasOne("UCABPagaloTodoMS.Core.Entities.PagoEntity", null)
                        .WithMany()
                        .HasForeignKey("pagosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UCABPagaloTodoMS.Core.Entities.ServicioEntity", null)
                        .WithMany()
                        .HasForeignKey("servicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.ConciliacionEntity", b =>
                {
                    b.HasOne("UCABPagaloTodoMS.Core.Entities.AdministradorEntity", "administrador")
                        .WithMany("conciliacion")
                        .HasForeignKey("AdministradorEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("administrador");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.ConsumidorEntity", b =>
                {
                    b.HasOne("UCABPagaloTodoMS.Core.Entities.PagoEntity", "pago")
                        .WithMany("consumidor")
                        .HasForeignKey("pagoEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pago");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.DetalleDeOpcionEntity", b =>
                {
                    b.HasOne("UCABPagaloTodoMS.Core.Entities.OpcionDePagoEntity", "opcionDePago")
                        .WithMany("detalleDeOpcion")
                        .HasForeignKey("opcionDePagoEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("opcionDePago");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.DetalleDePagoEntity", b =>
                {
                    b.HasOne("UCABPagaloTodoMS.Core.Entities.PagoEntity", "pago")
                        .WithMany("detalleDePago")
                        .HasForeignKey("pagoEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pago");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.PagoEntity", b =>
                {
                    b.HasOne("UCABPagaloTodoMS.Core.Entities.ConciliacionEntity", "conciliacion")
                        .WithMany("pagos")
                        .HasForeignKey("ConciliacionEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UCABPagaloTodoMS.Core.Entities.OpcionDePagoEntity", "opcionDePago")
                        .WithMany("pagos")
                        .HasForeignKey("opcionDePagoEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("conciliacion");

                    b.Navigation("opcionDePago");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.ServicioEntity", b =>
                {
                    b.HasOne("UCABPagaloTodoMS.Core.Entities.PrestadorEntity", "prestador")
                        .WithMany("servicios")
                        .HasForeignKey("prestadorEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("prestador");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.AdministradorEntity", b =>
                {
                    b.Navigation("conciliacion");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.ConciliacionEntity", b =>
                {
                    b.Navigation("pagos");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.OpcionDePagoEntity", b =>
                {
                    b.Navigation("detalleDeOpcion");

                    b.Navigation("pagos");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.PagoEntity", b =>
                {
                    b.Navigation("consumidor");

                    b.Navigation("detalleDePago");
                });

            modelBuilder.Entity("UCABPagaloTodoMS.Core.Entities.PrestadorEntity", b =>
                {
                    b.Navigation("servicios");
                });
#pragma warning restore 612, 618
        }
    }
}
