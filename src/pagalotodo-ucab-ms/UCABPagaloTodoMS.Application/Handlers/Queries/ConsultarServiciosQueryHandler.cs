using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;

    public class ConsultarServiciosQueryHandler : IRequestHandler<ConsultarServiciosQuery, List<ConsultarServiciosResponse>>
    {
        private readonly IUCABPagaloTodoDbContext _dbContext;
        private readonly ILogger<ConsultarServiciosQueryHandler> _logger;
        public ConsultarServiciosQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarServiciosQueryHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<List<ConsultarServiciosResponse>> Handle(ConsultarServiciosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null) //Pregunto si el request es nulo
            {
                    _logger.LogWarning("ConsultarServiciosQueryHandler.Handle: Request nulo.");
                    throw new ArgumentNullException(nameof(request));
                }
                else
                {
                    return HandleAsync(request);
                }
            }
            catch (Exception)
            {
                _logger.LogWarning("ConsultarServiciosQueryHandler.Handle: ArgumentNullException");
                throw;
            }
        }

        private async Task<List<ConsultarServiciosResponse>> HandleAsync(ConsultarServiciosQuery request)
        {
            try
            {
                _logger.LogInformation("ConsultarServiciosQueryHandler.HandleAsync");

                var result = await _dbContext.Servicio
                .Include(s => s.prestador)
                .Select(c => new ConsultarServiciosResponse()
                {
                    id_servicio = c.Id,
                    nombre = c.nombre,
                    descripcion = c.descripcion,
                    monto = c.monto,
                    id_prestador = c.PrestadorEntityId,
                    nombre_prestador = c.prestador.nombre,        
                })
            .ToListAsync();
            return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ConsultarServiciosQueryHandler.HandleAsync. {Mensaje}", ex.Message);
                throw;
            }
        }

    }

