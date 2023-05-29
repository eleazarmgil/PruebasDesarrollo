using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Application.Validators.UsuarioValidator;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;

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

                //Llamo a validator del CiValidator y verifico 
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
            _logger.LogWarning("ConsultarConsumidorQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }
    /// <summary>
    /// Este método maneja una consulta de consumidores y devuelve una lista de objetos ConsultarConsumidorResponse.
    /// </summary>
    /// <param name="request">Objeto ConsultarConsumidorQuery que contiene la ci de la consulta.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos ConsultarConsumidorResponse.</returns>
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

            var consumidor = _dbContext.Consumidor.Where(c=>c.ci == request._request.ci).Select(c => new ConsultarConsumidorResponse() //Traemos al consumidor de la bd
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