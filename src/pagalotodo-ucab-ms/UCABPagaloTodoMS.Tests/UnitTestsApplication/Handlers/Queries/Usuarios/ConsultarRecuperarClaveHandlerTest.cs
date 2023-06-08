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

public class ConsultarRecuperarClaveHandlerTest
{
    private readonly Mock<IUCABPagaloTodoDbContext> _dbContextMock;
    private readonly Mock<IMediator> _mediatorMock;
    private Mock<IDbContextTransactionProxy> _mockTransaccion;

    private readonly ConsultarRecuperarClaveQueryHandler _handler;
    private readonly Mock<ILogger<ConsultarRecuperarClaveQueryHandler>> _loggerMock;

    private Mock<IValidator<ConsultarRecuperarClaveQuery>> _mockVali;
    private Mock<IRequestHandler<ConsultarRecuperarClaveQuery, List<RecuperarClaveResponse>>> _mockHandler;

    public ConsultarRecuperarClaveHandlerTest()
    {
        _dbContextMock = new Mock<IUCABPagaloTodoDbContext>();
        _mediatorMock = new Mock<IMediator>();
        _mockTransaccion = new Mock<IDbContextTransactionProxy>();

        _loggerMock = new Mock<ILogger<ConsultarRecuperarClaveQueryHandler>>();
        _handler = new ConsultarRecuperarClaveQueryHandler(_dbContextMock.Object, _loggerMock.Object);

        _mockVali = new Mock<IValidator<ConsultarRecuperarClaveQuery>>();
        _mockHandler = new Mock<IRequestHandler<ConsultarRecuperarClaveQuery, List<RecuperarClaveResponse>>>();

        DataSeed.DataSeed.SetupDbContextData(_dbContextMock);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                             Handler
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    [Fact(DisplayName = "Handler pasa")]
    public async Task Handle_pasa()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildRecuperarClaveRequest();
        var response = BuildDataContextFaker.BuildListaRecuperarClaveResponse;
        var query = new ConsultarRecuperarClaveQuery(request);
        var cancellationToken = new CancellationToken();

        _mockHandler.Setup(x => x.Handle(query, cancellationToken))
                   .ReturnsAsync(response);
        // Act
        var result = await _mockHandler.Object.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<RecuperarClaveResponse>>(result);
    }

    [Fact(DisplayName = "ConsultarRecuperarClaveQueryHandler Query Null Cach(Execption)")]
    public void Handle_CatchException()
    {
        // Arrange
        ConsultarRecuperarClaveQuery request = null;
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact(DisplayName = "ConsultarRecuperarClaveQueryHandler Handle Validator Falla")]
    public void Handle_Validator()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildRecuperarClaveRequest();
        var query = new ConsultarRecuperarClaveQuery(request);
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
