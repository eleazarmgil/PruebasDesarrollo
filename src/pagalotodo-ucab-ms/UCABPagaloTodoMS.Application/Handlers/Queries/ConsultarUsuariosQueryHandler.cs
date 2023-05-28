using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;

public class ConsultarUsuariosQueryHandler : IRequestHandler<ConsultarUsuariosQuery, List<ConsultarUsuariosResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarUsuariosQueryHandler> _logger;
    public ConsultarUsuariosQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarUsuariosQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public Task<List<ConsultarUsuariosResponse>> Handle(ConsultarUsuariosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("LoginUsuarioQueryHandler.Handle: Request nulo.");
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

    private async Task<List<ConsultarUsuariosResponse>> HandleAsync(ConsultarUsuariosQuery request)
    {
        try
        {
            _logger.LogInformation("ConsultarUsuariosQueryHandler.HandleAsync");

            //Traigo todos los usuario de la base de datos con los parametros que deseo ver
            var result = _dbContext.Usuario.Select(c => new ConsultarUsuariosResponse()
            {
                id_usuario = c.Id,
                nombre = c.nombre + " " + c.apellido,
                usuario = c.usuario,
                correo = c.correo,
                Discriminator = EF.Property<string>(c, "Discriminator"),
                estado = c.estado,

            });

            return await result.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarUsuariosQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }

}
