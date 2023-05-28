using UCABPagaloTodoMS.Core.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using Microsoft.EntityFrameworkCore;

namespace UCABPagaloTodoMS.Application.Handlers.Queries;
public class ConsultarPreguntasDeSeguridadQueryHandler : IRequestHandler<ConsultarPreguntasDeSeguridadQuery, List<PreguntasDeSeguridadResponse>>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<ConsultarPreguntasDeSeguridadQueryHandler> _logger;
    public ConsultarPreguntasDeSeguridadQueryHandler(IUCABPagaloTodoDbContext dbContext, ILogger<ConsultarPreguntasDeSeguridadQueryHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public Task<List<PreguntasDeSeguridadResponse>> Handle(ConsultarPreguntasDeSeguridadQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("ConsultarPreguntasDeSeguridadQueryHandler: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                return HandleAsync(request);
            }
        }
        catch (Exception)
        {
            _logger.LogWarning("ConsultarPreguntasDeSeguridadQueryHandler: ArgumentNullException");
            throw;
        }
    }

    private async Task<List<PreguntasDeSeguridadResponse>> HandleAsync(ConsultarPreguntasDeSeguridadQuery request)
    {//Todo lo bueno para chocar contra la bd
        try
        {
            _logger.LogInformation("ConsultarPreguntasDeSeguridadQueryHandler.HandleAsync");

            var result = _dbContext.Usuario.Where(c => c.usuario == request._request.usuario).Select(c => new PreguntasDeSeguridadResponse()
            {
               pregunta_de_seguridad = c.preguntas_de_seguridad,
               pregunta_de_seguridad2 = c.preguntas_de_seguridad2
            });

            return await result.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarPreguntasDeSeguridadQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }
    }



}
