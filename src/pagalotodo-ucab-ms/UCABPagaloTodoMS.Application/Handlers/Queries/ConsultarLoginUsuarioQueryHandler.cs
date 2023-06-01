using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Application.Excepciones;
using UCABPagaloTodoMS.Application.Validators.UsuarioValidator;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;
using FluentValidation;
using Microsoft.Azure.Amqp.Framing;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;
public class ConsultarLoginUsuarioQueryHandler : IRequestHandler<ConsultarLoginUsuarioQuery, List<LoginUsuarioResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarLoginUsuarioQueryHandler> _logger;
    public ConsultarLoginUsuarioQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarLoginUsuarioQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// Maneja una consulta de login de usuario y devuelve una lista de objetos LoginUsuarioResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarLoginUsuarioQuery que contiene la información necesaria para realizar la consulta.</param>
    /// <param name="cancellationToken">El token de cancelación que se utiliza para cancelar la operación de forma asincrónica.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos LoginUsuarioResponse.</returns>
    /// <exception cref="ArgumentNullException">Se lanza si el objeto ConsultarLoginUsuarioQuery es nulo.</exception>
    /// <exception cref="ValidationException">Se lanza si el objeto ConsultarLoginUsuarioQuery es nulo.</exception>
    /// <remarks>
    /// Este método valida el objeto ConsultarLoginUsuarioQuery utilizando un validador de UsuarioPasswordValidator. Si la validación es exitosa, llama al método HandleAsync para manejar la consulta y devuelve los resultados como una tarea asincrónica. Si la validación falla, se lanza una excepción ArgumentNullException y se muestran los errores de validación en el registro.
    /// </remarks>
    public Task<List<LoginUsuarioResponse>> Handle(ConsultarLoginUsuarioQuery request, CancellationToken cancellationToken)
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
                var validator = new UsuarioPasswordValidator(); //Variable del validator
                //Llamo a validator del CiValidator y verifico 
                if (validator.Validate(request).IsValid) //Si el request es valido llamo a HandleAsync
                {
                    return HandleAsync(request);
                }
                else  //Si no es valido, muestra los errores con el campo y el mensaje del campo en el validator  
                {
                    throw new ValidationException($"Error en campos del {nameof(request)} campos invalidos {validator.Validate(request).Errors.Count}");
                }
            }
        }
        catch (ValidationException)
        {
            _logger.LogWarning("ConsultarConsumidorQueryHandler.Handle: ");
            throw;
        }
        catch (ArgumentNullException)
        {
            _logger.LogWarning("ConsultarConsumidorQueryHandler.Handle: ArgumentNullException");
            throw;
        }

    }
    /// <summary>
    /// Maneja una consulta de login de usuario y devuelve una lista de objetos LoginUsuarioResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarLoginUsuarioQuery que contiene la información necesaria para realizar la consulta.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos LoginUsuarioResponse.</returns>
    /// <exception cref="InvalidOperationException">Se lanza si el usuario no existe en la base de datos o si la contraseña no es correcta.</exception>
    /// <remarks>
    /// Este método busca al usuario en la base de datos utilizando el nombre de usuario y la contraseña proporcionados en el objeto ConsultarLoginUsuarioQuery. Si el usuario no está registrado o si la contraseña no es correcta, se lanza una excepción InvalidOperationException. Si el usuario está registrado y la contraseña es correcta, se crea un objeto LoginUsuarioResponse con el Id del usuario y se devuelve como una lista de objetos LoginUsuarioResponse en una tarea asincrónica.
    /// </remarks>
    private async Task<List<LoginUsuarioResponse>> HandleAsync(ConsultarLoginUsuarioQuery request)
    {
        try
        {
            _logger.LogInformation("ConsultarLoginUsuarioQueryHandler.HandleAsync");
            var result = _dbContext.Usuario.Count(c => c.usuario == request._request.usuario
                                                    && c.password == request._request.password);

            if (result == 0) //Verifico que el Usuario exista y sea su password la correcta
            {
                throw new InvalidOperationException("No se encontro al usuario registrado");
            }

            var usuario = _dbContext.Usuario.Where(c=>c.usuario == request._request.usuario).Select(c => new LoginUsuarioResponse() //Traemos al usuario de la bd
            {
                Id = c.Id,
            });

            return await usuario.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error LoginUsuarioQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }

}
