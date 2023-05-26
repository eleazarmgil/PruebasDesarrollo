using UCABPagaloTodoMS.Controllers;
using UCABPagaloTodoMS.Tests.MockData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

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
}
