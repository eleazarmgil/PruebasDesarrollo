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
public class CRUDServicioController : BaseController<CRUDServicioController>
{
    private readonly IMediator _mediator;
    public CRUDServicioController(ILogger<CRUDServicioController> logger, IMediator mediator) : base(logger)
    {
        _mediator = mediator;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //                                             CRUDS DE AGREGAR SERVICIOS
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Endpoint para agregar un nuevo servicio.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite agregar un nuevo servicio con los datos proporcionados en el cuerpo de la solicitud.
    ///     ## Description
    ///     ### GET Id del servicio
    ///     ## Url
    ///     GET /crudservicio/AgregarServicio
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene los datos del servicio a agregar.</param>
    /// <response code="200">
    ///     OK:
    ///     - La operación se completó con éxito y se devuelve el ID del nuevo servicio agregado.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta y no se pudo agregar el servicio.
    /// </response>
    /// <returns>El ID del nuevo servicio agregado.</returns>

    [HttpPost("AgregarServicio")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> AgregarServicio([FromBody] RegistrarServicioRequest request)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var command = new AgregarRegistrarServicioCommand(request);
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
    //                                             CRUDS DE CONSULTAR SERVICIOS
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Endpoint para consultar todos los servicios registrados.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite consultar todos los servicios registrados en el sistema.
    ///     ## Description
    ///     ### GET lista de servicios
    ///     ## Url
    ///     GET /crudservicio/ConsultarServicios
    /// </remarks>
    /// <response code="200">
    ///     OK:
    ///     - La operación se completó con éxito y se devuelve una lista de objetos ConsultarServiciosResponse.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta y no se pudo consultar los servicios.
    /// </response>
    /// <returns>Una lista de objetos ConsultarServiciosResponse que contienen información de todos los servicios registrados.</returns>

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
    //                                             CRUDS DE ACTUALIZAR SERVICIOS
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    /// <summary>
    /// Endpoint para actualizar un servicio existente.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite actualizar un servicio existente con los datos proporcionados en el cuerpo de la solicitud.
    ///     ## Description
    ///     ### GET Id del servicio
    ///     ## Url
    ///     GET /crudservicio/ActualizarServicio
    /// </remarks>
    /// <param name="valor">El objeto de solicitud que contiene los datos del servicio a actualizar.</param>
    /// <response code="200">
    ///     OK:
    ///     - La operación se completó con éxito y se devuelve el ID del servicio actualizado.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta y no se pudo actualizar el servicio.
    /// </response>
    /// <returns>El ID del servicio actualizado.</returns>
    [HttpPost("ActualizarServicio")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> ActualizarServicio([FromBody] ActualizarServicioRequest valor)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var query = new ActualizarServicioCommand(valor);
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
