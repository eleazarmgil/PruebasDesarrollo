using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;
using UCABPagaloTodoMS.Application.Excepciones;
using System.Text;
using FluentValidation.Results;
using UCABPagaloTodoMS.Application.Validators.UsuarioValidator;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;

public class ConsultarOpcionDePagoPorIdQueryHandler : IRequestHandler<ConsultarOpcionDePagoPorIdQuery, List<ConsultarOpcionDePagoPorIdResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarOpcionDePagoPorIdQueryHandler> _logger;
    public ConsultarOpcionDePagoPorIdQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarOpcionDePagoPorIdQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public Task<List<ConsultarOpcionDePagoPorIdResponse>> Handle(ConsultarOpcionDePagoPorIdQuery request, CancellationToken cancellationToken)
    {//Todo lo que puede fallar
        try
        {
            if (request is null)
            {
                _logger.LogWarning("ConsultarOpcionDePagoPorIdQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new ConsultarOpcionDePagoPorIdValidator();
                ValidationResult result = validator.Validate(request);
                //Llamo a validator y verifico 

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
            _logger.LogWarning("ConsultarOpcionDePagoPorIdQueryHandler.Handle: ValidationException ");
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<List<ConsultarOpcionDePagoPorIdResponse>> HandleAsync(ConsultarOpcionDePagoPorIdQuery request)
    {
        try
        {
            _logger.LogInformation("ConsultarOpcionDePagoPorIdQueryHandler.HandleAsync");

            var result = await _dbContext.OpcionDePago
                .Include(p => p.detalleDeOpcion)
                .Where(p => p.Id == request._request.opciondepago_id)
                .Select(c => new ConsultarOpcionDePagoPorIdResponse()
                {
                    Id = c.Id,
                    nombre = c.nombre,
                    estatus = c.estatus,
                    detalledeopciondepago = c.detalleDeOpcion.Select(d => new DetalleDeOpcionDePagoResponse()
                    {
                        nombre = d.nombre,
                        formato = d.formato
                    }).ToList()
                })
                .ToListAsync();

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarOpcionDePagoPorIdQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }

    }
}

