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
public class AgregarPagoController : BaseController<AgregarPagoController>
{
    private readonly IMediator _mediator;
    public AgregarPagoController(ILogger<AgregarPagoController> logger, IMediator mediator) : base(logger)
    {
        _mediator = mediator;
    }
    [HttpGet("AgregarPago")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Guid>> AgregarPago([FromBody] AgregarPagoRequest request)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var command = new AgregarPagoCommand(request);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            throw;
        }
    }
}
