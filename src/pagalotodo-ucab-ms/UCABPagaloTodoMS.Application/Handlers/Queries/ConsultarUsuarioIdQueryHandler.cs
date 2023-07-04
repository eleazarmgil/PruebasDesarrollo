using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;

public class ConsultarUsuarioIdQueryHandler : IRequestHandler<ConsultarUsuarioIdQuery, List<ConsultarUsuarioIdResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarUsuarioIdQueryHandler> _logger;
    public ConsultarUsuarioIdQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarUsuarioIdQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// Maneja una consulta de usurario y retorna toda la informacion asociada al id del usuario ConsultarUsuarioIdResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarUsuarioIdQuery que contiene la información necesaria para realizar la consulta.</param>
    /// <param name="cancellationToken">El token de cancelación que se utiliza para cancelar la operación de forma asincrónica.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos ConsultarUsuarioIdResponse.</returns>
    /// <exception cref="ArgumentNullException">Se lanza si el objeto ConsultarUsuarioIdQuery es nulo.</exception>
    /// <remarks>
    /// Este método llama al método HandleAsync para manejar la consulta y devuelve los resultados como una tarea asincrónica. Si el objeto ConsultarUsuarioIdQuery es nulo, se lanza una excepción ArgumentNullException.
    /// </remarks>
    public Task<List<ConsultarUsuarioIdResponse>> Handle(ConsultarUsuarioIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("ConsultarUsuarioIdQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                return HandleAsync(request);
            }
        }
        catch (Exception)
        {
            _logger.LogWarning("ConsultarUsuariosQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }
    /// <summary>
    /// Maneja una consulta de usuarios y devuelve una lista de objetos ConsultarUsuarioIdResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarUsuarioIdQuery que contiene la información necesaria para realizar la consulta.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos ConsultarUsuariosResponse.</returns>
    /// <remarks>
    /// Este método busca todos los usuarios en la base de datos y devuelve los campos "id_usuario", "nombre", "usuario", "correo", "Discriminator" y "estado" como una lista de objetos ConsultarUsuariosResponse en una tarea asincrónica.
    /// </remarks>
    private async Task<List<ConsultarUsuarioIdResponse>> HandleAsync(ConsultarUsuarioIdQuery request)
    {

        try
        {
            _logger.LogInformation("ConsultarUsuarioIdQueryHandler.HandleAsync");

            var result = _dbContext.Usuario
                .OfType<ConsumidorEntity>()
                .Where(u => u.Id == request._request.id_usuario)
                .Select(c => new ConsultarUsuarioIdResponse()
                {
                    id_usuario = c.Id,
                    nombre = c.nombre + " " + c.apellido,
                    usuario = c.usuario,
                    correo = c.correo,
                    Discriminator = EF.Property<string>(c, "Discriminator"),
                    estado = c.estado,
                    ci = c.ci,
                    rif = null,
                })
                .Union(_dbContext.Usuario
                    .OfType<PrestadorEntity>()
                    .Where(u => u.Id == request._request.id_usuario)
                    .Select(c => new ConsultarUsuarioIdResponse()
                    {
                        id_usuario = c.Id,
                        nombre = c.nombre + " " + c.apellido,
                        usuario = c.usuario,
                        correo = c.correo,
                        Discriminator = EF.Property<string>(c, "Discriminator"),
                        estado = c.estado,
                        rif = c.rif,
                        ci = null,
                    })
                );

            return result.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarUsuarioIdQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }



    }
}

