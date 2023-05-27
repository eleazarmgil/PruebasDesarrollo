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
public class ConsultarOpcionDePagoPorIdController : BaseController<ConsultarOpcionDePagoPorIdController>
{
    private readonly IMediator _mediator;
    public ConsultarOpcionDePagoPorIdController(ILogger<ConsultarOpcionDePagoPorIdController> logger, IMediator mediator) : base(logger)
    {
        _mediator = mediator;
    }

    [HttpPost("ConsultarOpcionDePagoPorId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ConsultarOpcionDePagoPorIdResponse>>> ConsultarOpcionDePagoPorId([FromBody] ConsultarOpcionDePagoPorIdRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta los LoginUsuario");
        try
        {
            var query = new ConsultarOpcionDePagoPorIdQuery(request);
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

