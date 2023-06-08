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

namespace UCABPagaloTodoMS.Tests.UnitTestsApplication.Handlers.Queries.Opcion;

public class ConsultarOpcionDePagoPorIdHandlerTest
{
    private readonly ConsultarOpcionDePagoPorIdQueryHandler _handler;
    private readonly Mock<ILogger<ConsultarOpcionDePagoPorIdQueryHandler>> _loggerMock;
    private readonly Mock<IUCABPagaloTodoDbContext> _dbContextMock;
    private readonly Mock<IMediator> _mediatorMock;
    private Mock<IDbContextTransactionProxy> _mockTransaccion;
    private Mock<IValidator<ConsultarOpcionDePagoPorIdQuery>> _mockVali;
    private Mock<IRequestHandler<ConsultarOpcionDePagoPorIdQuery, List<ConsultarOpcionDePagoPorIdResponse>>> _mockHandler;

    public ConsultarOpcionDePagoPorIdHandlerTest()
    {
        _mockHandler = new Mock<IRequestHandler<ConsultarOpcionDePagoPorIdQuery, List<ConsultarOpcionDePagoPorIdResponse>>>();
        _mockVali = new Mock<IValidator<ConsultarOpcionDePagoPorIdQuery>>();
        _mediatorMock = new Mock<IMediator>();
        _loggerMock = new Mock<ILogger<ConsultarOpcionDePagoPorIdQueryHandler>>();
        _dbContextMock = new Mock<IUCABPagaloTodoDbContext>();
        _handler = new ConsultarOpcionDePagoPorIdQueryHandler(_dbContextMock.Object, _loggerMock.Object);
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
        var request = BuildDataContextFaker.BuildConsultarOpcionDePagoPorIdRequest();
        var response = BuildDataContextFaker.BuildConsultarOpcionDePagoPorIdResponse;
        var query = new ConsultarOpcionDePagoPorIdQuery(request);
        var cancellationToken = new CancellationToken();

        _mockHandler.Setup(x => x.Handle(query, cancellationToken))
                   .ReturnsAsync(response);
        // Act
        var result = await _mockHandler.Object.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<ConsultarOpcionDePagoPorIdResponse>>(result);
    }

    [Fact(DisplayName = "ConsultarOpcionDePagoPorIdQueryHandler Query Null Cach(Execption)")]
    public void Handle_CatchException()
    {
        // Arrange
        ConsultarOpcionDePagoPorIdQuery request = null;
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact(DisplayName = "ConsultarOpcionDePagoPorIdQueryHandler Handle Validator Falla")]
    public void Handle_Validator()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildConsultarOpcionDePagoPorIdRequest();
        var query = new ConsultarOpcionDePagoPorIdQuery(request);
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
