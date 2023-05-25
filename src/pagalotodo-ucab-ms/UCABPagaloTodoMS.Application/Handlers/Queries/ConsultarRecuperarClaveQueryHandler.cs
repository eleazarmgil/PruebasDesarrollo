using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;
public class ConsultarRecuperarClaveQueryHandler : IRequestHandler<ConsultarRecuperarClaveQuery, List<RecuperarClaveResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarRecuperarClaveQueryHandler> _logger;

    public ConsultarRecuperarClaveQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarRecuperarClaveQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public Task<List<RecuperarClaveResponse>> Handle(ConsultarRecuperarClaveQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
            {
                _logger.LogWarning("ConsultarRecuperarClaveQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                return HandleAsync(request);
            }
        }
        catch (Exception)
        {
            _logger.LogWarning("ConsultarRecuperarClaveQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }

    private async Task<List<RecuperarClaveResponse>> HandleAsync(ConsultarRecuperarClaveQuery request) //Cambiarrrrrrrrrr
    {//Todo lo bueno para chocar contra la bd
        try
        {
            _logger.LogInformation("ConsultarPreguntasDeSeguridadQueryHandler.HandleAsync");

            var result = _dbContext.Usuario.Where(c => c.usuario == request._request.usuario).Select(c => new RecuperarClaveResponse()
            {
                Id = c.Id,
                password = c.password
            });

            return await result.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarPreguntasDeSeguridadQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }


}
