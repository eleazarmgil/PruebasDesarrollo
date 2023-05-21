using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Infrastructure.Correo;
using UCABPagaloTodoMS.Core.Database;

namespace UCABPagaloTodoMS.Application.Handlers.Commands
{
    public class ActualizarPrestadorCommandHandler : IRequestHandler<ActualizarPrestadorCommand, Guid>
    {
        private readonly IUCABPagaloTodoDbContext _dbContext;
        private readonly ILogger<ActualizarPrestadorCommandHandler> _logger;
        private EnviarCorreo correo = new EnviarCorreo();

        public ActualizarPrestadorCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ActualizarPrestadorCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Guid> Handle(ActualizarPrestadorCommand request, CancellationToken cancellationToken)
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

        private async Task<Guid> HandleAsync(ActualizarPrestadorCommand request)
        {
            var transaccion = _dbContext.BeginTransaction();
            try
            {
                _logger.LogInformation("ActualizarPrestadorCommandHandler.HandleAsync {Request}", request);
                // Busca el usuario que deseas actualizar
                var usuario_bd = _dbContext.Prestador.FirstOrDefault(c => c.usuario == request._request.usuario);

                if (usuario_bd != null) //Si el usuario existe
                {
                    if (request._request.usuario != null) 
                    {
                        usuario_bd.usuario = request._request.usuario;
                    }

                    if (request._request.password != null) 
                    {
                        usuario_bd.password = request._request.password;
                    }

                    if (request._request.correo != null) 
                    {
                        usuario_bd.correo = request._request.correo;
                    }

                    if (request._request.nombre != null) 
                    {
                        usuario_bd.nombre = request._request.nombre;
                    }

                    if (request._request.apellido != null) 
                    {
                        usuario_bd.apellido = request._request.apellido;
                    }

                    if (request._request.preguntas_de_seguridad != null) 
                    {
                        usuario_bd.preguntas_de_seguridad = request._request.preguntas_de_seguridad;
                    }

                    if (request._request.preguntas_de_seguridad2 != null) 
                    {
                        usuario_bd.preguntas_de_seguridad2 = request._request.preguntas_de_seguridad2;
                    }

                    if (request._request.respuesta_de_seguridad != null)
                    {
                        usuario_bd.respuesta_de_seguridad = request._request.respuesta_de_seguridad;
                    }

                    if (request._request.respuesta_de_seguridad2 != null)
                    {
                        usuario_bd.respuesta_de_seguridad2 = request._request.respuesta_de_seguridad2;
                    }

                    if (request._request.rif != null)
                    {
                        usuario_bd.rif = request._request.rif;
                    }

                    if (request._request.nombre_empresa != null)
                    {
                        usuario_bd.nombre_empresa = request._request.nombre_empresa;
                    }
                    if (request._request.estado != null)
                    {
                        usuario_bd.estado = request._request.estado;
                    }

                    _dbContext.Usuario.Update(usuario_bd);
                    await _dbContext.SaveEfContextChanges("APP");
                    transaccion.Commit();
                    _logger.LogInformation("ActualizarPrestadorCommandHandler.HandleAsync {Response}", usuario_bd.Id);

                    return usuario_bd.Id;
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
}
