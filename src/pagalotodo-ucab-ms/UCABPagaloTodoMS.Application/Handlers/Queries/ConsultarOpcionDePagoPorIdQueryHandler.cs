using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;
using UCABPagaloTodoMS.Core.Entities;

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
                _logger.LogWarning("ConsultarServicioEmpresaQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                return HandleAsync(request);
            }
        }
        catch (Exception)
        {
            _logger.LogWarning("ConsultarServicioEmpresaQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }

    private async Task<List<ConsultarOpcionDePagoPorIdResponse>> HandleAsync(ConsultarOpcionDePagoPorIdQuery request)
    {//Todo lo bueno para chocar contra la bd
        try
        {
            _logger.LogInformation("ConsultarServicioEmpresaQueryHandler.HandleAsync");

            var result = _dbContext.OpcionDePago.Where(p => p.Id == request._request.opciondepago_id).Select(c => new ConsultarOpcionDePagoPorIdResponse()
            {
                Id = c.Id,
                nombre = c.nombre,
                estatus = c.estatus,

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

