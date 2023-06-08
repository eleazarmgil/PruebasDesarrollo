using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Core.Entities;
using FluentValidation.Results;
using UCABPagaloTodoMS.Application.Excepciones;
using System.Text;



namespace UCABPagaloTodoMS.Application.Handlers.Commands;

public class AdministradorActualizarConsumidorCommandHandler : IRequestHandler<AdministradorActualizarConsumidorCommand, Guid>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<AdministradorActualizarConsumidorCommandHandler> _logger;

    public AdministradorActualizarConsumidorCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<AdministradorActualizarConsumidorCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> Handle(AdministradorActualizarConsumidorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._request == null)
            {
                _logger.LogWarning("AdministradorActualizarConsumidorCommandHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new AdministradorActualizarConsumidorValidator();
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
            _logger.LogWarning("RegistrarAgregarServicioQueryHandler.Handle: ValidationException ");
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<Guid> HandleAsync(AdministradorActualizarConsumidorCommand request)
    {
        var transaccion = _dbContext.BeginTransaction();
        try
        {
            _logger.LogInformation("AdministradorActualizarConsumidorCommandHandler.HandleAsync {Request}", request);

            var usuario_bd = _dbContext.Consumidor.FirstOrDefault(c => c.Id == request._request.Id);
            if (usuario_bd == null) //Pregunto si es nulo
            {
                return await HandleAsync(request);
            }

            // Actualiza las propiedades del usuario
            foreach (var propiedad in typeof(AdministradorActualizarConsumidorRequest).GetProperties())
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

