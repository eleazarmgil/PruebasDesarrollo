using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using UCABPagaloTodoMS.Application.Validators.UsuarioValidator;
using System.Text;
using FluentValidation.Results;


namespace UCABPagaloTodoMS.Application.Handlers.Queries;
public class ConsultarDetalleDeOpcionDePagoQueryHandler : IRequestHandler<ConsultarDetalleDeOpcionDePagoQuery, List<ConsultarDetalleDeOpcionDePagoResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarDetalleDeOpcionDePagoQueryHandler> _logger;

    public ConsultarDetalleDeOpcionDePagoQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarDetalleDeOpcionDePagoQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public Task<List<ConsultarDetalleDeOpcionDePagoResponse>> Handle(ConsultarDetalleDeOpcionDePagoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
            {
                _logger.LogWarning("ConsultarDetalleDeOpcionDePagoQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new ConsultarDetalleDeOpcionValidator();
                ValidationResult result = validator.Validate(request);
                //Llamo a validator del Agregar Consumidor y verifico 

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
            _logger.LogWarning("ConsultarDetalleDeOpcionDePagoQueryHandler.Handle: ValidationException ");
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<List<ConsultarDetalleDeOpcionDePagoResponse>> HandleAsync(ConsultarDetalleDeOpcionDePagoQuery request)
    {
        try
        {
            _logger.LogInformation("ConsultarDetalleDeOpcionDePagoQueryHandler.HandleAsync");

            var result = _dbContext.DetalleDeOpcion.Where(c => c.OpcionDePagoEntityId == request._request.opciondepago_id).Select(c => new ConsultarDetalleDeOpcionDePagoResponse()
            {
                nombre = c.nombre,
                tipo_dato = c.tipo_dato,
                formato = c.formato,
                cant_caracteres = c.cant_caracteres,
            });

            return await result.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarDetalleDeOpcionDePagoQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }
}