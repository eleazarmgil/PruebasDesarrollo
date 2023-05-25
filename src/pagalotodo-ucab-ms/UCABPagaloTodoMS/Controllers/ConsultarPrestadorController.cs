using MediatR;
using Microsoft.AspNetCore.Mvc;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Base;

namespace UCABPagaloTodoMS.Controllers;

[ApiController]
[Route("[controller]")]
public class ConsultarPrestadorController : BaseController<ConsultarPrestadorController>
{
    private readonly IMediator _mediator;
    public ConsultarPrestadorController(ILogger<ConsultarPrestadorController> logger, IMediator mediator) : base(logger)
    {
        _mediator = mediator;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [HttpGet("ConsultarPrestador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ConsultarPrestadorResponse>>> ConsultarPrestador([FromBody] ConsultarPrestadorRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta el rif del prestador");
        try
        {
            var query = new ConsultarPrestadorQuery(request);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error en la consulta de los usuario de prueba. Exception: " + ex);
            throw;
        }
    }
}
