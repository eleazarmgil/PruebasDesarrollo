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

        /// <summary>
        /// Maneja una consulta de servicios y devuelve una lista de objetos ConsultarServiciosResponse.
        /// </summary>
        /// <param name="request">El objeto ConsultarServiciosQuery que contiene la información necesaria para realizar la consulta.</param>
        /// <param name="cancellationToken">El token de cancelación que se utiliza para cancelar la operación de forma asincrónica.</param>
        /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos ConsultarServiciosResponse.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si el objeto ConsultarServiciosQuery es nulo.</exception>
        /// <remarks>
        /// Este método llama al método HandleAsync para manejar la consulta y devuelve los resultados como una tarea asincrónica. Si el objeto ConsultarServiciosQuery es nulo, se lanza una excepción ArgumentNullException.
        /// </remarks>
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

        /// <summary>
        /// Maneja una consulta de servicios y devuelve una lista de objetos ConsultarServiciosResponse.
        /// </summary>
        /// <param name="request">El objeto ConsultarServiciosQuery que contiene la información necesaria para realizar la consulta.</param>
        /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos ConsultarServiciosResponse.</returns>
        /// <remarks>
        /// Este método busca todos los servicios en la base de datos, incluyendo los datos del prestador, y devuelve los campos "id_servicio", "nombre", "descripcion", "monto", "id_prestador" y "nombre_prestador" como una lista de objetos ConsultarServiciosResponse en una tarea asincrónica.
        /// </remarks>
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
                    nombre_prestador = c.prestador.nombre + " " + c.prestador.apellido,        
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

