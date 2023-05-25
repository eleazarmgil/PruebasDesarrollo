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
public class ConsultarConsumidorController : BaseController<ConsultarConsumidorController>
{
    private readonly IMediator _mediator;
    public ConsultarConsumidorController(ILogger<ConsultarConsumidorController> logger, IMediator mediator) : base(logger)
    {
        _mediator = mediator;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [HttpGet("ConsultarConsumidor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ConsultarConsumidorResponse>>> ConsultarConsumidor([FromBody] ConsultarConsumidorRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta el ci del consumidor");
        try
        {
            var query = new ConsultarConsumidorQuery(request);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error en la consulta del ci del prestador. Exception: " + ex);
            throw;
        }
    }
}

