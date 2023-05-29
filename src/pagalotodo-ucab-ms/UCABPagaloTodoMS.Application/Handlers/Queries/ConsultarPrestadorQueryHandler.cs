using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Application.Validators.UsuarioValidator;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;
using FluentValidation;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;
public class ConsultarPrestadorQueryHandler : IRequestHandler<ConsultarPrestadorQuery, List<ConsultarPrestadorResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarPrestadorQueryHandler> _logger;
    public ConsultarPrestadorQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarPrestadorQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public Task<List<ConsultarPrestadorResponse>> Handle(ConsultarPrestadorQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("ConsultarPrestadorQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new RifValidator(); //Variable del validator

                //Llamo a validator del RifValidator y verifico 
                ValidationResult result = validator.Validate(request);
                if (result.IsValid) //Si el request es valido llamo a HandleAsync
                {
                    return HandleAsync(request);
                }
                else  //Si no es valido, muestra los errores con el campo y el mensaje del campo en el validator  
                {
                    foreach (var error in result.Errors)
                    {
                        _logger.LogWarning($"Error en el campo {error.PropertyName} {error.ErrorMessage}");
                    }
                    throw new ArgumentNullException(nameof(request));
                }
            }
        }
        catch (Exception)
        {
            _logger.LogWarning("ConsultarPrestadorQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }

    private async Task<List<ConsultarPrestadorResponse>> HandleAsync(ConsultarPrestadorQuery request)
    {
        try
        {
            _logger.LogInformation("ConsultarPrestadorQueryHandler.HandleAsync");
            var result = _dbContext.Usuario.Count(c => c.usuario == request._request.ci);

            if (result == 0) //Verifico que el Consumidor exista 
            {
                throw new InvalidOperationException("No se encontro al usuario registrado");
            }

            var usuario = _dbContext.Prestador.Where(c => c.rif == request._request.rif).Select(c => new ConsultarPrestadorResponse()
            {
                Id = c.Id,
            });

            return await usuario.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarPrestadorQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }

}