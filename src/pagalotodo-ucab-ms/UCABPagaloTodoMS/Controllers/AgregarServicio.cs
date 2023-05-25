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
public class AgregarServicioController : BaseController<AgregarServicioController>
{
    private readonly IMediator _mediator;
    public AgregarServicioController(ILogger<AgregarServicioController> logger, IMediator mediator) : base(logger)
    {
        _mediator = mediator;
    }
    [HttpPost("AgregarServicio")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Guid>> AgregarPrestador([FromBody] RegistrarServicioRequest request)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var command = new AgregarRegistrarServicioCommand(request);
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
