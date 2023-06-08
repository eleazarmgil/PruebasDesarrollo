using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Mappers;
using UCABPagaloTodoMS.Application.Validators;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Application.Excepciones;



namespace UCABPagaloTodoMS.Application.Handlers.Commands;

public class AgregarOpcionPagoCommandHandler : IRequestHandler<AgregarOpcionPagoCommand, Guid>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<AgregarOpcionPagoCommandHandler> _logger;

    public AgregarOpcionPagoCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<AgregarOpcionPagoCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> Handle(AgregarOpcionPagoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._request == null)
            {
                _logger.LogWarning("AgregarOpcionPagoCommandHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new AgregarOpcionPagoValidator();
                ValidationResult result = validator.Validate(request);
                //Llamo a validator del Agregar opcion pago y verifico 
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

            _logger.LogWarning("AgregarOpcionPagoCommandHandler.Handle: ValidationException ");

            throw;
        }

        catch (ArgumentNullException)
        {

            _logger.LogWarning("AgregarOpcionPagoCommandHandler.Handle: ArgumentNullException");

            throw;
        }


    }

    private async Task<Guid> HandleAsync(AgregarOpcionPagoCommand request)
    {
        var transaccion = _dbContext.BeginTransaction();
        try
        {
            _logger.LogInformation("AgregarOpcionPagoCommandHandler.HandleAsync {Request}", request);

            
            var result = _dbContext.Servicio.Count(c => c.Id == request._request.ServicioEntityId); 

            if (result == 0)
            {
                throw new InvalidOperationException("Registro fallido: No existe este servicio");
            }

            var entity = AgregarOpcionPagoMapper.MapRequestEntity(request._request);

            _dbContext.OpcionDePago.Add(entity);
            var id = entity.Id;
            await _dbContext.SaveEfContextChanges("APP");
            transaccion.Commit();
            _logger.LogInformation("AgregarOpcionPagoCommandHandler.HandleAsync {Response}", id);
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error AgregarOpcionPagoCommandHandler.HandleAsync. {Mensaje}", ex.Message);
            transaccion.Rollback();
            throw;
        }
    }


}
