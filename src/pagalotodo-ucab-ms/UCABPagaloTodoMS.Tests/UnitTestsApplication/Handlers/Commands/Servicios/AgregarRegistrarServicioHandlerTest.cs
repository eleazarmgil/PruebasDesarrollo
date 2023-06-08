using Moq;
using Xunit;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Tests.MockData;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Application.Handlers.Queries;
using FluentValidation.Results;
using UCABPagaloTodoMS.Application.Handlers.Commands;
using UCABPagaloTodoMS.Application.Queries;

namespace UCABPagaloTodoMS.Tests.UnitTestsApplication.Handlers.Commands.Servicios;

public class AgregarRegistrarServicioHandlerTest
{
    private readonly Mock<IUCABPagaloTodoDbContext> _dbContextMock;
    private readonly Mock<IMediator> _mediatorMock;
    private Mock<IDbContextTransactionProxy> _mockTransaccion;

    private readonly AgregarRegistrarServicioCommandHandler _handler;
    private readonly Mock<ILogger<AgregarRegistrarServicioCommandHandler>> _loggerMock;

    private Mock<IValidator<AgregarRegistrarServicioCommand>> _mockVali;
    private Mock<IRequestHandler<AgregarRegistrarServicioCommand, Guid>> _mockHandler;

    public AgregarRegistrarServicioHandlerTest()
    {
        _dbContextMock = new Mock<IUCABPagaloTodoDbContext>();
        _mediatorMock = new Mock<IMediator>();
        _mockTransaccion = new Mock<IDbContextTransactionProxy>();

        _loggerMock = new Mock<ILogger<AgregarRegistrarServicioCommandHandler>>();
        _handler = new AgregarRegistrarServicioCommandHandler(_dbContextMock.Object, _loggerMock.Object);

        _mockVali = new Mock<IValidator<AgregarRegistrarServicioCommand>>();
        _mockHandler = new Mock<IRequestHandler<AgregarRegistrarServicioCommand, Guid>>();

        DataSeed.DataSeed.SetupDbContextData(_dbContextMock);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                             Handler
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    [Fact(DisplayName = "Handler pasa")]
    public async Task Handle_pasa()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildRegistrarServicioRequest();
        var response = BuildDataContextFaker.BuildGuidRegistrarServicioResponse;
        var command = new AgregarRegistrarServicioCommand(request);
        var cancellationToken = new CancellationToken();

        _mockHandler.Setup(x => x.Handle(command, cancellationToken))
                   .ReturnsAsync(response);
        // Act
        var result = await _mockHandler.Object.Handle(command, cancellationToken);

        // Assert
        Assert.IsType<Guid>(result);
    }

    [Fact(DisplayName = "AgregarRegistrarServicioCommandHandler Command Null Cach(Execption)")]
    public void Handle_CatchException()
    {
        // Arrange
        AgregarRegistrarServicioCommand command = null;
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "AgregarRegistrarServicioCommandHandler Handle Validator Falla")]
    public void Handle_Validator()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildRegistrarServicioRequest();
        var command = new AgregarRegistrarServicioCommand(request);
        var cancellationToken = new CancellationToken();

        _mockVali.Setup(x => x.Validate(command))
             .Returns(new ValidationResult(new[] { new ValidationFailure("usuario", "El nombre de usuario es requerido.") }));


        var result = _mockHandler.Object.Handle(command, cancellationToken);
        // Act & Assert
        Assert.NotNull(() => result);
        Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, cancellationToken));
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                             HandlerAsync
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

}
