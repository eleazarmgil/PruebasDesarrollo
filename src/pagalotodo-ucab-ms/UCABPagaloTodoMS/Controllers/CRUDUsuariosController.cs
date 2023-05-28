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
public class CRUDUsuariosController : BaseController<CRUDUsuariosController>
{
    private readonly IMediator _mediator;

    public CRUDUsuariosController(ILogger<CRUDUsuariosController> logger, IMediator mediator) : base(logger)
    {
        _mediator = mediator;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //                                             CRUDS DE AGREGAR USUARIOS
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    /// <summary>
    /// Endpoint para agregar un nuevo prestador.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite agregar un nuevo prestador con los datos proporcionados en el cuerpo de la solicitud.
    /// </remarks>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// <returns>El ID del nuevo prestador agregado.</returns>

    [HttpGet("AgregarPrestador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Guid>> AgregarPrestador([FromBody] RegistrarPrestadorRequest request)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var command = new AgregarRegistrarPrestadorCommand(request);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            throw;
        }
    }

    /// <summary>
    ///     Endpoint para obtener una lista de información de usuarios.
    /// </summary>
    /// <remarks>
    ///     ## Description
    ///     ### Get campos usuario, correo y nombre
    ///     ## Url
    ///     GET /crudusuarios/agregarconsumidor
    /// </remarks>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// </response>
    /// <returns> Objeto de respuesta que contiene la información de un usuario.</returns>

    [HttpGet("AgregarConsumidor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Guid>> AgregarConsumidor([FromBody] RegistrarConsumidorRequest request)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var command = new AgregarRegistrarConsumidorCommand(request);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            throw;
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //                                             CRUDS DE CONSULTAR USUARIOS
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    ///     Endpoint para obtener una lista de información de usuarios.
    /// </summary>
    /// <remarks>
    ///     ## Description
    ///     ### Get campos usuario, correo y nombre
    ///     ## Url
    ///     GET /crudusuarios/ConsultarUsuarios
    /// </remarks>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// </response>
    /// <returns> Objeto de respuesta que contiene la información de un usuario.</returns>
 
    [HttpPost("ConsultarUsuarios")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ConsultarUsuariosResponse>>> ConsultarUsuarios()
    {
        _logger.LogInformation("Entrando al método que consulta los LoginUsuario");
        try
        {
            var query = new ConsultarUsuariosQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error en la consulta de los usuario de prueba. Exception: " + ex);
            throw;
        }
    }

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


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //                                             CRUDS DE ACTUALIZAR USUARIOS
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [HttpPost("AdministradorActualizarPrestador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> AdministradorActualizarPrestador([FromBody] AdministradorActualizarPrestadorRequest request)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var command = new AdministradorActualizarPrestadorCommand(request);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            throw;
        }
    }

    [HttpPost("AdministradorActualizarConsumidor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> AdministradorActualizarConsumidor([FromBody] AdministradorActualizarConsumidorRequest request)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var command = new AdministradorActualizarConsumidorCommand(request);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            throw;
        }
    }

    [HttpPost("CambiarClave")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CambiarClave([FromBody] CambiarClaveUsuarioRequest valor)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var query = new CambiarClaveCommand(valor);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            throw;
        }
    }

}