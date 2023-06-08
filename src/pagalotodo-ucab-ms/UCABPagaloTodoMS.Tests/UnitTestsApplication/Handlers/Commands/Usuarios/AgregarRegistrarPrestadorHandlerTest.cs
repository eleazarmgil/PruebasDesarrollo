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

namespace UCABPagaloTodoMS.Tests.UnitTestsApplication.Handlers.Commands.Usuarios;

public class AgregarRegistrarPrestadorHandlerTest
{
    private readonly Mock<IUCABPagaloTodoDbContext> _dbContextMock;
    private readonly Mock<IMediator> _mediatorMock;
    private Mock<IDbContextTransactionProxy> _mockTransaccion;

    private readonly AgregarRegistrarPrestadorCommandHandler _handler;
    private readonly Mock<ILogger<AgregarRegistrarPrestadorCommandHandler>> _loggerMock;

    private Mock<IValidator<AgregarRegistrarPrestadorCommand>> _mockVali;
    private Mock<IRequestHandler<AgregarRegistrarPrestadorCommand, Guid>> _mockHandler;

    public AgregarRegistrarPrestadorHandlerTest()
    {
        _dbContextMock = new Mock<IUCABPagaloTodoDbContext>();
        _mediatorMock = new Mock<IMediator>();
        _mockTransaccion = new Mock<IDbContextTransactionProxy>();

        _loggerMock = new Mock<ILogger<AgregarRegistrarPrestadorCommandHandler>>();
        _handler = new AgregarRegistrarPrestadorCommandHandler(_dbContextMock.Object, _loggerMock.Object);

        _mockVali = new Mock<IValidator<AgregarRegistrarPrestadorCommand>>();
        _mockHandler = new Mock<IRequestHandler<AgregarRegistrarPrestadorCommand, Guid>>();

        DataSeed.DataSeed.SetupDbContextData(_dbContextMock);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                             Handler
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    [Fact(DisplayName = "Handler pasa")]
    public async Task Handle_pasa()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildRegistrarPrestadorRequest();
        var response = BuildDataContextFaker.BuildGuidRegistrarPrestadorResponse;
        var command = new AgregarRegistrarPrestadorCommand(request);
        var cancellationToken = new CancellationToken();

        _mockHandler.Setup(x => x.Handle(command, cancellationToken))
                   .ReturnsAsync(response);
        // Act
        var result = await _mockHandler.Object.Handle(command, cancellationToken);

        // Assert
        Assert.IsType<Guid>(result);
    }

    [Fact(DisplayName = "AgregarRegistrarPrestadorCommandHandler Command Null Cach(Execption)")]
    public void Handle_CatchException()
    {
        // Arrange
        AgregarRegistrarPrestadorCommand command = null;
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "AgregarRegistrarPrestadorCommandHandler Handle Validator Falla")]
    public void Handle_Validator()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildRegistrarPrestadorRequest();
        var command = new AgregarRegistrarPrestadorCommand(request);
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
