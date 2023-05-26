using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Infrastructure.Correo;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Handlers.Commands;

public class AdministradorActualizarConsumidorCommandHandler : IRequestHandler<AdministradorActualizarConsumidorCommand, Guid>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<AdministradorActualizarConsumidorCommandHandler> _logger;
    private EnviarCorreo correo = new EnviarCorreo();

    public AdministradorActualizarConsumidorCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<AdministradorActualizarConsumidorCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> Handle(AdministradorActualizarConsumidorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._request == null)
            {
                _logger.LogWarning("AdministradorActualizarConsumidorCommandHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                return await HandleAsync(request);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<Guid> HandleAsync(AdministradorActualizarConsumidorCommand request)
    {
        var transaccion = _dbContext.BeginTransaction();
        try
        {
            _logger.LogInformation("AdministradorActualizarConsumidorCommandHandler.HandleAsync {Request}", request);

            var usuario_bd = _dbContext.Consumidor.FirstOrDefault(c => c.usuario == request._request.usuario);
            if (usuario_bd == null)
            {
                return await HandleAsync(request);
            }

            // Actualiza las propiedades del usuario
            foreach (var propiedad in typeof(AdministradorActualizarConsumidorRequest).GetProperties())
            {
                var valor = propiedad.GetValue(request._request);
                if (valor != null)
                {
                    typeof(ConsumidorEntity).GetProperty(propiedad.Name)?.SetValue(usuario_bd, valor);
                }
            }

            _dbContext.Usuario.Update(usuario_bd);
            await _dbContext.SaveEfContextChanges("APP");
            transaccion.Commit();
            _logger.LogInformation("AdministradorActualizarConsumidorCommandHandler.HandleAsync {Response}", usuario_bd.Id);

            return usuario_bd.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en AdministradorActualizarConsumidorCommandHandler.HandleAsync. {Mensaje}", ex.Message);
            transaccion.Rollback();
            throw;
        }

    }
}
