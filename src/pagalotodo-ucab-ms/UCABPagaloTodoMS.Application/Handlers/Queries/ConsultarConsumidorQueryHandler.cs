/*using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;

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
    {//Todo lo que puede fallar
        try
        {
            if (request is null)
            {
                _logger.LogWarning("LoginUsuarioQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                return HandleAsync(request);
            }
        }
        catch (Exception)
        {
            _logger.LogWarning("LoginUsuarioQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }

    private async Task<List<LoginUsuarioResponse>> HandleAsync(ConsultarLoginUsuarioQuery request)
    {//Todo lo bueno para chocar contra la bd
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
*/