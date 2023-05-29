using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;

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
                return HandleAsync(request);
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

            var result = _dbContext.Prestador.Where(c => c.rif == request._request.rif).Select(c => new ConsultarPrestadorResponse()
            {
                Id = c.Id,
            });

            return await result.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarPrestadorQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }

}