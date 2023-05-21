using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Handlers.Queries;
using UCABPagaloTodoMS.Application.Mappers;
using UCABPagaloTodoMS.Core.Database;

namespace UCABPagaloTodoMS.Application.Handlers.Commands
{
    public class AgregarRegistrarServicioCommandHandler : IRequestHandler<AgregarRegistrarServicioCommand, Guid>
    {
        private readonly IUCABPagaloTodoDbContext _dbContext;
        private readonly ILogger<AgregarRegistrarServicioCommandHandler> _logger;

        public AgregarRegistrarServicioCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<AgregarRegistrarServicioCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Guid> Handle(AgregarRegistrarServicioCommand request, CancellationToken cancellationToken)
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

        private async Task<Guid> HandleAsync(AgregarRegistrarServicioCommand request)
        {
            var transaccion = _dbContext.BeginTransaction();
            try
            {
                _logger.LogInformation("RegistrarAgregarServicoCommandHandler.HandleAsync {Request}", request);
                Guid idGuid;
                Guid.TryParse(request._request.id, out idGuid);

                var result = _dbContext.Usuario.Count(c => c.Id == idGuid); // agregar que el id del servicio no exista

                if (result == 0)
                {
                    throw new InvalidOperationException("Registro fallido: No existe prestador para este servicio");
                }

                var entity = RegistrarServicioMapper.MapRequestEntity(request._request);
                _dbContext.Servicio.Add(entity);
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
}
