﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Base;

namespace UCABPagaloTodoMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CambiarClaveController : BaseController<CambiarClaveController>
    {
        private readonly IMediator _mediator;

        public CambiarClaveController(ILogger<CambiarClaveController> logger, IMediator mediator) : base(logger)
        {
            _mediator = mediator;
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
}
