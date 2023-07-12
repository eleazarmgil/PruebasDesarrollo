﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Base;

namespace UCABPagaloTodoMS.Controllers;

[ApiController]
[Route("[controller]")]
public class CRUDPagoController : BaseController<CRUDPagoController>
{
    private readonly IMediator _mediator;
    public CRUDPagoController(ILogger<CRUDPagoController> logger, IMediator mediator) : base(logger)
    {
        _mediator = mediator;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //                                             CRUDS DE AGREGAR PAGO
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Endpoint para realizar un pago.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite agregar un nuevo pago a un servicio con los datos proporcionados en el cuerpo de la solicitud.
    ///     ## Description
    ///     ### Set campos monto, fecha, opcion de pago, consumidor y detalle del pago, 
    ///     ## Url
    ///     POST /crudPagos/AgregarPago
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene los datos del necesarios para agregar el pago.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// </response>
    /// <returns>El ID del nuevo pago agregado.</returns>

    [HttpPost("AgregarPago")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Guid>> AgregarPago([FromBody] AgregarPagoRequest request)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var command = new AgregarPagoCommand(request);
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
    //                                              CONSULTAR PAGOS CONSUMIDOR
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Endpoint para consultar los pagos que a hecho un consumidor.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite consultar todos los pagos realizador por un consumidor.
    ///     ## Description
    ///     ### Get Lista de pagos realizados.
    ///     ## Url
    ///     GET /crudPagos/ConsultarPagosConsumidor
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene el id_consumidor para hacer la consulta.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// </response>
    /// <returns> una lista de ConsultarPagosPrestadorResponse </returns>

    [HttpGet("PagosConsumidor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Guid>> AConsultarPagosConsumidor([FromBody] ConsultarPagosConsumidorRequest request)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var query = new ConsultarPagosConsumidorQuery(request);
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
    //                                              CONSULTAR PAGOS PRESTADOR
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Endpoint para consultar los pagos que ha recibido un prestador.
    /// </summary>
    /// <remarks>
    /// Este endpoint permite consultar todos los pagos recibidos.
    ///     ## Description
    ///     ### Get Lista de pagos recibidos.
    ///     ## Url
    ///     GET /crudPagos/ConsultarPagosPrestador
    /// </remarks>
    /// <param name="request">El objeto de solicitud que contiene el id_prestador para hacer la consulta.</param>
    /// <response code="200">
    ///     Accepted:
    ///     - Operation successful.
    /// </response>
    /// <response code="400">
    ///     Bad Request:
    ///     - La solicitud del cliente es incorrecta.
    /// </response>
    /// <returns> una lista de ConsultarPagosPrestadorResponse </returns>

    [HttpGet("PagosPrestador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Guid>> ConsultarPagosPrestador([FromBody] ConsultarPagosPrestadorRequest request)
    {
        _logger.LogInformation("Entrando al método que registra los valores de prueba");
        try
        {
            var query = new ConsultarPagosPrestadorQuery(request);
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
