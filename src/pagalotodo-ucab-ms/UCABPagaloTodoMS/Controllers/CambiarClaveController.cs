using Microsoft.AspNetCore.Mvc;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CambiarClaveController : Controller
    {
        private readonly IMediator _mediator;

        public CambiarClaveController(ILogger<CambiarClaveController> logger, IMediator mediator) : base(logger)
        {
            _mediator = mediator;
        }

        [HttpPost("valor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> AgregarValor(ValoresRequest valor)
        {
            _logger.LogInformation("Entrando al método que registra los valores de prueba");
            try
            {
                var query = new AgregarValorPruebaCommand(valor);
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
