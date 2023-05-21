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
public class ConsultasUsuariosController : BaseController<ConsultasUsuariosController>
{
    private readonly IMediator _mediator;
    public ConsultasUsuariosController(ILogger<ConsultasUsuariosController> logger, IMediator mediator) : base(logger)
    {
        _mediator = mediator;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [HttpGet("PreguntasDeSeguridad")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<PreguntasDeSeguridadResponse>>> LoginUsuario([FromBody] PreguntasDeSeguridadRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta las preguntas de seguridad del usuario");
        try
        {
            var query = new ConsultarPreguntasDeSeguridadQuery(request);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error en la consulta de los usuario de prueba. Exception: " + ex);
            throw;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [HttpGet("LoginUsuario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<LoginUsuarioResponse>>> LoginUsuario([FromBody] LoginUsuarioRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta los LoginUsuario");
        try
        {
            var query = new ConsultarLoginUsuarioQuery(request);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error en la consulta de los usuario de prueba. Exception: " + ex);
            throw;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [HttpGet("RecuperarClave")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<RecuperarClaveResponse>>> LoginUsuario([FromBody] RecuperarClaveRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta los LoginUsuario");
        try
        {
            var query = new ConsultarRecuperarClaveQuery(request);
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
