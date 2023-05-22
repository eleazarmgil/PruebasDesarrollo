using MediatR;
using Microsoft.AspNetCore.Mvc;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Base;

namespace UCABPagaloTodoMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultarUsuariosController : BaseController<ConsultarUsuariosController>
    {
        private readonly IMediator _mediator;
        public ConsultarUsuariosController(ILogger<ConsultarUsuariosController> logger, IMediator mediator) : base(logger)
        {
            _mediator = mediator;
        }

        [HttpGet("ConsultarUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<ConsultarUsuarios>>> ConsultarUsuarios()
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

    }
}

