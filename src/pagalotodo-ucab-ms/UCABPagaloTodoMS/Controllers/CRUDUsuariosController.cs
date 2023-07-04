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
    ///     ## Description
    ///     ### Set campos usuario,password, correo, nombre, apellido, preguntas_de_seguridad, preguntas_de_seguridad2, respuesta_de_seguridad, respuesta_de_seguridad2, rif y nombre_empresa, 
    ///     ## Url
    ///     POST /crudusuarios/agregarprestador
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene los datos del prestador a agregar.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// </response>
    /// <returns>El ID del nuevo prestador agregado.</returns>

    [HttpPost("AgregarPrestador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Guid>> AgregarPrestador([FromBody] RegistrarPrestadorRequest request)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var command = new AgregarRegistrarPrestadorCommand(request);
            var response = await _mediator.Send(command);
            return Response200(NewResponseOperation(), response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            return Response400(NewResponseOperation(), ex.Message,
                "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
        }
    }

    /// <summary>
    /// Endpoint para agregar un nuevo Consumidor.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite agregar un nuevo Consumidor con los datos proporcionados en el cuerpo de la solicitud.
    ///     ## Description
    ///     ### Set campos usuario,password, correo, nombre, apellido, preguntas_de_seguridad, preguntas_de_seguridad2, respuesta_de_seguridad, respuesta_de_seguridad2 y ci.
    ///     ## Url
    ///     GET /crudusuarios/agregarconsumidor
    ///     POST /crudusuarios/agregarconsumidor
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene los datos del Consumidor a agregar.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// </response>
    /// <returns>El ID del nuevo Consumidor agregado.</returns>

    [HttpPost("AgregarConsumidor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Guid>> AgregarConsumidor([FromBody] RegistrarConsumidorRequest request)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var command = new AgregarRegistrarConsumidorCommand(request);
            var response = await _mediator.Send(command);
            return Response200(NewResponseOperation(), response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            return Response400(NewResponseOperation(), ex.Message,
                "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //                                             CRUDS DE CONSULTAR USUARIOS
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    ///     Endpoint para obtener una lista de información de usuarios.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite obtener una lista de información de usuarios registrados en el sistema.
    ///     ## Description
    ///     ### Get campos usuario, correo y nombre
    ///     ## Url
    ///     GET /crudusuarios/consultarusuarios
    /// </remarks>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// </response>
    /// <returns> Objeto de respuesta que contiene la información de una lista de usuarios.</returns>

    [HttpGet("ConsultarUsuarios")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ConsultarUsuariosResponse>>> ConsultarUsuarios()
    {
        _logger.LogInformation("Entrando al método que consulta los LoginUsuario");
        try
        {
            var query = new ConsultarUsuariosQuery();
            var response = await _mediator.Send(query);
            return Response200(NewResponseOperation(), response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            return Response400(NewResponseOperation(), ex.Message,
                "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
        }
    }

    /// <summary>
    ///     Endpoint para obtener información de un usuario registrado en el sistema.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite obtener el Id de un usuario registrado en el sistema a partir de su nombre de usuario y contraseña.
    ///     ## Description
    ///     ### Get campo Id
    ///     ## Url
    ///     GET /crudusuarios/loginusuario
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene el nombre de usuario y contraseña del usuario a consultar.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// </response>
    /// <returns>Un objeto que contiene la información del usuario consultado.</returns>

    [HttpPost("LoginUsuario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<LoginUsuarioResponse>>> LoginUsuario([FromBody] LoginUsuarioRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta los LoginUsuario");
        try
        {
            var query = new ConsultarLoginUsuarioQuery(request);
            var response = await _mediator.Send(query);
            return Response200(NewResponseOperation(), response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            return Response400(NewResponseOperation(), ex.Message,
                "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
        }
    }

    /// <summary>
    ///     Endpoint para obtener información de un consumidor.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite obtener información de un consumidor registrado en el sistema.
    ///     ## Description
    ///     ### Get campo Id
    ///     ## Url
    ///     GET /crudusuarios/consultarconsumidor
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene el identificador del consumidor a consultar.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// </response>
    /// <returns> Un objeto que contiene la información del consumidor consultado.</returns>

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
            return Response200(NewResponseOperation(), response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            return Response400(NewResponseOperation(), ex.Message,
                "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
        }
    }

    /// <summary>
    ///     Endpoint para obtener información de un prestador.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite obtener información de un prestador registrado en el sistema.
    ///     ## Description
    ///     ### Get campo Id
    ///     ## Url
    ///     GET /crudusuarios/consultarprestador
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene el identificador del prestador a consultar.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// </response>
    /// <returns> Un objeto que contiene la información del prestador consultado.</returns>

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
            return Response200(NewResponseOperation(), response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            return Response400(NewResponseOperation(), ex.Message,
                "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
        }
    }

    /// <summary>
    ///     Endpoint para obtener información de un usuario por su id.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite obtener información de un usuario registrado en el sistema.
    ///     ## Description
    ///     ### Get campo Id
    ///     ## Url
    ///     GET /crudusuarios/consultarUsuarioId
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene el identificador del usuario a consultar.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// </response>
    /// <returns> Un objeto que contiene la información del usuario consultado.</returns>

    [HttpGet("ConsultarUsuarioId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ConsultarUsuarioIdResponse>>> ConsultarUsuarioId([FromBody] ConsultarUsuarioIdRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta el id del usuario");
        try
        {
            var query = new ConsultarUsuarioIdQuery(request);
            var response = await _mediator.Send(query);
            return Response200(NewResponseOperation(), response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            return Response400(NewResponseOperation(), ex.Message,
                "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
        }
    }

    /// <summary>
    /// Endpoint para obtener las preguntas de seguridad de un usuario registrado en el sistema.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite obtener las preguntas de seguridad de un usuario registrado en el sistema a partir de su nombre de usuario y correo electrónico.
    ///     ## Description
    ///     ### Get campos preguntas_de_seguridad, preguntas_de_seguridad2
    ///     ## Url
    ///     GET /crudusuarios/PreguntasDeSeguridad
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene el nombre de usuario y correo electrónico del usuario a consultar.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// <returns>Una lista de objetos que contienen las preguntas de seguridad del usuario consultado.</returns>

    [HttpGet("PreguntasDeSeguridad")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<PreguntasDeSeguridadResponse>>> PreguntasDeSeguridad([FromQuery] ConsultarUsuarioRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta las preguntas de seguridad del usuario");
        try
        {
            var query = new ConsultarPreguntasDeSeguridadQuery(request);
            var response = await _mediator.Send(query);
            return Response200(NewResponseOperation(), response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            return Response400(NewResponseOperation(), ex.Message,
                "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
        }
    }

    /// <summary>
    /// Endpoint para recuperar la clave de acceso de un usuario registrado en el sistema.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite recuperar la clave de acceso de un usuario registrado en el sistema a partir de su usuario y correo electrónico.
    ///     ## Description
    ///     ### Get campos Id, password
    ///     ## Url
    ///     GET /crudusuarios/recuperarclave
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene el correo electrónico del usuario.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta
    /// <returns>Un objeto que contiene la clave de acceso y id del usuario consultado.</returns>

    [HttpGet("RecuperarClave")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<RecuperarClaveResponse>>> RecuperarClave([FromBody] RecuperarClaveRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta los LoginUsuario");
        try
        {
            var query = new ConsultarRecuperarClaveQuery(request);
            var response = await _mediator.Send(query);
            return Response200(NewResponseOperation(), response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            return Response400(NewResponseOperation(), ex.Message,
                "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //                                             CRUDS DE ACTUALIZAR USUARIOS
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Actualiza un consumidor existente en la base de datos.
    /// </summary>
    /// Este endpoint permite actualizar los datos de un consumidor registrado en el sistema a partir de su guid.
    ///     ## Description
    ///     ### Get campos Id, password
    ///     ## Url
    ///     PUT /crudusuarios/recuperarclave
    /// <param name="valor">Los datos del consumidor a actualizar.</param>
    /// <returns>El ID del consumidor actualizado.</returns>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta
 
    [HttpPut("ActualizarConsumidor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> ActualizarConsumidor([FromBody] ActualizarConsumidorRequest valor)
    {
        _logger.LogInformation("Entrando al método que actualiza un consumidor");
        try
        {
            var command = new ActualizarConsumidorCommand(valor);
            var response = await _mediator.Send(command);
            return Response200(NewResponseOperation(), response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar actualizar un consumidor. Exception: " + ex);
            return Response400(NewResponseOperation(), ex.Message,
                "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
        }
    }

    /// <summary>
    /// Endpoint para actualizar la información de un consumidor de servicios registrado en el sistema por un administrador.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite actualizar la información de un consumidor de servicios registrado en el sistema a partir de su identificador único.
    ///     ## Description
    ///     ### Get campos Id
    ///     ## Url
    ///     GET /crudusuarios/AdministradorActualizarConsumidor
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene la información actualizada del consumidor de servicios.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta
    /// <returns>El identificador único del consumidor de servicios actualizado.</returns>

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
            return Response200(NewResponseOperation(), response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            return Response400(NewResponseOperation(), ex.Message,
                "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
        }
    }

    /// <summary>
    /// Endpoint para actualizar la información de un prestador de servicios registrado en el sistema por un administrador.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite actualizar la información de un prestador de servicios registrado en el sistema a partir de su identificador único.
    ///     ## Description
    ///     ### Get campos Id
    ///     ## Url
    ///     GET /crudusuarios/AdministradorActualizarPrestador
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene la información actualizada del prestador de servicios.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta
    /// <returns>El identificador único del prestador de servicios actualizado.</returns>

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
            return Response200(NewResponseOperation(), response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            return Response400(NewResponseOperation(), ex.Message,
                "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
        }
    }

    /// <summary>
    /// Endpoint para cambiar la clave de acceso de un usuario registrado en el sistema.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite cambiar la clave de acceso de un usuario registrado en el sistema a partir de su identificador único.
    ///     ## Description
    ///     ### Get campos Id y newpassword
    ///     ## Url
    ///     GET /crudusuarios/CambiarClave
    /// </remarks>
    /// <param name="valor">El objeto de solicitud que contiene el identificador único del usuario y su nueva clave de acceso.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta
    /// <returns>El identificador único del usuario con la clave de acceso actualizada.</returns>

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
            return Response200(NewResponseOperation(), response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
            return Response400(NewResponseOperation(), ex.Message,
                "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
        }
    }
}