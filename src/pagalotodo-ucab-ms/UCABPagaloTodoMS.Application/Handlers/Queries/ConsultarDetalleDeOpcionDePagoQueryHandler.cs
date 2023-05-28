using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;

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
                _logger.LogWarning("ConsultarValoresQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                return HandleAsync(request);
            }
        }
        catch (Exception)
        {
            _logger.LogWarning("ConsultarValoresQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }

    private async Task<List<ConsultarDetalleDeOpcionDePagoResponse>> HandleAsync(ConsultarDetalleDeOpcionDePagoQuery request)
    {
        try
        {
            _logger.LogInformation("ConsultarValoresQueryHandler.HandleAsync");

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
            _logger.LogError(ex, "Error ConsultarValoresQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }
}