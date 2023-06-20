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
    /// <remarks>
    /// Este método valida el objeto ConsultarLoginUsuarioQuery utilizando un validador de UsuarioPasswordValidator. Si la validación es exitosa, llama al método HandleAsync para manejar la consulta y devuelve los resultados como una tarea asincrónica. Si la validación falla, se lanza una excepción ArgumentNullException y se muestran los errores de validación en el registro.
    /// </remarks>
    public Task<List<LoginUsuarioResponse>> Handle(ConsultarLoginUsuarioQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("LoginUsuarioQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new UsuarioPasswordValidator();
                ValidationResult result = validator.Validate(request);
                //Llamo a validator del LoginUsuario y verifico 
                if (result.IsValid) 
                {
                    return HandleAsync(request);
                }
                else
                {
                    var errorMessages = new StringBuilder("Registro fallido: ");

                    foreach (var error in result.Errors) //Muestra los errores
                    {
                        errorMessages.AppendLine($"{error.ErrorMessage}");
                    }
                    throw new ValidationException($"Error en campos del {nameof(request)} campos invalidos {errorMessages.ToString()}");
                }
            }
        }
        catch (ValidationException)
        {
            _logger.LogWarning("LoginUsuarioQueryHandler.Handle.Handle: ValidationException ");
            throw;
        }
        catch (Exception)
        {
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
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //Validacion de que exista
            var result = _dbContext.Usuario.Count(c => c.usuario == request._request.usuario
                                                    && c.password == request._request.password);

            if (result == 0) //Verifico que el Usuario exista y sea su password la correcta
            {
                throw new InvalidOperationException("No se encontro al usuario registrado");
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //Verifico que tipo es
            var tipoConsumidor = _dbContext.Consumidor.Count(c => c.usuario == request._request.usuario
                                                    && c.ci != null
                                                    );
            if (tipoConsumidor == 1) //Verifico si es usuario Consumidor
            {
                var usuarioConsumidor = _dbContext.Usuario.Where(c => c.usuario == request._request.usuario).Select(c => new LoginUsuarioResponse() //Traemos al usuario de la bd
                {
                    Id = c.Id,
                    discriminator = "Consumidor",
                    usuario=c.usuario
                });
                return await usuarioConsumidor.ToListAsync();
            }


            var tipoPrestador = _dbContext.Consumidor.Count(c => c.usuario == request._request.usuario
                                                    && c.ci != null
                                                    );
            if (tipoPrestador == 1) //Verifico si es usuario Prestador
            {
                var usuarioPrestador = _dbContext.Usuario.Where(c => c.usuario == request._request.usuario).Select(c => new LoginUsuarioResponse() //Traemos al usuario de la bd
                {
                    Id = c.Id,
                    discriminator = "Prestador",
                    usuario = c.usuario
                });
                return await usuarioPrestador.ToListAsync();
            }

            var tipoadministrador = _dbContext.Consumidor.Count(c => c.usuario == request._request.usuario); //Es usuarioAdministrador

            var usuarioAdministrador = _dbContext.Usuario.Where(c => c.usuario == request._request.usuario).Select(c => new LoginUsuarioResponse() //Traemos al usuario de la bd
            {
                Id = c.Id,
                discriminator = "Administrador",
                usuario = c.usuario
            });
            return await usuarioAdministrador.ToListAsync();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error LoginUsuarioQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }

}
