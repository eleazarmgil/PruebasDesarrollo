using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UCABPagaloTodoMS.Application.Handlers.Queries;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Tests.DataSeed;
using UCABPagaloTodoMS.Tests.MockData;
using Xunit;

namespace UCABPagaloTodoMS.Tests.UnitTestsApplication.Handlers.Queries.Usuarios;

public class LoginUsuarioHandlerTest
{
    private readonly ConsultarLoginUsuarioQueryHandler _handler;
    private readonly Mock<IUCABPagaloTodoDbContext> _contextMock;
    private readonly Mock<ILogger<ConsultarLoginUsuarioQueryHandler>> _mockLogger;

    public LoginUsuarioHandlerTest()
    {
        var faker = new Faker();
        _contextMock = new Mock<IUCABPagaloTodoDbContext>();
        _mockLogger = new Mock<ILogger<ConsultarLoginUsuarioQueryHandler>>();
        _handler = new ConsultarLoginUsuarioQueryHandler(_contextMock.Object, _mockLogger.Object);
        _contextMock.SetupDbContextData();
    }

    [Fact]
    public void Handle_NullQuery_ThrowsArgumentNullException()
    {
        // Arrange
        ConsultarLoginUsuarioQuery request = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public void Handle_UserNotFound_ThrowsInvalidOperationException()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildLoginUsuarioRequestFallaUsuarioNull();
        var query = new ConsultarLoginUsuarioQuery(request);

        var handler = _handler.Handle(query, CancellationToken.None);
        
        Assert.NotNull(handler);
        // Act & Assert
        Assert.ThrowsAsync<InvalidOperationException>(() => handler);
    }

}
