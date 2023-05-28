using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Application.Validators;
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
    /// Este método verifica .
    /// </summary>
    /// <param name="a">El primer número entero.</param>
    /// <param name="b">El segundo número entero.</param>
    /// <returns>La suma de los dos números enteros.</returns>
    public Task<List<RecuperarClaveResponse>> Handle(ConsultarRecuperarClaveQuery request, CancellationToken cancellationToken)
    {
        var validator = new ConsultarRecuperarClaveValidator(); //Variable del validator
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("ConsultarRecuperarClaveQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                //Llamo a validator del RecuperarClave y verifico 
                ValidationResult result = validator.Validate(request);

                if (result.IsValid) //Si el request es valido llamo a HandleAsync
                {
                    return HandleAsync(request);
                }
                else  //Si no es valido muestra los errores con el campo y el mensaje del campo en el validator  
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

    private async Task<List<RecuperarClaveResponse>> HandleAsync(ConsultarRecuperarClaveQuery request) 
    {
        try
        {
            _logger.LogInformation("ConsultarPreguntasDeSeguridadQueryHandler.HandleAsync");

            var result = _dbContext.Usuario.Count(c => c.usuario == request._request.usuario);

            if (result == 0) //Verifico que el usuario exista
            {
                throw new InvalidOperationException("No se encontro al usuario registrado");
            }

            //Pregunto si tanto el usuario como las respuestas de seguridad son las correctas
            var usuario = _dbContext.Usuario.Where(c => c.usuario == request._request.usuario 
                                                     && c.respuesta_de_seguridad == request._request.respuesta_de_seguridad 
                                                     && c.respuesta_de_seguridad2 == request._request.respuesta_de_seguridad2)
                                            .Select(c => new RecuperarClaveResponse()
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
