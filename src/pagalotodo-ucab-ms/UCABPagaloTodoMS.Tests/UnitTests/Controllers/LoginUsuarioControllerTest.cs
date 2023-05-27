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

    [Fact]
    public async Task LoginUsuarioTest()
    {
        var valores = BuildDataContextFaker.BuildListaLoginUsuario();

        _mediatorMock.Setup(x => x.Send(It.IsAny<ConsultarLoginUsuarioQuery>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(valores));

        var result = await _controller.LoginUsuario();
        var response = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(200, response.StatusCode);
        _mediatorMock.Verify();

    }
}
