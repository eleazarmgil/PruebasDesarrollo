using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Core.Database;
using FluentValidation.Results;
using System.Text;
using UCABPagaloTodoMS.Application.Excepciones;
using UCABPagaloTodoMS.Application.Validators.UsuarioValidator;

namespace UCABPagaloTodoMS.Application.Handlers.Commands;

public class ActualizarOpcionDePagoEstadoCommandHandler : IRequestHandler<ActualizarOpcionDePagoEstadoCommand, Guid>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ActualizarOpcionDePagoEstadoCommandHandler> _logger;

    public ActualizarOpcionDePagoEstadoCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ActualizarOpcionDePagoEstadoCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// Maneja la solicitud de actualizar el estatus de una opcion de pago.
    /// </summary>
    /// <param name="request">La solicitud de actualizar el estatus.</param>
    /// <param name="cancellationToken">El token de cancelación.</param>
    /// <returns>El ID de la opcion de pago que fue actualizado.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando la solicitud es nula.</exception>
    public async Task<Guid> Handle(ActualizarOpcionDePagoEstadoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._request == null)
            {
                _logger.LogWarning("ActualizarOpcionDePagoEstadoCommandHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new ActualizarOpcionDePagoEstado();
                ValidationResult result = validator.Validate(request);
                //Llamo a validator  y verifico 
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
            _logger.LogWarning("ActualizarOpcionDePagoEstadoCommandHandler.Handle: ValidationException ");
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Actualiza el estatus de una opcion de pago  en la base de datos.
    /// </summary>
    /// <param name="request">La solicitud de actualizar el estatus.</param>
    /// <returns>El ID de la opcion de pago a  actualizar.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando la solicitud es nula.</exception>
    private async Task<Guid> HandleAsync(ActualizarOpcionDePagoEstadoCommand request)
    {
        var transaccion = _dbContext.BeginTransaction();
        try
        {
            _logger.LogInformation("ActualizarOpcionDePagoEstadoCommandHandler.Handle.HandleAsync {Request}", request);

            var opciondepago = _dbContext.OpcionDePago.FirstOrDefault(c => c.Id == request._request.opciondepagoid);
            if (opciondepago == null) //Pregunto si es nulo
            {
                return await HandleAsync(request);
            }

            opciondepago.estatus = request._request.estado;

            _dbContext.OpcionDePago.Update(opciondepago);
            await _dbContext.SaveEfContextChanges("APP");
            transaccion.Commit();
            _logger.LogInformation("ActualizarOpcionDePagoEstadoCommandHandler.HandleAsync {Response}", opciondepago.Id);

            return opciondepago.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en ActualizarOpcionDePagoEstadoCommandHandler.HandleAsync. {Mensaje}", ex.Message);
            transaccion.Rollback();
            throw;
        }
    }
}
