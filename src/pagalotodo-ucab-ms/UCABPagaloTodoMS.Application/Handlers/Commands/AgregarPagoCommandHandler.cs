using Azure;
using MassTransit.Mediator;
using MediatR;
using Microsoft.Azure.Amqp.Serialization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Handlers.Queries;
using UCABPagaloTodoMS.Application.Mappers;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Core.Entities;

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
                _logger.LogWarning("ActualizarPrestadorCommandHandler.Handle: Request nulo.");
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

           
            var result = _dbContext.OpcionDePago.Count(c => c.Id == request._request.OpcionDePagoIdEntity); // id existe

            if (result == 0)
            {
                throw new InvalidOperationException("Registro fallido: No existe prestador para este servicio");
            }

            var entity = AgregarPagoMapper.MapRequestEntity(request._request);

            _dbContext.Pago.Add(entity);
           // var id = entity.Id;
           

            var consultaDetallesRequest = new ConsultarDetalleDeOpcionDePagoRequest
            {
                opciondepago_id = request._request.OpcionDePagoIdEntity
            };



            var detallesOpcionPago = await _mediator.Send(new ConsultarDetalleDeOpcionDePagoQuery(consultaDetallesRequest));

            foreach (var detalle in detallesOpcionPago)
            {
                var detallePago = new DetalleDePagoEntity
                {
                    nombre = detalle.nombre,
                    pagoid= entity.Id,
                    // asignar las demás propiedades de DetalleDePagoEntity según corresponda
                };
                _dbContext.DetalleDePago.Add(detallePago);
            }

            await _dbContext.SaveEfContextChanges("APP");
            transaccion.Commit();
            _logger.LogInformation("AgregarValorPruebaCommandHandler.HandleAsync {Response}", entity.Id);
            return entity.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarValoresQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            transaccion.Rollback();
            throw;
        }

    }
}
