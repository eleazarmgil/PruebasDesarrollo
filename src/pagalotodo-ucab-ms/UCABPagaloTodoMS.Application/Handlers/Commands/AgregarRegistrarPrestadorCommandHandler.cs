using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Handlers.Queries;
using UCABPagaloTodoMS.Application.Mappers;
using UCABPagaloTodoMS.Core.Database;

namespace UCABPagaloTodoMS.Application.Handlers.Commands
{
    public class AgregarRegistrarPrestadorCommandHandler : IRequestHandler<AgregarRegistrarPrestadorCommand, Guid>
    {
        private readonly IUCABPagaloTodoDbContext _dbContext;
        private readonly ILogger<AgregarRegistrarPrestadorCommandHandler> _logger;

        public AgregarRegistrarPrestadorCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<AgregarRegistrarPrestadorCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Guid> Handle(AgregarRegistrarPrestadorCommand request, CancellationToken cancellationToken)
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

        private async Task<Guid> HandleAsync(AgregarRegistrarPrestadorCommand request)
        {
            var transaccion = _dbContext.BeginTransaction();
            try
            {
                _logger.LogInformation("AgregarValorPruebaCommandHandler.HandleAsync {Request}", request);
                var result = _dbContext.Prestador.Count(c => c.usuario == request._request.usuario);

                if (result > 0)
                {
                    throw new InvalidOperationException("Registro fallido: el usuario ya existe");
                }

                var entity = RegistrarPrestadorMapper.MapRequestEntity(request._request);
                _dbContext.Prestador.Add(entity);
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
