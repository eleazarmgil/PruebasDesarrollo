using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;
using UCABPagaloTodoMS.Application.Validators.UsuarioValidator;
using FluentValidation.Results;
using FluentValidation;
using System.Text;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;

public class ConsultarServicioEmpresaQueryHandler : IRequestHandler<ConsultarServicioEmpresaQuery, List<ConsultarServicioEmpresaResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarServicioEmpresaQueryHandler> _logger;
    public ConsultarServicioEmpresaQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarServicioEmpresaQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public Task<List<ConsultarServicioEmpresaResponse>> Handle(ConsultarServicioEmpresaQuery request, CancellationToken cancellationToken)
    {//Todo lo que puede fallar
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("ConsultarServicioEmpresaQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new ConsultarServicioEmpresaValidator(); //Variable del validator

                //Llamo a validator y verifico 
                ValidationResult result = validator.Validate(request);
                if (result.IsValid) //Si el request es valido llamo a HandleAsync
                {
                    return HandleAsync(request);
                }
                else  //Si no es valido, muestra los errores con el campo y el mensaje del campo en el validator  
                {
                    var errorMessages = new StringBuilder("Registro fallido: ");


                    foreach (var error in result.Errors)
                    {
                        errorMessages.AppendLine($"{error.ErrorMessage}");
                    }
                    throw new ValidationException($"Error en campos del {nameof(request)} campos invalidos {errorMessages.ToString()}");
                }
            }
        }

        catch (ValidationException)
        {
            _logger.LogWarning("ConsultarServicioEmpresaQueryHandler.Handle: ValidationException ");
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<List<ConsultarServicioEmpresaResponse>> HandleAsync(ConsultarServicioEmpresaQuery request)
    {//Todo lo bueno para chocar contra la bd
        try
        {
            _logger.LogInformation("ConsultarServicioEmpresaQueryHandler.HandleAsync");

            
            var prestador = await _dbContext.Prestador.Where(p => p.Id == request._request.id_prestador)
                .Include(p => p.servicios)
                .ToListAsync();

           
            var result = prestador.SelectMany(p => p.servicios
                .Select(s => new ConsultarServicioEmpresaResponse
                {
                    nombre_empresa = p.nombre_empresa,
                    nombre_prestador = p.usuario,
                    id_servicio = s.Id,
                    nombre = s.nombre,
                    descripcion = s.descripcion,
                    monto = s.monto,
                    id_prestador = p.Id
                }))
                .ToList();

            return result;

         
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error LoginUsuarioQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }

}

