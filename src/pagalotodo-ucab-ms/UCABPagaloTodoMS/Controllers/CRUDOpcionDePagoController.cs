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
public class CRUDOpcionPagoController : BaseController<CRUDOpcionPagoController>
{
    private readonly IMediator _mediator;
    public CRUDOpcionPagoController(ILogger<CRUDOpcionPagoController> logger, IMediator mediator) : base(logger)
    {
        _mediator = mediator;
    }
    
    
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //                                             CRUDS DE AGREGAR OPCION DE PAGO
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Endpoint para agregar una nueva opcion de pago asociada a un servicio.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite agregar una nueva opcion de pago con los datos proporcionados en el cuerpo de la solicitud.
    ///     ## Description
    ///     ### GET Id de la opcion de pago
    ///     ## Url
    ///     POST /crudsopciondepago/AgregarOpcionPago
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene los datos de la opcion de pago a agregar.</param>
    /// <response code="200">
    ///     OK:
    ///     - La operación se completó con éxito y se devuelve el ID de la opcion de pago agregada.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta y no se pudo agregar la opcion de pago.
    /// </response>
    /// <returns>El ID del nuevo servicio agregado.</returns>

    [HttpPost("AgregarOpcionPago")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<ActionResult<Guid>> AgregarOpcionDePago([FromBody] AgregarOpcionPagoRequest request)
    {
        _logger.LogInformation("Entrando al método que registra la opcion de pago");
        
        try
        {
            var command = new AgregarOpcionPagoCommand(request);
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
    //                                             CRUDS DE CONSULTAR OPCION DE PAGO
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Endpoint para Consultar una opcion de pago en especifico.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite consultar una opcion de pago con los datos proporcionados en el cuerpo de la solicitud.
    ///     ## Description
    ///     ### GET Id de la opcion de pago, nombre, estatus y lista de detalle de opcion de pago
    ///     ## Url
    ///     GET /crudsopciondepago/ConsultarOpcionDePagoPorId
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene el id para consultar la opcion de pago.</param>
    /// <response code="200">
    ///     OK:
    ///     - La operación se completó con éxito y se devuelve el ID de la opcion de pago a consultar.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta y no se pudo consultar la opcion de pago.
    /// </response>
    /// <returns>El ID del nuevo servicio agregado.</returns>

    [HttpGet("ConsultarOpcionDePagoPorId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ConsultarOpcionDePagoPorIdResponse>>> ConsultarOpcionDePagoPorId([FromBody] ConsultarOpcionDePagoPorIdRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta la OpcionDePagoPorId");
        try
        {
            var query = new ConsultarOpcionDePagoPorIdQuery(request);
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
    /// Endpoint para consultar el detalle de una opcion de pago.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite consultar solo el detalle de una opcion de pago determinada .
    ///     ## Description
    ///     ### GET nombre,tipo de dato, formato y cantidad de caracteres.
    ///     ## Url
    ///     GET /crudsopciondepago/ConsultarDetalleDeOpcion
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene el id para consultar la opcion de pago.</param>
    /// <response code="200">
    ///     OK:
    ///     - La operación se completó con éxito y se devuelve el ID de la opcion de pago a consultar.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta y no se pudo consultar la opcion de pago.
    /// </response>
    /// <returns>El ID del detalle de pago de opcion consultado.</returns>
    /// 


    [HttpGet("ConsultarDetalleDeOpcion")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ConsultarDetalleDeOpcionDePagoResponse>>> ConsultarDetalleDeOpcionDePago([FromBody] ConsultarDetalleDeOpcionDePagoRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta los LoginUsuario");
        try
        {
            var query = new ConsultarDetalleDeOpcionDePagoQuery(request);
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
    //                                             CRUDS DE ACTUALIZAR OPCION DE PAGO
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    /// <summary>
    /// Endpoint para Actualizar el estatus de la opcion de pago.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite cambiar el estatus de la opcion de pago
    ///     ## Description
    ///     ### GET opciondepago_id y estado.
    ///     ## Url
    ///     PUT /crudsopciondepago/ActualizarOpcionDePagoEstado
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene el id y el estado para hacer el cambio de estatus.</param>
    /// <response code="200">
    ///     OK:
    ///     - La operación se completó con éxito y se devuelve el ID de la opcion de pago .
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta y no se pudo actualizar la opcion de pago.
    /// </response>
    /// <returns>El ID de la opcion de pago actualizada.</returns>
    /// 


    [HttpPut("ActualizarOpcionDePagoEstado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ActualizarOpcionDePagoEstadoResponse>>> ActualizarOpcionDePagoEstado([FromBody] ActualizarOpcionDePagoEstadoRequest request)
    {
        _logger.LogInformation("Entrando al método que consulta los LoginUsuario");
        try
        {
            var command = new ActualizarOpcionDePagoEstadoCommand(request);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ocurrio un error en la consulta de los usuario de prueba. Exception: " + ex);
            throw;
        }
    }

}