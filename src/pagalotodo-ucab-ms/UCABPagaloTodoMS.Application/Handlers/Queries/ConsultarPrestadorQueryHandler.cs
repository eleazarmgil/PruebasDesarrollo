using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Application.Validators.UsuarioValidator;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;
using FluentValidation;
using System.Text;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;
public class ConsultarPrestadorQueryHandler : IRequestHandler<ConsultarPrestadorQuery, List<ConsultarPrestadorResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarPrestadorQueryHandler> _logger;
    public ConsultarPrestadorQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarPrestadorQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    /// <summary>
    /// Maneja una consulta de prestador y devuelve una lista de objetos ConsultarPrestadorResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarPrestadorQuery que contiene la información necesaria para realizar la consulta.</param>
    /// <param name="cancellationToken">El token de cancelación que se utiliza para cancelar la operación de forma asincrónica.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos ConsultarPrestadorResponse.</returns>
    /// <exception cref="ArgumentNullException">Se lanza si el objeto ConsultarPrestadorQuery es nulo.</exception>
    /// <remarks>
    /// Este método valida el objeto ConsultarPrestadorQuery utilizando un validador de RifValidator. Si la validación es exitosa, llama al método HandleAsync para manejar la consulta y devuelve los resultados como una tarea asincrónica. Si la validación falla, se lanza una excepción ArgumentNullException y se muestran los errores de validación en el registro.
    /// </remarks>
    public Task<List<ConsultarPrestadorResponse>> Handle(ConsultarPrestadorQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("ConsultarPrestadorQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new RifValidator(); //Variable del validator

                //Llamo a validator del RifValidator y verifico 
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
            _logger.LogWarning("ConsultarPrestadorQueryHandler.Handle: ValidationException ");
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }
    /// <summary>
    /// Maneja una consulta de prestador y devuelve una lista de objetos ConsultarPrestadorResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarPrestadorQuery que contiene la información necesaria para realizar la consulta.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos ConsultarPrestadorResponse.</returns>
    /// <exception cref="InvalidOperationException">Se lanza si el Prestador no está registrado en la base de datos.</exception>
    /// <remarks>
    /// Este método busca el Prestador en la base de datos utilizando el RIF proporcionado en el objeto ConsultarPrestadorQuery. Si el Prestador no está registrado, se lanza una excepción InvalidOperationException. Si el Prestador está registrado, se crea un objeto ConsultarPrestadorResponse con el Id del Prestador y se devuelve como una lista de objetos ConsultarPrestadorResponse en una tarea asincrónica.
    /// </remarks>
    private async Task<List<ConsultarPrestadorResponse>> HandleAsync(ConsultarPrestadorQuery request)
    {
        try
        {
            _logger.LogInformation("ConsultarPrestadorQueryHandler.HandleAsync");
            var result = _dbContext.Prestador.Count(c => c.rif == request._request.rif);

            if (result == 0) //Verifico que el Prestador exista 
            {
                throw new InvalidOperationException("No se encontro al Prestador registrado");
            }

            var prestador = _dbContext.Prestador.Where(c => c.rif == request._request.rif).Select(c => new ConsultarPrestadorResponse() //Traemos al Prestador de la bd
            {
                Id = c.Id,
            });

            return await prestador.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarPrestadorQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }

}