﻿using UCABPagaloTodoMS.Controllers;
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

namespace UCABPagaloTodoMS.Tests.UnitTests.Controllers.CRUDServicios.Update;

public class ActualizarServicioControllerTest
{
    private readonly CRUDServicioController _controller;
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<ILogger<CRUDServicioController>> _loggerMock;

    public ActualizarServicioControllerTest()
    {
        _loggerMock = new Mock<ILogger<CRUDServicioController>>();
        _mediatorMock = new Mock<IMediator>();

        _controller = new CRUDServicioController(_loggerMock.Object, _mediatorMock.Object);
        _controller.ControllerContext = new ControllerContext();
        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
    }

    [Fact(DisplayName = "ActualizarServicioController estatus 200-ok")]
    public async Task ActualizarServicioStatus200OK()
    {
        //Arrange-> Datos necesario para las pruebas
        var request = BuildDataContextFaker.BuildActualizarServicioRequest();
        var valores = BuildDataContextFaker.BuildGuidActualizarServicio();

        _mediatorMock.Setup(x => x.Send(It.IsAny<ActualizarServicioCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(valores));

        //Act-> Cuales son las actividades de mi consulta que debo tener
        var result = await _controller.ActualizarServicio(request);
        var response = Assert.IsType<OkObjectResult>(result.Result);

        //Assert-> Aqui verifico cual es el estado de la consulta-> 200 = 200
        Assert.Equal(200, response.StatusCode);
        _mediatorMock.Verify();
    }

    [Fact(DisplayName = "ActualizarServicioController estatus 400-BadRequest")]
    public async Task AdministradorActualizaServicioStatus400BadRequestTest()
    {
        //Arrange-> Datos necesario para las pruebas
        var request = BuildDataContextFaker.BuildActualizarServicioRequest();
        _mediatorMock.Setup(x => x.Send(It.IsAny<ActualizarServicioCommand>(), It.IsAny<CancellationToken>()))
                    .ThrowsAsync(new Exception("Ocurrio un error"));

        //Act-> Cuales son las actividades de mi consulta que debo tener
        var result = await _controller.ActualizarServicio(request);
        var response = Assert.IsType<BadRequestObjectResult>(result.Result);

        //Assert-> Aqui verifico cual es el estado de la consulta-> 400 = 400
        Assert.Equal(400, response.StatusCode);
        _mediatorMock.Verify();
    }
}