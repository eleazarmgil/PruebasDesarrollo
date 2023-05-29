using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Application.Validators.UsuarioValidator;
using Microsoft.EntityFrameworkCore;
using RestSharp.Validation;
using FluentValidation.Results;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;
public class ConsultarLoginUsuarioQueryHandler : IRequestHandler<ConsultarLoginUsuarioQuery, List<LoginUsuarioResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarLoginUsuarioQueryHandler> _logger;
    public ConsultarLoginUsuarioQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarLoginUsuarioQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public Task<List<LoginUsuarioResponse>> Handle(ConsultarLoginUsuarioQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("LoginUsuarioQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new UsuarioPasswordValidator();
                ValidationResult result = validator.Validate(request);
                //Llamo a validator del LoginUsuario y verifico 
                if (result.IsValid) 
                {
                    return HandleAsync(request);
                }
                else
                {
                    foreach (var error in result.Errors) //Muestra los errores
                    {
                        _logger.LogWarning($"Error en el campo {error.PropertyName} {error.ErrorMessage}");
                    }
                    throw new ArgumentNullException(nameof(request));
                }
            }
        }
        catch (Exception)
        {
            _logger.LogWarning("LoginUsuarioQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }

    private async Task<List<LoginUsuarioResponse>> HandleAsync(ConsultarLoginUsuarioQuery request)
    {
        try
        {
            _logger.LogInformation("ConsultarLoginUsuarioQueryHandler.HandleAsync");

            var result = _dbContext.Usuario.Where(c=>c.usuario == request._request.usuario).Select(c => new LoginUsuarioResponse()
            {
                Id = c.Id,
            });

            return await result.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error LoginUsuarioQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }

}
