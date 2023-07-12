using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;

public class ConsultarOpPagoServicioQueryHandler : IRequestHandler<ConsultarOpPagoServicioQuery, List<ConsultarOpPagoServicioResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarOpPagoServicioQueryHandler> _logger;
    public ConsultarOpPagoServicioQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarOpPagoServicioQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }


    /// <summary>
    /// Maneja una consulta de pagos y retorna toda los pagos registrados hechos por un consumidor en ConsultarPagosconsumidorResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarPagosConsumidorQuery contiene la información necesaria para realizar la consulta.</param>
    /// <param name="cancellationToken">El token de cancelación que se utiliza para cancelar la operación de forma asincrónica.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos ConsultarPagosPrestadorResponse.</returns>
    /// <exception cref="ArgumentNullException">Se lanza si el objeto ConsultarPagosConsumidorQuery es nulo.</exception>
    /// <remarks>
    /// Este método llama al método HandleAsync para manejar la consulta y devuelve los resultados como una tarea asincrónica. Si el objeto ConsultarPagosPrestadorQuery es nulo, se lanza una excepción ArgumentNullException.
    /// </remarks>
    /// 

    public Task<List<ConsultarOpPagoServicioResponse>> Handle(ConsultarOpPagoServicioQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning(" ConsultarOpPagoServicioQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                return HandleAsync(request);
            }
        }
        catch (Exception)
        {
            _logger.LogWarning(" ConsultarOpPagoServicioQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }
    /// <summary>
    /// Maneja una consulta de pagos y retorna toda los pagos realizados por un consumidor en ConsultarPagosConsumidorResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarPagosConsumidorQuery que contiene la información necesaria para realizar la consulta.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos ConsultarPagosConsumidorResponse.</returns>
    /// <remarks>
    /// Este método busca todos los pagos que realizo un consumidor en la base de datos y devuelve los campos "id_pago", "nombre_consumidor", "nombre_servicio", "monto", "fecha"  como una lista de objetos ConsultarPagosPrestadorResponse en una tarea asincrónica.
    /// </remarks>
    /// 
    private async Task<List<ConsultarOpPagoServicioResponse>> HandleAsync(ConsultarOpPagoServicioQuery request)
    {
        try
        {
            _logger.LogInformation("ConsultarOpPagoServicioQueryHandler.HandleAsync");

            // Obtener todas las opciones de pago que tengan el mismo ServicioEntityId que el que se manda por request
            var opcionesDePago = await _dbContext.OpcionDePago
                .Where(op => op.ServicioEntityId == request._request.id_servicio && op.estatus != "Inactiva")
                .ToListAsync();

            // Mapear cada objeto OpcionDePagoEntity a un objeto ConsultarOpPagoServicioResponse
            var result = opcionesDePago.Select(opcionDePago => new ConsultarOpPagoServicioResponse
            {
                id_opcion_pago = opcionDePago.Id,
                nombre_opcion_pago = opcionDePago.nombre,

            }).ToList();

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarOpPagoServicioQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }
}

