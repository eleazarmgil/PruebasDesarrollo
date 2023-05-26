using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Infrastructure.Correo;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Handlers.Commands;

public class ActualizarServicioCommandHandler : IRequestHandler<ActualizarServicioCommand, Guid>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ActualizarServicioCommandHandler> _logger;
    private EnviarCorreo correo = new EnviarCorreo();

    public ActualizarServicioCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ActualizarServicioCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> Handle(ActualizarServicioCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._request == null)
            {
                _logger.LogWarning("ActualizarServicioCommandHandler.Handle: Request nulo.");
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

    private async Task<Guid> HandleAsync(ActualizarServicioCommand request)
    {
        var transaccion = _dbContext.BeginTransaction();
        try
        {
            _logger.LogInformation("ActualizarServicioCommandHandler.HandleAsync {Request}", request);

            var servicio_bd = _dbContext.Servicio.FirstOrDefault(c => c.Id == request._request.Id);
            if (servicio_bd == null)
            {
                return await HandleAsync(request);
            }

            // Actualiza las propiedades del servicio
            foreach (var propiedad in typeof(ActualizarServicioRequest).GetProperties())
            {
                var valor = propiedad.GetValue(request._request);
                if (valor != null)
                {
                    typeof(ServicioEntity).GetProperty(propiedad.Name)?.SetValue(servicio_bd, valor);
                }
            }

            _dbContext.Servicio.Update(servicio_bd);
            await _dbContext.SaveEfContextChanges("APP");
            transaccion.Commit();
            _logger.LogInformation("ActualizarServicioCommandHandler.HandleAsync {Response}", servicio_bd.Id);

            return servicio_bd.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en ActualizarServicioCommandHandler.HandleAsync. {Mensaje}", ex.Message);
            transaccion.Rollback();
            throw;
        }

    }
}
