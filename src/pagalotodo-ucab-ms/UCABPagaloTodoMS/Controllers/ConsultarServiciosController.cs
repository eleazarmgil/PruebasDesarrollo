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
public class ConsultarServiciosController : BaseController<ConsultarServiciosController>
{
    private readonly IMediator _mediator;
    public ConsultarServiciosController(ILogger<ConsultarServiciosController> logger, IMediator mediator) : base(logger)
    {
        _mediator = mediator;
    }

    [HttpPost("ConsultarServicios")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ConsultarServiciosResponse>>> ConsultarServicios()
    {
        _logger.LogInformation("Entrando al método que consulta los LoginUsuario");
        try
        {
            var query = new ConsultarServiciosQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error en la consulta de los usuario de prueba. Exception: " + ex);
            throw;
        }
    }


    [HttpPost("ConsultarServiciosEmpresa")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ConsultarServicioEmpresaResponse>>> ConsultarServicioEmpresa([FromBody] ConsultarServicioEmpresaRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta los LoginUsuario");
        try
        {
            var query = new ConsultarServicioEmpresaQuery(request);
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

