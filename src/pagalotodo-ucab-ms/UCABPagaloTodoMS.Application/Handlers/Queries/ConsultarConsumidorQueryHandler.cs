using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Application.Validators.UsuarioValidator;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;
using System.Text;
using UCABPagaloTodoMS.Application.Excepciones;


namespace UCABPagaloTodoMS.Application.Handlers.Queries;
public class ConsultarConsumidorQueryHandler : IRequestHandler<ConsultarConsumidorQuery, List<ConsultarConsumidorResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarConsumidorQueryHandler> _logger;
    public ConsultarConsumidorQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarConsumidorQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    /// <summary>
    /// Maneja una consulta de consumidor y devuelve un objeto de ConsultarConsumidorResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarConsumidorQuery que contiene la informaci�n necesaria para realizar la consulta.</param>
    /// <param name="cancellationToken">El token de cancelaci�n que se utiliza para cancelar la operaci�n de forma asincr�nica.</param>
    /// <returns>Una tarea asincr�nica que representa la operaci�n y una lista de objetos ConsultarConsumidorResponse.</returns>
    /// <exception cref="ArgumentNullException">Se lanza si el objeto ConsultarConsumidorQuery es nulo.</exception>
    /// <remarks>
    /// Este m�todo valida el objeto ConsultarConsumidorQuery utilizando un validador de CiValidator. Si la validaci�n es exitosa, llama al m�todo HandleAsync para manejar la consulta y devuelve los resultados como una tarea asincr�nica. Si la validaci�n falla, se lanza una excepci�n ArgumentNullException y se muestran los errores de validaci�n en el registro.
    /// </remarks>
    public Task<List<ConsultarConsumidorResponse>> Handle(ConsultarConsumidorQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("ConsultarConsumidorQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new CiValidator(); //Variable del validator

                //Llamo a validator  y verifico 
                ValidationResult result = validator.Validate(request);
                if (result.IsValid) //Si el request es valido llamo a HandleAsync
                {
                    return HandleAsync(request);
                }
                else  //Si no es valido, muestra los errores con el campo y el mensaje del campo en el validator  
                {
                    var errorMessages = new StringBuilder("Registro fallido: ");

                    foreach (var error in result.Errors)
                    {
                        errorMessages.AppendLine($"{error.ErrorMessage}");
                    }
                    throw new ValidationException($"Error en campos del {nameof(request)} campos invalidos {errorMessages.ToString()}");
                }
            }
        }
        catch (ValidationException)
        {
            _logger.LogWarning("ConsultarConsumidorQueryHandler.Handle: ValidationException ");
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }
    /// <summary>
    /// Este m�todo maneja una consulta de consumidores y devuelve una lista de objetos ConsultarConsumidorResponse.
    /// </summary>
    /// <param name="request">Objeto ConsultarConsumidorQuery que contiene la ci de la consulta.</param>
    /// <returns>Una tarea asincr�nica que representa la operaci�n y una lista de objetos ConsultarConsumidorResponse.</returns>
    /// <exception cref="InvalidOperationException">Se lanza si el usuario proporcionado no existe en la base de datos.</exception>
    private async Task<List<ConsultarConsumidorResponse>> HandleAsync(ConsultarConsumidorQuery request)
    {
        try
        {
            _logger.LogInformation("ConsultarConsumidorQueryHandler.HandleAsync");

            var result = _dbContext.Consumidor.Count(c => c.ci == request._request.ci);

            if (result == 0) //Verifico que el Consumidor exista 
            {
                throw new InvalidOperationException("No se encontro al Consumidor registrado");
            }

            var consumidor = _dbContext.Consumidor.Where(c => c.ci == request._request.ci).Select(c => new ConsultarConsumidorResponse() //Traemos al consumidor de la bd
            {
                Id = c.Id,
            });

            return await consumidor.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarConsumidorQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }

}