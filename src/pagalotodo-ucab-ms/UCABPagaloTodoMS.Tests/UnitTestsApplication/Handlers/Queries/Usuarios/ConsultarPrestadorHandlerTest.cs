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

public class ConsultarPrestadorHandlerTest
{
    private readonly Mock<IUCABPagaloTodoDbContext> _dbContextMock;
    private readonly Mock<IMediator> _mediatorMock;
    private Mock<IDbContextTransactionProxy> _mockTransaccion;

    private readonly ConsultarPrestadorQueryHandler _handler;
    private readonly Mock<ILogger<ConsultarPrestadorQueryHandler>> _loggerMock;

    private Mock<IValidator<ConsultarPrestadorQuery>> _mockVali;
    private Mock<IRequestHandler<ConsultarPrestadorQuery, List<ConsultarPrestadorResponse>>> _mockHandler;

    public ConsultarPrestadorHandlerTest()
    {
        _dbContextMock = new Mock<IUCABPagaloTodoDbContext>();
        _mediatorMock = new Mock<IMediator>();
        _mockTransaccion = new Mock<IDbContextTransactionProxy>();

        _loggerMock = new Mock<ILogger<ConsultarPrestadorQueryHandler>>();
        _handler = new ConsultarPrestadorQueryHandler(_dbContextMock.Object, _loggerMock.Object);

        _mockVali = new Mock<IValidator<ConsultarPrestadorQuery>>();
        _mockHandler = new Mock<IRequestHandler<ConsultarPrestadorQuery, List<ConsultarPrestadorResponse>>>();

        DataSeed.DataSeed.SetupDbContextData(_dbContextMock);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                             Handler
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    [Fact(DisplayName = "Handler pasa")]
    public async Task Handle_pasa()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildConsultarPrestadorRequest();
        var response = BuildDataContextFaker.BuildListaConsultarPrestadorResponse;
        var query = new ConsultarPrestadorQuery(request);
        var cancellationToken = new CancellationToken();

        _mockHandler.Setup(x => x.Handle(query, cancellationToken))
                   .ReturnsAsync(response);
        // Act
        var result = await _mockHandler.Object.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<ConsultarPrestadorResponse>>(result);
    }

    [Fact(DisplayName = "ConsultarPrestadorQueryHandler Query Null Cach(Execption)")]
    public void Handle_CatchException()
    {
        // Arrange
        ConsultarPrestadorQuery request = null;
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact(DisplayName = "ConsultarPrestadorQueryHandler Handle Validator Falla")]
    public void Handle_Validator()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildConsultarPrestadorRequest();
        var query = new ConsultarPrestadorQuery(request);
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
