using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Infrastructure.Correo;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Application.Requests;
using Org.BouncyCastle.Asn1.Ocsp;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Handlers.Commands;
public class AdministradorActualizarPrestadorCommandHandler : IRequestHandler<AdministradorActualizarPrestadorCommand, Guid>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<AdministradorActualizarPrestadorCommandHandler> _logger;
    private EnviarCorreo correo = new EnviarCorreo();

    public AdministradorActualizarPrestadorCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<AdministradorActualizarPrestadorCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> Handle(AdministradorActualizarPrestadorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._request == null)
            {
                _logger.LogWarning("ActualizarPrestadorCommandHandler.Handle: Request nulo.");
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

    private async Task<Guid> HandleAsync(AdministradorActualizarPrestadorCommand request)
    {
        var transaccion = _dbContext.BeginTransaction();
        try
        {
            _logger.LogInformation("ActualizarPrestadorCommandHandler.HandleAsync {Request}", request);

            var usuario_bd = _dbContext.Prestador.FirstOrDefault(c => c.usuario == request._request.usuario);
            if (usuario_bd == null)
            {
                return await HandleAsync(request);
            }

            // Actualiza las propiedades del usuario
            foreach (var propiedad in typeof(AdministradorActualizarPrestadorRequest).GetProperties())
            {
                var valor = propiedad.GetValue(request._request);
                if (valor != null)
                {
                    typeof(PrestadorEntity).GetProperty(propiedad.Name)?.SetValue(usuario_bd, valor);
                }
            }

            _dbContext.Usuario.Update(usuario_bd);
            await _dbContext.SaveEfContextChanges("APP");
            transaccion.Commit();
            _logger.LogInformation("ActualizarPrestadorCommandHandler.HandleAsync {Response}", usuario_bd.Id);

            return usuario_bd.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en ActualizarPrestadorCommandHandler.HandleAsync. {Mensaje}", ex.Message);
            transaccion.Rollback();
            throw;
        }

    }
}
