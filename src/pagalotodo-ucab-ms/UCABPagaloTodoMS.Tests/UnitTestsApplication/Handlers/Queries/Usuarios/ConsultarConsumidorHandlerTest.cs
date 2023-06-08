using Moq;
using Xunit;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Tests.MockData;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Application.Handlers.Queries;
using FluentValidation.Results;


namespace UCABPagaloTodoMS.Tests.UnitTestsApplication.Handlers.Queries.Usuarios;

public class ConsultarConsumidorHandlerTest
{
    private readonly ConsultarConsumidorQueryHandler _handler;
    private readonly Mock<ILogger<ConsultarConsumidorQueryHandler>> _loggerMock;
    private readonly Mock<IUCABPagaloTodoDbContext> _dbContextMock;
    private readonly Mock<IMediator> _mediatorMock;
    private Mock<IDbContextTransactionProxy> _mockTransaccion;
    private Mock<IValidator<ConsultarConsumidorQuery>> _mockVali;
    private Mock<IRequestHandler<ConsultarConsumidorQuery, List<ConsultarConsumidorResponse>>> _mockHandler;

    public ConsultarConsumidorHandlerTest()
    {
        _mockHandler = new Mock<IRequestHandler<ConsultarConsumidorQuery, List<ConsultarConsumidorResponse>>>();
        _mockVali = new Mock<IValidator<ConsultarConsumidorQuery>>();
        _mediatorMock = new Mock<IMediator>();
        _loggerMock = new Mock<ILogger<ConsultarConsumidorQueryHandler>>();
        _dbContextMock = new Mock<IUCABPagaloTodoDbContext>();
        _handler = new ConsultarConsumidorQueryHandler(_dbContextMock.Object, _loggerMock.Object);
        DataSeed.DataSeed.SetupDbContextData(_dbContextMock);
        _mockTransaccion = new Mock<IDbContextTransactionProxy>();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                             Handler
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [Fact(DisplayName = "Handler pasa")]
    public async Task Handle_pasa()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildConsultarConsumidorRequest();
        var response = BuildDataContextFaker.BuildListaConsultarConsumidorResponse;
        var query = new ConsultarConsumidorQuery(request);
        var cancellationToken = new CancellationToken();

        _mockHandler.Setup(x => x.Handle(query, cancellationToken))
                   .ReturnsAsync(response);
        // Act
        var result = await _mockHandler.Object.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<ConsultarConsumidorResponse>>(result);
    }

    [Fact(DisplayName = "ConsultarConsumidorQueryHandler Query Null Cach(Execption)")]
    public void Handle_CatchException()
    {
        // Arrange
        ConsultarConsumidorQuery request = null;
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact(DisplayName = "ConsultarConsumidorQueryHandler Handle Validator Falla")]
    public void Handle_Validator()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildConsultarConsumidorRequest();
        var query = new ConsultarConsumidorQuery(request);
        var cancellationToken = new CancellationToken();

        _mockVali.Setup(x => x.Validate(query))
             .Returns(new ValidationResult(new[] { new ValidationFailure("ci", "El campo CI es requerido.") }));


        var result = _mockHandler.Object.Handle(query, cancellationToken);
        // Act & Assert
        Assert.NotNull(() => result);
        Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(query, cancellationToken));
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                             HandlerAsync
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



}

