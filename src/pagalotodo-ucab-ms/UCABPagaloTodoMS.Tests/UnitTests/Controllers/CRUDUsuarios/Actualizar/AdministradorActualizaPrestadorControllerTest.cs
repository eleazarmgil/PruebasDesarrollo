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

namespace UCABPagaloTodoMS.Tests.UnitTests.Controllers.CRUDUsuarios.Update;

public class AdministradorActualizaPrestadorControllerTest
{

    private readonly CRUDUsuariosController _controller;
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<ILogger<CRUDUsuariosController>> _loggerMock;

    public AdministradorActualizaPrestadorControllerTest()
    {
        _loggerMock = new Mock<ILogger<CRUDUsuariosController>>();
        _mediatorMock = new Mock<IMediator>();

        _controller = new CRUDUsuariosController(_loggerMock.Object, _mediatorMock.Object);
        _controller.ControllerContext = new ControllerContext();
        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
    }


    [Fact(DisplayName = "AdministradorActualizaPrestadorController estatus 200-ok")]
    public async Task AdministradorActualizaPrestadorStatus200OK()
    {
        //Arrange-> Datos necesario para las pruebas
        var request = BuildDataContextFaker.BuildAdministradorActualizarPrestadorRequest();
        var valores = BuildDataContextFaker.BuildGuidAdministradorActualizarPrestadorResponse();

        _mediatorMock.Setup(x => x.Send(It.IsAny<AdministradorActualizarConsumidorCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(valores));

        //Act-> Cuales son las actividades de mi consulta que debo tener
        var result = await _controller.AdministradorActualizarPrestador(request);
        var response = Assert.IsType<OkObjectResult>(result.Result);

        //Assert-> Aqui verifico cual es el estado de la consulta-> 200 = 200
        Assert.Equal(200, response.StatusCode);
        _mediatorMock.Verify();
    }

    [Fact(DisplayName = "AdministradorActualizaPrestadorController estatus 400-BadRequest")]
    public async Task AdministradorActualizaPrestadorStatus400BadRequestTest()
    {
        //Arrange-> Datos necesario para las pruebas
        var request = BuildDataContextFaker.BuildAdministradorActualizarPrestadorRequest();
        _mediatorMock.Setup(x => x.Send(It.IsAny<AdministradorActualizarPrestadorCommand>(), It.IsAny<CancellationToken>()))
                    .ThrowsAsync(new Exception("Ocurrio un error"));

        //Act-> Cuales son las actividades de mi consulta que debo tener
        var result = await _controller.AdministradorActualizarPrestador(request);
        Console.WriteLine(result.Result);
        var response = Assert.IsType<BadRequestObjectResult>(result.Result);

        //Assert-> Aqui verifico cual es el estado de la consulta-> 400 = 400
        Assert.Equal(400, response.StatusCode);
        _mediatorMock.Verify();
    }

}
