using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Handlers.Queries;
using UCABPagaloTodoMS.Application.Mappers;
using UCABPagaloTodoMS.Core.Database;
using FluentValidation.Results;
using FluentValidation;
using System.Text;

namespace UCABPagaloTodoMS.Application.Handlers.Commands;
public class AgregarRegistrarConsumidorCommandHandler : IRequestHandler<AgregarRegistrarConsumidorCommand, Guid>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<AgregarRegistrarConsumidorCommandHandler> _logger;

    public AgregarRegistrarConsumidorCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<AgregarRegistrarConsumidorCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> Handle(AgregarRegistrarConsumidorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._request == null)
            {
                _logger.LogWarning("AgregarRegistrarConsumidorCommandHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new AgregarConsumidorValidator();
                ValidationResult result = validator.Validate(request);
                //Llamo a validator del Agregar Consumidor y verifico 
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
            _logger.LogWarning("AgregarRegistrarConsumidorCommandHandler.Handle: ValidationException ");
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<Guid> HandleAsync(AgregarRegistrarConsumidorCommand request)
    {
        var transaccion = _dbContext.BeginTransaction();
        try
        {
            _logger.LogInformation("AgregarRegistrarConsumidorCommandHandler.HandleAsync {Request}", request);

            var result = _dbContext.Consumidor.Count(c => c.usuario == request._request.usuario || c.ci == request._request.ci);


            if (result > 0)
            {
                throw new InvalidOperationException("Registro fallido: el usuario ya existe");
            }

            var entity = RegistrarConsumidorMapper.MapRequestEntity(request._request);
            _dbContext.Consumidor.Add(entity);
            var id = entity.Id;
            await _dbContext.SaveEfContextChanges("APP");
            transaccion.Commit();
            _logger.LogInformation("AgregarRegistrarConsumidorCommandHandler.HandleAsync {Response}", id);
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error AgregarRegistrarConsumidorCommandHandler.HandleAsync. {Mensaje}", ex.Message);
            transaccion.Rollback();
            throw;
        }
    }


}
