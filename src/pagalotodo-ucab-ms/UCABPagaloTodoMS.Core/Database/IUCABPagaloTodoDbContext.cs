﻿using Microsoft.EntityFrameworkCore;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Core.Database
{
    public interface IUCABPagaloTodoDbContext
    {
        DbSet<ValoresEntity> Valores { get; }
        DbSet<UsuarioEntity> Usuario { get; }
        DbSet<AdministradorEntity> Administrador { get; }

        DbSet<PrestadorEntity> Prestador { get; }

        DbSet<ConsumidorEntity> Consumidor { get; }

        DbContext DbContext
        {
            get;
        }

        IDbContextTransactionProxy BeginTransaction();

        void ChangeEntityState<TEntity>(TEntity entity, EntityState state);

        Task<bool> SaveEfContextChanges(string user, CancellationToken cancellationToken = default);

    }
}
