using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Core.Entities;
using FluentValidation.Results;
using UCABPagaloTodoMS.Application.Excepciones;
using System.Text;

namespace UCABPagaloTodoMS.Application.Handlers.Commands;

public class ActualizarConsumidorCommandHandler : IRequestHandler<ActualizarConsumidorCommand, Guid>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ActualizarConsumidorCommandHandler> _logger;

    public ActualizarConsumidorCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ActualizarConsumidorCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// Maneja la solicitud de actualizar un consumidor.
    /// </summary>
    /// <param name="request">La solicitud de actualizar un consumidor.</param>
    /// <param name="cancellationToken">El token de cancelación.</param>
    /// <returns>El ID del consumidor actualizado.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando la solicitud es nula.</exception>
    public async Task<Guid> Handle(ActualizarConsumidorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._request == null)
            {
                _logger.LogWarning("ActualizarConsumidorCommandHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new ActualizarConsumidorValidator();
                ValidationResult result = validator.Validate(request);
                //Llamo a validator del LoginUsuario y verifico 
                if (result.IsValid)
                {
                    return await HandleAsync(request);

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
            _logger.LogWarning("ActualizarConsumidorCommandHandler.Handle: ValidationException ");
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Actualiza un consumidor en la base de datos.
    /// </summary>
    /// <param name="request">La solicitud de actualizar el consumidor.</param>
    /// <returns>El ID del consumidor actualizado.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando la solicitud es nula.</exception>
    private async Task<Guid> HandleAsync(ActualizarConsumidorCommand request)
    {
        var transaccion = _dbContext.BeginTransaction();
        try
        {
            _logger.LogInformation("ActualizarConsumidorCommandHandler.HandleAsync {Request}", request);

            var usuario_bd = _dbContext.Consumidor.FirstOrDefault(c => c.Id == request._request.Id);
            if (usuario_bd == null) //Pregunto si es nulo
            {
                return await HandleAsync(request);
            }

            // Actualiza las propiedades del usuario
            foreach (var propiedad in typeof(ActualizarConsumidorCommand).GetProperties())
            {
                var valor = propiedad.GetValue(request._request);
                if (valor != null)
                {
                    typeof(ConsumidorEntity).GetProperty(propiedad.Name)?.SetValue(usuario_bd, valor);
                }
            }

            _dbContext.Usuario.Update(usuario_bd);
            await _dbContext.SaveEfContextChanges("APP");
            transaccion.Commit();
            _logger.LogInformation("AdministradorActualizarConsumidorCommandHandler.HandleAsync {Response}", usuario_bd.Id);

            return usuario_bd.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en AdministradorActualizarConsumidorCommandHandler.HandleAsync. {Mensaje}", ex.Message);
            transaccion.Rollback();
            throw;
        }
    }
}
