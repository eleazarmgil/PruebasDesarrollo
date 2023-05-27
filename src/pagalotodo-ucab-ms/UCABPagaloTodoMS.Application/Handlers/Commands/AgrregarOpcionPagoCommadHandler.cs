using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Handlers.Queries;
using UCABPagaloTodoMS.Application.Mappers;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Core.Entities;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;

namespace UCABPagaloTodoMS.Application.Handlers.Commands;

public class AgregarOpcionPagoCommandHandler : IRequestHandler<AgregarOpcionPagoCommand, Guid>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<AgregarOpcionPagoCommandHandler> _logger;

    public AgregarOpcionPagoCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<AgregarOpcionPagoCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> Handle(AgregarOpcionPagoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._request == null)
            {
                _logger.LogWarning("ConsultarValoresQueryHandler.Handle: Request nulo.");
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

    private async Task<Guid> HandleAsync(AgregarOpcionPagoCommand request)
    {
        var transaccion = _dbContext.BeginTransaction();
        try
        {
            _logger.LogInformation("RegistrarAgregarServicoCommandHandler.HandleAsync {Request}", request);


            var result = _dbContext.Servicio.Count(c => c.Id == request._request.ServicioEntityId); // agregar que el id del servicio no exista

            if (result == 0)
            {
                throw new InvalidOperationException("Registro fallido: No existe prestador para este servicio");
            }

            var entity = AgregarOpcionPagoMapper.MapRequestEntity(request._request);



          /*  entity.detalleDeOpcion = new List<DetalleDeOpcionEntity>();

            if (request._request.detalleDeOpcion != null)
            {
                foreach (var detalleDeOpcion in request._request.detalleDeOpcion)
                {
                    entity.detalleDeOpcion.Add(new DetalleDeOpcionEntity
                    {
                        nombre = detalleDeOpcion.nombre,
                        tipo_dato = detalleDeOpcion.tipo_dato,
                        cant_caracteres = detalleDeOpcion.cant_caracteres,
                        formato = detalleDeOpcion.formato,
                        
                    });
                }
            }*/



            _dbContext.OpcionDePago.Add(entity);
            var id = entity.Id;

            await _dbContext.SaveEfContextChanges("APP");
            transaccion.Commit();
            _logger.LogInformation("AgregarValorPruebaCommandHandler.HandleAsync {Response}", id);
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarValoresQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            transaccion.Rollback();
            throw;
        }
    }


}
