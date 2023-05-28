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

namespace UCABPagaloTodoMS.Tests.UnitTests.Controllers;

public class LoginUsuarioControllerTest
{
    private readonly LoginUsuarioController _controller;
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<ILogger<LoginUsuarioController>> _loggerMock;

    public LoginUsuarioControllerTest()
    {
        _loggerMock = new Mock<ILogger<LoginUsuarioController>>();
        _mediatorMock = new Mock<IMediator>();

        _controller = new LoginUsuarioController(_loggerMock.Object, _mediatorMock.Object);
        _controller.ControllerContext = new ControllerContext();
        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
    }

    [Fact(DisplayName = "LoginUsuarioController estatus 200-ok")]
    public async Task LoginUsuarioTest()
    {
        //Arrange-> Variables de mock
        var valores = BuildDataContextFaker.BuildListaLoginUsuario();
        var request = BuildDataContextFaker.BuildLoginUsuarioRequest();

        _mediatorMock.Setup(x => x.Send(It.IsAny<ConsultarLoginUsuarioQuery>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(valores));

        //Act-> Cuales son las actividades de mi consulta que debo tener
        var result = await _controller.LoginUsuario(request);
        var response = Assert.IsType<OkObjectResult>(result.Result); //

        //Assert-> Aqui verifico cual es el estado de la consulta-> 200 = 200
        Assert.Equal(200, response.StatusCode);
        _mediatorMock.Verify();

    }
}
