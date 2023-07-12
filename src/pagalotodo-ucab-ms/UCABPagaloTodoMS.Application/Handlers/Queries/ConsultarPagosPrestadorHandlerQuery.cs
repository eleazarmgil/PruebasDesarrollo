using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;

public class ConsultarPagosPrestadorQueryHandler : IRequestHandler<ConsultarPagosPrestadorQuery, List<ConsultarPagosPrestadorResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarPagosPrestadorQueryHandler> _logger;
    public ConsultarPagosPrestadorQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarPagosPrestadorQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// Maneja una consulta de pagos y retorna toda los pagos registrados de un prestador en ConsultarPagosPrestadorResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarPagosPrestadorQuery contiene la información necesaria para realizar la consulta.</param>
    /// <param name="cancellationToken">El token de cancelación que se utiliza para cancelar la operación de forma asincrónica.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos ConsultarPagosPrestadorResponse.</returns>
    /// <exception cref="ArgumentNullException">Se lanza si el objeto ConsultarPagosPrestadorQuery es nulo.</exception>
    /// <remarks>
    /// Este método llama al método HandleAsync para manejar la consulta y devuelve los resultados como una tarea asincrónica. Si el objeto ConsultarPagosPrestadorQuery es nulo, se lanza una excepción ArgumentNullException.
    /// </remarks>
    /// 


    public Task<List<ConsultarPagosPrestadorResponse>> Handle(ConsultarPagosPrestadorQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("ConsultarPagosPrestadorQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                return HandleAsync(request);
            }
        }
        catch (Exception)
        {
            _logger.LogWarning("ConsultarPagosPrestadorQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }
    /// <summary>
    /// Maneja una consulta de pagos y retorna toda los pagos registrados de un prestafor en ConsultarPagosPrestadorResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarPagosPrestadorQuery que contiene la información necesaria para realizar la consulta.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos ConsultarPagosPrestadorResponse.</returns>
    /// <remarks>
    /// Este método busca todos los pagos que recibe un prestador en la base de datos y devuelve los campos "id_pago", "nombre_consumidor", "nombre_servicio", "monto", "fecha"  como una lista de objetos ConsultarPagosPrestadorResponse en una tarea asincrónica.
    /// </remarks>
    /// 

    private async Task<List<ConsultarPagosPrestadorResponse>> HandleAsync(ConsultarPagosPrestadorQuery request)
    {
        try
        {
            _logger.LogInformation("ConsultarPagosPrestadorQueryHandler.HandleAsync");

            var servicios = await _dbContext.Servicio
                .Include(s => s.pago)
                .ThenInclude(p => p.Consumidor)
                .Where(s => s.PrestadorEntityId == request._request.id_prestador)
                .ToListAsync();

            if (servicios.All(s => s.pago == null || !s.pago.Any()))
            {
                throw new InvalidOperationException("No se encuentran pagos registrados");
            }

            // Mapear cada objeto PagoEntity a un objeto ConsultarPagosPrestadorResponse
            var result = servicios.SelectMany(servicio => servicio.pago.Select(pago => new ConsultarPagosPrestadorResponse
            {
                id_pago = pago.Id,
                fecha = pago.fecha,
                monto = pago.monto,
                nombre_servicio = servicio.nombre,
                nombre_consumidor = pago.Consumidor.nombre
            })).ToList();

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarPagosConsumidorQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }
}

