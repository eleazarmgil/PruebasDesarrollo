using UCABPagaloTodoMS.Controllers;
using UCABPagaloTodoMS.Tests.MockData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Tests.UnitTests.Controllers.CRUDOpcionDePago;

public class ConsultarDetalleDeOpcionControllerTest
{
    private readonly CRUDOpcionPagoController _controller;
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<ILogger<CRUDOpcionPagoController>> _loggerMock;

    public ConsultarDetalleDeOpcionControllerTest()
    {
        _loggerMock = new Mock<ILogger<CRUDOpcionPagoController>>();
        _mediatorMock = new Mock<IMediator>();

        _controller = new CRUDOpcionPagoController(_loggerMock.Object, _mediatorMock.Object);
        _controller.ControllerContext = new ControllerContext();
        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
    }

    [Fact(DisplayName = "ConsultarDetalleDeOpcionDePagoController estatus 200-ok")]
    public async Task ConsultarDetalleDeOpcionDePagoStatus200OK()
    {
        //Arrange-> Datos necesario para las pruebas
        var request = BuildDataContextFaker.BuildConsultarDetalleDeOpcionRequest();
        var valores = BuildDataContextFaker.BuildConsultarDetalleDeOpcionResponse();

        _mediatorMock.Setup(x => x.Send(It.IsAny<ConsultarDetalleDeOpcionDePagoQuery>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(valores));

        //Act-> Cuales son las actividades de mi consulta que debo tener
        var result = await _controller.ConsultarDetalleDeOpcionDePago(request);
        var response = Assert.IsType<OkObjectResult>(result.Result);

        //Assert-> Aqui verifico cual es el estado de la consulta-> 200 = 200
        Assert.Equal(200, response.StatusCode);
        _mediatorMock.Verify();
    }

    [Fact(DisplayName = "ConsultarDetalleDeOpcionDePagoController estatus 400-BadRequest")]
    public async Task ConsultarDetalleDeOpcionDePagoStatus400BadRequestTest()
    {
        //Arrange-> Datos necesario para las pruebas
        var request = BuildDataContextFaker.BuildConsultarDetalleDeOpcionRequest();
        _mediatorMock.Setup(x => x.Send(It.IsAny<ConsultarDetalleDeOpcionDePagoQuery>(), It.IsAny<CancellationToken>()))
                    .ThrowsAsync(new Exception("Ocurrio un error"));

        //Act-> Cuales son las actividades de mi consulta que debo tener
        var result = await _controller.ConsultarDetalleDeOpcionDePago(request);
        var response = Assert.IsType<BadRequestObjectResult>(result.Result);

        //Assert-> Aqui verifico cual es el estado de la consulta-> 400 = 400
        Assert.Equal(400, response.StatusCode);
        _mediatorMock.Verify();
    }
}
