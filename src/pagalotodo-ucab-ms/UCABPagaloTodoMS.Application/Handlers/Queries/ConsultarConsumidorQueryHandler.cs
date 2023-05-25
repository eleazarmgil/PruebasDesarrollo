using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;
public class ConsultarConsumidorQueryHandler : IRequestHandler<ConsultarConsumidorQuery, List<ConsultarConsumidorResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarConsumidorQueryHandler> _logger;
    public ConsultarConsumidorQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarConsumidorQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public Task<List<ConsultarConsumidorResponse>> Handle(ConsultarConsumidorQuery request, CancellationToken cancellationToken)
    {//Todo lo que puede fallar
        try
        {
            if (request is null)
            {
                _logger.LogWarning("ConsultarConsumidorQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                return HandleAsync(request);
            }
        }
        catch (Exception)
        {
            _logger.LogWarning("ConsultarConsumidorQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }

    private async Task<List<ConsultarConsumidorResponse>> HandleAsync(ConsultarConsumidorQuery request)
    {//Todo lo bueno para chocar contra la bd
        try
        {
            _logger.LogInformation("ConsultarConsumidorQueryHandler.HandleAsync");

            var result = _dbContext.Consumidor.Where(c=>c.ci == request._request.ci).Select(c => new ConsultarConsumidorResponse()
            {
                Id = c.Id,
            });

            return await result.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarConsumidorQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }

}