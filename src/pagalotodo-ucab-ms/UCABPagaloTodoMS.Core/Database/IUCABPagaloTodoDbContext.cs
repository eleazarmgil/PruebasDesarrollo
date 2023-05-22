using Microsoft.EntityFrameworkCore;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Core.Database;
public interface IUCABPagaloTodoDbContext
{
    DbSet<ValoresEntity> Valores { get; set; } 
    DbSet<UsuarioEntity> Usuario { get; set; } 
    DbSet<AdministradorEntity> Administrador { get; set; } 
    DbSet<ConciliacionEntity> Conciliacion { get; set; } 
    DbSet<ConsumidorEntity> Consumidor { get; set; } 
    DbSet<DetalleDeOpcionEntity> DetalleDeOpcion { get; set; } 
    DbSet<OpcionDePagoEntity> OpcionDePago { get; set; }
    DbSet<DetalleDePagoEntity> DetalleDePago { get; set; }
    DbSet<PagoEntity> Pago { get; set; } 
    DbSet<PrestadorEntity> Prestador { get; set; } 
    DbSet<ServicioEntity> Servicio { get; set; } 
    DbContext DbContext
    {
        get;
    }

    IDbContextTransactionProxy BeginTransaction();

    void ChangeEntityState<TEntity>(TEntity entity, EntityState state);

    Task<bool> SaveEfContextChanges(string user, CancellationToken cancellationToken = default);

}
