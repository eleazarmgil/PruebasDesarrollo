using Moq;
using Xunit;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Tests.MockData;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Responses;
using FluentValidation.Results;
using UCABPagaloTodoMS.Application.Handlers.Commands;
using UCABPagaloTodoMS.Application.Queries;

namespace UCABPagaloTodoMS.Tests.UnitTestsApplication.Handlers.Commands.CRUDPagos;

public class AgregarPagoHandlerTest
{
    private readonly Mock<IUCABPagaloTodoDbContext> _dbContextMock;
    private readonly Mock<IMediator> _mediatorMock;
    private Mock<IDbContextTransactionProxy> _mockTransaccion;

    private readonly AgregarPagoCommandHandler _handler;
    private readonly Mock<ILogger<AgregarPagoCommandHandler>> _loggerMock;

    private Mock<IValidator<AgregarPagoCommand>> _mockVali;
    private Mock<IRequestHandler<AgregarPagoCommand, Guid>> _mockHandler;

    public AgregarPagoHandlerTest()
    {
        _dbContextMock = new Mock<IUCABPagaloTodoDbContext>();
        _mediatorMock = new Mock<IMediator>();
        _mockTransaccion = new Mock<IDbContextTransactionProxy>();

        _loggerMock = new Mock<ILogger<AgregarPagoCommandHandler>>();
        _handler = new AgregarPagoCommandHandler(_dbContextMock.Object, _loggerMock.Object, _mediatorMock.Object);

        _mockVali = new Mock<IValidator<AgregarPagoCommand>>();
        _mockHandler = new Mock<IRequestHandler<AgregarPagoCommand, Guid>>();

        DataSeed.DataSeed.SetupDbContextData(_dbContextMock);
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                             Handler
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    [Fact(DisplayName = "Handler pasa")]
    public async Task Handle_pasa()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildAgregarPagoRequest();
        var response = BuildDataContextFaker.BuildGuidAgregarPagoResponse;
        var command = new AgregarPagoCommand(request);
        var cancellationToken = new CancellationToken();

        _mockHandler.Setup(x => x.Handle(command, cancellationToken))
                   .ReturnsAsync(response);
        // Act
        var result = await _mockHandler.Object.Handle(command, cancellationToken);

        // Assert
        Assert.IsType<Guid>(result);
    }

    [Fact(DisplayName = "AgregarPagoCommandHandler Command Null Cach(Execption)")]
    public void Handle_CatchException()
    {
        // Arrange
        AgregarPagoCommand command = null;
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "AgregarPagoCommandHandler Handle Validator Falla")]
    public void Handle_Validator()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildAgregarPagoRequest();
        var command = new AgregarPagoCommand(request);
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
