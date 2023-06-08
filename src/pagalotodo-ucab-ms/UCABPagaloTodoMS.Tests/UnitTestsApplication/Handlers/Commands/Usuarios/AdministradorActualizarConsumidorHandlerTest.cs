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
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Tests.UnitTestsApplication.Handlers.Commands.Usuarios;

public class AdministradorActualizarConsumidorHandlerTest
{
    private readonly Mock<IUCABPagaloTodoDbContext> _dbContextMock;
    private readonly Mock<IMediator> _mediatorMock;
    private Mock<IDbContextTransactionProxy> _mockTransaccion;

    private readonly AdministradorActualizarConsumidorCommandHandler _handler;
    private readonly Mock<ILogger<AdministradorActualizarConsumidorCommandHandler>> _loggerMock;

    private Mock<IValidator<AdministradorActualizarConsumidorCommand>> _mockVali;
    private Mock<IRequestHandler<AdministradorActualizarConsumidorCommand, Guid>> _mockHandler;

    public AdministradorActualizarConsumidorHandlerTest()
    {
        _dbContextMock = new Mock<IUCABPagaloTodoDbContext>();
        _mediatorMock = new Mock<IMediator>();
        _mockTransaccion = new Mock<IDbContextTransactionProxy>();

        _loggerMock = new Mock<ILogger<AdministradorActualizarConsumidorCommandHandler>>();
        _handler = new AdministradorActualizarConsumidorCommandHandler(_dbContextMock.Object, _loggerMock.Object);

        _mockVali = new Mock<IValidator<AdministradorActualizarConsumidorCommand>>();
        _mockHandler = new Mock<IRequestHandler<AdministradorActualizarConsumidorCommand, Guid>>();

        DataSeed.DataSeed.SetupDbContextData(_dbContextMock);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                             Handler
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    [Fact(DisplayName = "Handler pasa")]
    public async Task Handle_pasa()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildAdministradorActualizarConsumidorRequest();
        var response = BuildDataContextFaker.BuildGuidAdministradorActualizarConsumidorResponse;
        var command = new AdministradorActualizarConsumidorCommand(request);
        var cancellationToken = new CancellationToken();

        _mockHandler.Setup(x => x.Handle(command, cancellationToken))
                   .ReturnsAsync(response);
        // Act
        var result = await _mockHandler.Object.Handle(command, cancellationToken);

        // Assert
        Assert.IsType<Guid>(result);
    }

    [Fact(DisplayName = "AdministradorActualizarConsumidorCommandHandler Command Null Cach(Execption)")]
    public void Handle_CatchException()
    {
        // Arrange
        AdministradorActualizarConsumidorCommand command = null;
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "AdministradorActualizarConsumidorCommandHandler Handle Validator Falla")]
    public void Handle_Validator()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildAdministradorActualizarConsumidorRequest();
        var query = new AdministradorActualizarConsumidorCommand(request);
        var cancellationToken = new CancellationToken();

        _mockVali.Setup(x => x.Validate(query))
             .Returns(new ValidationResult(new[] { new ValidationFailure("usuario", "El nombre de usuario es requerido.") }));


        var result = _mockHandler.Object.Handle(query, cancellationToken);
        // Act & Assert
        Assert.NotNull(() => result);
        Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(query, cancellationToken));
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                             HandlerAsync
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

}
