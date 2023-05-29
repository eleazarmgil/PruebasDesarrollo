using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Application.Validators.UsuarioValidator;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;
public class ConsultarRecuperarClaveQueryHandler : IRequestHandler<ConsultarRecuperarClaveQuery, List<RecuperarClaveResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarRecuperarClaveQueryHandler> _logger;

    public ConsultarRecuperarClaveQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarRecuperarClaveQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// Manejador para la consulta de recuperación de clave. Verifica que el request de ConsultarRecuperarClaveQuery no sea nulo y lo valida utilizando el validador ConsultarRecuperarClaveValidator. Si el request es válido, llama al método HandleAsync para procesar la consulta. Si el request no es válido, lanza una excepción ArgumentNullException y muestra los errores de validación en el registro de eventos.
    /// </summary>
    /// <param name="request">El objeto ConsultarRecuperarClaveQuery que contiene los datos de la consulta.</param>
    /// <param name="cancellationToken">El token de cancelación para la operación asincrónica.</param>
    /// <returns>Una tarea que representa la operación asincrónica. El resultado de la tarea es una lista de objetos RecuperarClaveResponse que contienen los resultados de la consulta.</returns>
    public Task<List<RecuperarClaveResponse>> Handle(ConsultarRecuperarClaveQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("ConsultarRecuperarClaveQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new ConsultarRecuperarClaveValidator(); //Variable del validator

                //Llamo a validator del RecuperarClave y verifico 
                ValidationResult result = validator.Validate(request);
                if (result.IsValid) //Si el request es valido llamo a HandleAsync
                {
                    return HandleAsync(request);
                }
                else  //Si no es valido, muestra los errores con el campo y el mensaje del campo en el validator  
                { 
                    foreach (var error in result.Errors) 
                    {
                        _logger.LogWarning($"Error en el campo {error.PropertyName} {error.ErrorMessage}");
                    }
                    throw new ArgumentNullException(nameof(request));
                }
            }
        }
        catch (Exception)
        {
            _logger.LogWarning("ConsultarRecuperarClaveQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }

    /// <summary>
    /// Método asincrónico que maneja la consulta de recuperación de clave. Verifica que el usuario exista en la base de datos y que las respuestas de seguridad proporcionadas sean correctas. Si los datos son correctos, devuelve una lista de objetos RecuperarClaveResponse que contienen el Id y el password del usuario. Si los datos no son correctos, lanza una excepción InvalidOperationException y registra un mensaje de error en el log de eventos.
    /// </summary>
    /// <param name="request">El objeto ConsultarRecuperarClaveQuery que contiene los datos de la consulta.</param>
    /// <returns>Una tarea que representa la operación asincrónica. El resultado de la tarea es una lista de objetos RecuperarClaveResponse que contienen el Id y el password del usuario correspondiente.</returns>
    private async Task<List<RecuperarClaveResponse>> HandleAsync(ConsultarRecuperarClaveQuery request) 
    {
        try
        {
            _logger.LogInformation("ConsultarPreguntasDeSeguridadQueryHandler.HandleAsync");

            var result = _dbContext.Usuario.Count(c => c.usuario == request._request.usuario
                                                    && c.respuesta_de_seguridad == request._request.respuesta_de_seguridad
                                                    && c.respuesta_de_seguridad2 == request._request.respuesta_de_seguridad2);

            if (result == 0) //Verifico que el usuario exista y que tenga las respuestas correctas
            {
                throw new InvalidOperationException("No se encontro al usuario registrado");
            }

            //Traemos el usuario y la password de la BD
            var usuario = _dbContext.Usuario.Where(c => c.usuario == request._request.usuario).Select(c => new RecuperarClaveResponse()
            {
                Id = c.Id,
                password = c.password
            });

            return await usuario.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarPreguntasDeSeguridadQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }


}
