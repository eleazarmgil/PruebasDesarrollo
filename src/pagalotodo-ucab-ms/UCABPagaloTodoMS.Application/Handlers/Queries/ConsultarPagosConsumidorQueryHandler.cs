using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;

public class ConsultarPagosConsumidorQueryHandler : IRequestHandler<ConsultarPagosConsumidorQuery, List<ConsultarPagosConsumidorResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarPagosConsumidorQueryHandler> _logger;
    public ConsultarPagosConsumidorQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarPagosConsumidorQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// Maneja una consulta de usurario y retorna toda la informacion asociada al id del usuario ConsultarUsuarioIdResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarUsuarioIdQuery que contiene la información necesaria para realizar la consulta.</param>
    /// <param name="cancellationToken">El token de cancelación que se utiliza para cancelar la operación de forma asincrónica.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos ConsultarUsuarioIdResponse.</returns>
    /// <exception cref="ArgumentNullException">Se lanza si el objeto ConsultarUsuarioIdQuery es nulo.</exception>
    /// <remarks>
    /// Este método llama al método HandleAsync para manejar la consulta y devuelve los resultados como una tarea asincrónica. Si el objeto ConsultarUsuarioIdQuery es nulo, se lanza una excepción ArgumentNullException.
    /// </remarks>
    public Task<List<ConsultarPagosConsumidorResponse>> Handle(ConsultarPagosConsumidorQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("ConsultarUsuarioIdQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                return HandleAsync(request);
            }
        }
        catch (Exception)
        {
            _logger.LogWarning("ConsultarUsuariosQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }
    /// <summary>
    /// Maneja una consulta de usuarios y devuelve una lista de objetos ConsultarUsuarioIdResponse.
    /// </summary>
    /// <param name="request">El objeto ConsultarUsuarioIdQuery que contiene la información necesaria para realizar la consulta.</param>
    /// <returns>Una tarea asincrónica que representa la operación y una lista de objetos ConsultarUsuariosResponse.</returns>
    /// <remarks>
    /// Este método busca todos los usuarios en la base de datos y devuelve los campos "id_usuario", "nombre", "usuario", "correo", "Discriminator" y "estado" como una lista de objetos ConsultarUsuariosResponse en una tarea asincrónica.
    /// </remarks>
    private async Task<List<ConsultarPagosConsumidorResponse>> HandleAsync(ConsultarPagosConsumidorQuery request)
    {

        try
        {
            _logger.LogInformation("ConsultarPagosConsumidorQueryHandler.HandleAsync");

            // Obtener el objeto ConsumidorEntity correspondiente al ID del consumidor que se está consultando
            var consumidor = await _dbContext.Usuario.OfType<ConsumidorEntity>()
                .Include(c => c.Pago)
                .FirstOrDefaultAsync(c => c.Id == request._request.id_consumidor);

            // Si no se encuentra el consumidor, devolver una lista vacía
            if (consumidor == null)
            {
                return new List<ConsultarPagosConsumidorResponse>();
            }

            // Mapear cada objeto PagoEntity a un objeto ConsultarPagosConsumidorResponse
            var result = new List<ConsultarPagosConsumidorResponse>();

            foreach (var pago in consumidor.Pago)
            {
                var servicio = await _dbContext.Servicio.FindAsync(pago.ServicioEntityId);

                if (servicio == null)
                {
                    continue; // Si no se encuentra el servicio asociado al pago, continuar con el siguiente pago
                }

                var response = new ConsultarPagosConsumidorResponse()
                {
                    id_pago = pago.Id,
                    fecha = pago.fecha,
                    monto = pago.monto,
                    nombre_servicio = servicio.nombre
                };

                result.Add(response);
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarPagosConsumidorQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }
}

