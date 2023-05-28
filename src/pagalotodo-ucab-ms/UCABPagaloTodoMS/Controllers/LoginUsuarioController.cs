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
public class LoginUsuarioController : BaseController<LoginUsuarioController>
{
    private readonly IMediator _mediator;
    public LoginUsuarioController(ILogger<LoginUsuarioController> logger, IMediator mediator) : base(logger)
    {
        _mediator = mediator;
    }

    /// <summary>
    ///     Endpoint Inicia sesión con las credenciales del usuario.
    /// </summary>
    /// <remarks>
    ///     ## Description
    ///     ### Get valores usuario y password
    ///     ## Url
    ///     GET /LoginUsuario/LoginUsuario
    /// </remarks>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// </response>
    /// <returns> Un objeto de respuesta que indica si el inicio de sesión fue exitoso o no.</returns>

    [HttpGet("LoginUsuario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LoginUsuarioResponse>> LoginUsuario([FromBody] LoginUsuarioRequest request)
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

}

