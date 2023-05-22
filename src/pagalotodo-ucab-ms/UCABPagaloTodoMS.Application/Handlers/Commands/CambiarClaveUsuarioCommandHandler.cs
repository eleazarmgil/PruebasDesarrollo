using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Infrastructure.Correo;
using UCABPagaloTodoMS.Core.Database;

namespace UCABPagaloTodoMS.Application.Handlers.Commands;
public class CambiarClaveUsuarioCommandHandler : IRequestHandler<CambiarClaveCommand ,Guid>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<CambiarClaveUsuarioCommandHandler> _logger;
    private EnviarCorreo correo = new EnviarCorreo();

    public CambiarClaveUsuarioCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<CambiarClaveUsuarioCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> Handle(CambiarClaveCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._request == null)
            {
                _logger.LogWarning("CambiarClaveUsuarioCommandHandler.Handle: Request nulo.");
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

    private async Task<Guid> HandleAsync(CambiarClaveCommand request)
    {
        var transaccion = _dbContext.BeginTransaction();
        try
        {
            _logger.LogInformation("CambiarClaveUsuarioCommandHandler.HandleAsync {Request}", request);
            // Busca el usuario que deseas actualizar
            var usuario_bd = _dbContext.Usuario.FirstOrDefault(c => c.usuario == request._request.usuario);

            if (usuario_bd != null) //Si el usuario existe
            {
                if (request._request.newpassword != null) //Y la nueva password no es vacia
                {
                    usuario_bd.password = request._request.newpassword;

                    _dbContext.Usuario.Update(usuario_bd);
                    await _dbContext.SaveEfContextChanges("APP");
                    transaccion.Commit();

                    _logger.LogInformation("AgregarValorePruebaCommandHandler.HandleAsync {Response}", usuario_bd.Id);
                    correo.EnviaCorreoUsuario(usuario_bd.correo, "Cambio de contraseña", "Su contraseña fue cambiada exitosamente, la nueva contraseña es: " + usuario_bd.password.ToString());

                    return usuario_bd.Id;

                }
            }
            return await HandleAsync(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarValoresQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            transaccion.Rollback();
            throw;
        }
    }
}
