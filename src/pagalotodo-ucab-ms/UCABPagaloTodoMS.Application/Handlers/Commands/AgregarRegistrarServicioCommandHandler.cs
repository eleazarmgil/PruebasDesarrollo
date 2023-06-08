using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Mappers;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Application.Excepciones;

namespace UCABPagaloTodoMS.Application.Handlers.Commands;

public class AgregarRegistrarServicioCommandHandler : IRequestHandler<AgregarRegistrarServicioCommand, Guid>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<AgregarRegistrarServicioCommandHandler> _logger;

    public AgregarRegistrarServicioCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<AgregarRegistrarServicioCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> Handle(AgregarRegistrarServicioCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._request == null)
            {
                _logger.LogWarning("AgregarRegistrarServicioCommandHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new AgregarServicioValidator();
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

            _logger.LogWarning("AgregarRegistrarServicioCommandHandler.Handle: ValidationException ");

            throw;
        }
        catch (Exception)
        {
            throw;
        }

    }

        
    private async Task<Guid> HandleAsync(AgregarRegistrarServicioCommand request)
    {
        var transaccion = _dbContext.BeginTransaction();
        try
        {
            _logger.LogInformation("RegistrarAgregarServicoCommandHandler.HandleAsync {Request}", request);
 

            var result = _dbContext.Usuario.Count(c => c.Id == request._request.PrestadorEntityId); // agregar que el id del servicio no exista

            if (result == 0)
            {
                throw new InvalidOperationException("Registro fallido: No existe prestador para este servicio");
            }

            var entity = RegistrarServicioMapper.MapRequestEntity(request._request);
            _dbContext.Servicio.Add(entity);
            var id = entity.Id;
            
            await _dbContext.SaveEfContextChanges("APP");
            transaccion.Commit();
            _logger.LogInformation("RegistrarAgregarServicoCommandHandler.HandleAsync {Response}", id);
            
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error RegistrarAgregarServicoCommandHandler.HandleAsync. {Mensaje}", ex.Message);
            transaccion.Rollback();
            throw;
        }
    }


}
