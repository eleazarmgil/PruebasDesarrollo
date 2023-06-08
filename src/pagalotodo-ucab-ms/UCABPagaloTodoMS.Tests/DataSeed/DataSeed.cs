using Moq;
using MockQueryable.Moq;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UCABPagaloTodoMS.Core.Database;
using Microsoft.EntityFrameworkCore;
using UCABPagaloTodoMS.Core.Entities;
using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Tests.DataSeed;

[ExcludeFromCodeCoverage]
public static class DataSeed
{
    //Seed de los Valores
    public static Mock<DbSet<ValoresEntity>> mock_valores = new Mock<DbSet<ValoresEntity>>();
    //Seed de los usuarios
    public static Mock<DbSet<UsuarioEntity>> mock_usuario = new Mock<DbSet<UsuarioEntity>>();
    public static Mock<DbSet<PrestadorEntity>> mock_prestador = new Mock<DbSet<PrestadorEntity>>();
    public static Mock<DbSet<ConsumidorEntity>> mock_consumidor = new Mock<DbSet<ConsumidorEntity>>();
    public static Mock<DbSet<AdministradorEntity>> mock_administrador = new Mock<DbSet<AdministradorEntity>>();
    //Seed de los pagos
    public static Mock<DbSet<PagoEntity>> mock_pago = new Mock<DbSet<PagoEntity>>();
    public static Mock<DbSet<DetalleDePagoEntity>> mock_detalle_de_pago = new Mock<DbSet<DetalleDePagoEntity>>();
    public static Mock<DbSet<DetalleDeOpcionEntity>> mock_detalle_de_opcion = new Mock<DbSet<DetalleDeOpcionEntity>>();
    public static Mock<DbSet<OpcionDePagoEntity>> mock_opcion_de_pago = new Mock<DbSet<OpcionDePagoEntity>>();
    //Seed de los Servicios
    public static Mock<DbSet<ServicioEntity>> mock_servicio = new Mock<DbSet<ServicioEntity>>();
    //Seed de la conciliacion
    public static Mock<DbSet<ConciliacionEntity>> mock_conciliacion = new Mock<DbSet<ConciliacionEntity>>();

    public static void SetupDbContextData(this Mock<IUCABPagaloTodoDbContext> mockContext)
    {

        //Valores
        var request_valores = new List<ValoresEntity>
        {
            new ValoresEntity
            {
                Id = new Guid("907dd04e-6648-4168-a835-129c29ac9fb2"),
                Nombre = "Maria",
                Apellido = "Arteaga",
                Identificacion = "213213344"
            },
        };

        //usuario
        var request_usuarios = new List<UsuarioEntity>
        {
             new UsuarioEntity
             {
                  Id=Guid.NewGuid(),
                  CreatedAt = DateTime.Now,
                  CreatedBy="Admin",
                  UpdatedAt=DateTime.Now,
                  UpdatedBy="",

                  usuario ="Usuario1",
                  password="password1",
                  correo="prueba@gmail.com",
                  nombre ="Luis",
                  apellido="Febles",
                  preguntas_de_seguridad= "Pregunta1",
                  preguntas_de_seguridad2 = "Pregunta2",
                  respuesta_de_seguridad= "Respuesta1",
                  respuesta_de_seguridad2= "Respuesta2",
                  estado=true,
             }
        };
        //administradores
        var request_administrador = new List<AdministradorEntity>
        {
             new AdministradorEntity
             {
                  Id=Guid.NewGuid(),
                  CreatedAt = DateTime.Now,
                  CreatedBy="Admin",
                  UpdatedAt=DateTime.Now,
                  UpdatedBy="",

                  usuario ="Usuario_admin1",
                  password="password_admin1",
                  correo="prueba@gmail.com",
                  nombre ="Luis",
                  apellido="Febles",
                  preguntas_de_seguridad= "Pregunta1",
                  preguntas_de_seguridad2 = "Pregunta2",
                  respuesta_de_seguridad= "Respuesta1",
                  respuesta_de_seguridad2= "Respuesta2",
                  estado=true,
             },

             new AdministradorEntity
             {
                  Id=Guid.NewGuid(),
                  CreatedAt = DateTime.Now,
                  CreatedBy="Admin",
                  UpdatedAt=DateTime.Now,
                  UpdatedBy="",

                  usuario ="Usuario_admin2",
                  password="Password.1",
                  correo="SeedPruebas@gmail.com",
                  nombre ="Maga",
                  apellido="Febles",
                  preguntas_de_seguridad= "Pregunta1",
                  preguntas_de_seguridad2 = "Pregunta2",
                  respuesta_de_seguridad= "Respuesta1",
                  respuesta_de_seguridad2= "Respuesta2",
                  estado=true,
             }
        };
        //Prestador
        var request_prestador = new List<PrestadorEntity>
        {
             new PrestadorEntity
             {
                  Id=Guid.NewGuid(),
                  CreatedAt = DateTime.Now,
                  CreatedBy="Admin",
                  UpdatedAt=DateTime.Now,
                  UpdatedBy="",

                  usuario ="Usuario1",
                  password="password1",
                  correo="prueba@gmail.com",
                  nombre ="Luis",
                  apellido="Febles",
                  preguntas_de_seguridad= "Pregunta1",
                  preguntas_de_seguridad2 = "Pregunta2",
                  respuesta_de_seguridad= "Respuesta1",
                  respuesta_de_seguridad2= "Respuesta2",
                  estado=true,

                  rif="V-272792001",
                  nombre_empresa ="Polar",
             }
        };
        //Consumidor
        var request_consumidor = new List<ConsumidorEntity>
        {
             new ConsumidorEntity
             {
                  Id=Guid.NewGuid(),
                  CreatedAt = DateTime.Now,
                  CreatedBy="Admin",
                  UpdatedAt=DateTime.Now,
                  UpdatedBy="",

                  usuario ="Usuario1",
                  password="password1",
                  correo="prueba@gmail.com",
                  nombre ="Luis",
                  apellido="Febles",
                  preguntas_de_seguridad= "Pregunta1",
                  preguntas_de_seguridad2 = "Pregunta2",
                  respuesta_de_seguridad= "Respuesta1",
                  respuesta_de_seguridad2= "Respuesta2",
                  estado=true,

                  ci="V-27279200",
             }
        };




        //Usuario DataSeed
        mockContext.Setup(C => C.Usuario).Returns(request_usuarios.AsQueryable().BuildMockDbSet().Object);
        mockContext.Setup(C => C.Prestador).Returns(request_prestador.AsQueryable().BuildMockDbSet().Object);
        mockContext.Setup(C => C.Administrador).Returns(request_administrador.AsQueryable().BuildMockDbSet().Object);
        mockContext.Setup(C => C.Consumidor).Returns(request_consumidor.AsQueryable().BuildMockDbSet().Object);
        mockContext.Setup(c => c.Valores).Returns(request_valores.AsQueryable().BuildMockDbSet().Object);

    }
}
