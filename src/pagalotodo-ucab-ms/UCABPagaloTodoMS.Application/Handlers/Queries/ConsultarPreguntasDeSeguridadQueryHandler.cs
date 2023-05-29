using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Application.Validators.UsuarioValidator;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;
using FluentValidation;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;
public class ConsultarPreguntasDeSeguridadQueryHandler : IRequestHandler<ConsultarPreguntasDeSeguridadQuery, List<PreguntasDeSeguridadResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarPreguntasDeSeguridadQueryHandler> _logger;
    public ConsultarPreguntasDeSeguridadQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarPreguntasDeSeguridadQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// Maneja una consulta de preguntas de seguridad y devuelve una lista de objetos PreguntasDeSeguridadResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarPreguntasDeSeguridadQuery que contiene la información necesaria para realizar la consulta.</param>
    /// <param name="cancellationToken">El token de cancelación que se utiliza para cancelar la operación de forma asincrónica.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos PreguntasDeSeguridadResponse.</returns>
    /// <exception cref="ArgumentNullException">Se lanza si el objeto ConsultarPreguntasDeSeguridadQuery es nulo.</exception>
    /// <remarks>
    /// Este método valida el objeto ConsultarPreguntasDeSeguridadQuery utilizando un validador de UsuarioValidator. Si la validación es exitosa, llama al método HandleAsync para manejar la consulta y devuelve los resultados como una tarea asincrónica. Si la validación falla, se lanza una excepción ArgumentNullException y se muestran los errores de validación en el registro.
    /// </remarks>
    public Task<List<PreguntasDeSeguridadResponse>> Handle(ConsultarPreguntasDeSeguridadQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("ConsultarPreguntasDeSeguridadQueryHandler: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new UsuarioValidator(); //Variable del validator

                //Llamo a validator del UsuarioValidator y verifico 
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
            _logger.LogWarning("ConsultarPreguntasDeSeguridadQueryHandler: ArgumentNullException");
            throw;
        }
    }

    /// <summary>
    /// Maneja una consulta de preguntas de seguridad y devuelve una lista de objetos PreguntasDeSeguridadResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarPreguntasDeSeguridadQuery que contiene la información necesaria para realizar la consulta.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos PreguntasDeSeguridadResponse.</returns>
    /// <exception cref="InvalidOperationException">Se lanza si el usuario no existe en la base de datos.</exception>
    /// <remarks>
    /// Este método busca al usuario en la base de datos utilizando el nombre de usuario proporcionado en el objeto ConsultarPreguntasDeSeguridadQuery. Si el usuario no está registrado, se lanza una excepción InvalidOperationException. Si el usuario está registrado, se crea un objeto PreguntasDeSeguridadResponse con las preguntas de seguridad del usuario y se devuelve como una lista de objetos PreguntasDeSeguridadResponse en una tarea asincrónica.
    /// </remarks>
    private async Task<List<PreguntasDeSeguridadResponse>> HandleAsync(ConsultarPreguntasDeSeguridadQuery request)
    {
        try
        {
            _logger.LogInformation("ConsultarPreguntasDeSeguridadQueryHandler.HandleAsync");
            var result = _dbContext.Usuario.Count(c => c.usuario == request._request.usuario);

            if (result == 0) //Verifico que el Usuario exista 
            {
                throw new InvalidOperationException("No se encontro al usuario registrado");
            }

            var usuario = _dbContext.Usuario.Where(c => c.usuario == request._request.usuario).Select(c => new PreguntasDeSeguridadResponse() //Traemos las preguntas de seguridad de la bd
            {
               pregunta_de_seguridad = c.preguntas_de_seguridad,
               pregunta_de_seguridad2 = c.preguntas_de_seguridad2
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
