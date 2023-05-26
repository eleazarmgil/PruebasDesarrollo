using Moq;
using MockQueryable.Moq;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UCABPagaloTodoMS.Core.Database;
using Microsoft.EntityFrameworkCore;
using static Bogus.Person.CardAddress;
using System.Text.RegularExpressions;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Tests.DataSeed;
public static class DataSeed
{
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

    }
}
