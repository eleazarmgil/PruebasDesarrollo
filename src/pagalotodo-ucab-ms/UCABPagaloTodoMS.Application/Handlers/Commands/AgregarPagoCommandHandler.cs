
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Mappers;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Core.Entities;
using UCABPagaloTodoMS.Infrastructure.Migrations;

namespace UCABPagaloTodoMS.Application.Handlers.Commands;

public class AgregarPagoCommandHandler : IRequestHandler<AgregarPagoCommand, Guid>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<AgregarPagoCommandHandler> _logger;
    private readonly MediatR.IMediator _mediator;

    public AgregarPagoCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<AgregarPagoCommandHandler> logger, MediatR.IMediator mediator)
    {
        _dbContext = dbContext;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<Guid> Handle(AgregarPagoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._request == null)
            {
                _logger.LogWarning("AgregarPagoCommandHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                return await HandleAsync(request);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<Guid> HandleAsync(AgregarPagoCommand request)
    {
        var transaccion = _dbContext.BeginTransaction();

        try
        {
            _logger.LogInformation("AgregarPagoCommandHandler.HandleAsync {Request}", request);


            var opcionDePago = await _dbContext.OpcionDePago
             .Where(c => c.Id == request._request.OpcionDePagoIdEntity)
             .Select(c => new { c.estatus, c.ServicioEntityId })
             .FirstOrDefaultAsync();

            if (opcionDePago == null)
            {
                throw new InvalidOperationException("Registro fallido: No existe la opcion de pago indicada");
            }

            if (opcionDePago.estatus != "Activa")
            {
                throw new InvalidOperationException("Registro fallido: La opcion de pago indicada no está activa");
            }

            var servicio = await _dbContext.Servicio
            .Where(s => s.Id == opcionDePago.ServicioEntityId)
            .FirstOrDefaultAsync();

            if (servicio == null)
            {
                throw new InvalidOperationException("Registro fallido: No existe el servicio correspondiente a la opción de pago indicada");
            }

            if (request._request.monto < servicio.monto)
            {
                throw new InvalidOperationException($"Registro fallido: El monto mínimo de pago es {servicio.monto}.");
            }


            var entity = AgregarPagoMapper.MapRequestEntity(request._request);
            entity.ServicioEntityId = opcionDePago.ServicioEntityId;
            _dbContext.Pago.Add(entity);
            


            var consultaDetallesRequest = new ConsultarDetalleDeOpcionDePagoRequest
            {
                opciondepago_id = request._request.OpcionDePagoIdEntity
            };



            var detallesOpcionPago = await _mediator.Send(new ConsultarDetalleDeOpcionDePagoQuery(consultaDetallesRequest));

            if (request._request.detalledepago == null || request._request.detalledepago.Count != detallesOpcionPago.Count)
            {
                throw new InvalidOperationException("Registro fallido: La lista de detalles de pago es nula o no tiene la cantidad correcta de elementos.");
            }

            var detalleDePagoEntities = new List<DetalleDePagoEntity>();


            for (int i = 0; i < detallesOpcionPago.Count; i++)
            {
                var detalleDepago = new DetalleDePagoEntity
                {
                    nombre = detallesOpcionPago[i].nombre ?? "",
                    detalle = request._request.detalledepago[i].detalle,
                    pagoid = entity.Id,
                };

                detalleDePagoEntities.Add(detalleDepago);
            }


            _dbContext.DetalleDePago.AddRange(detalleDePagoEntities);

            
            await _dbContext.SaveEfContextChanges("APP");
            transaccion.Commit();
            _logger.LogInformation("AgregarPagoCommandHandler.HandleAsync {Response}", entity.Id);
            return entity.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error AgregarPagoCommandHandler.HandleAsync. {Mensaje}", ex.Message);
            transaccion.Rollback();
            throw;
        }

    }


}
