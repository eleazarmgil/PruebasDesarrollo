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

public class ConsultarUsuariosHandlerTest
{
    private readonly Mock<IUCABPagaloTodoDbContext> _dbContextMock;
    private readonly Mock<IMediator> _mediatorMock;
    private Mock<IDbContextTransactionProxy> _mockTransaccion;

    private readonly ConsultarUsuariosQueryHandler _handler;
    private readonly Mock<ILogger<ConsultarUsuariosQueryHandler>> _loggerMock;

    private Mock<IValidator<ConsultarUsuariosQuery>> _mockVali;
    private Mock<IRequestHandler<ConsultarUsuariosQuery, List<ConsultarUsuariosResponse>>> _mockHandler;

    public ConsultarUsuariosHandlerTest()
    {
        _dbContextMock = new Mock<IUCABPagaloTodoDbContext>();
        _mediatorMock = new Mock<IMediator>();
        _mockTransaccion = new Mock<IDbContextTransactionProxy>();

        _loggerMock = new Mock<ILogger<ConsultarUsuariosQueryHandler>>();
        _handler = new ConsultarUsuariosQueryHandler(_dbContextMock.Object, _loggerMock.Object);

        _mockVali = new Mock<IValidator<ConsultarUsuariosQuery>>();
        _mockHandler = new Mock<IRequestHandler<ConsultarUsuariosQuery, List<ConsultarUsuariosResponse>>>();

        DataSeed.DataSeed.SetupDbContextData(_dbContextMock);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                             Handler
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    [Fact(DisplayName = "Handler pasa")]
    public async Task Handle_pasa()
    {
        // Arrange
        var response = BuildDataContextFaker.BuildListaConsultarUsuariosResponse;
        var query = new ConsultarUsuariosQuery();
        var cancellationToken = new CancellationToken();

        _mockHandler.Setup(x => x.Handle(query, cancellationToken))
                   .ReturnsAsync(response);
        // Act
        var result = await _mockHandler.Object.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<ConsultarUsuariosResponse>>(result);
    }

    [Fact(DisplayName = "ConsultarUsuariosQueryHandler Query Null Cach(Execption)")]
    public void Handle_CatchException()
    {
        // Arrange
        ConsultarUsuariosQuery request = null;
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact(DisplayName = "ConsultarUsuariosQueryHandler Handle Validator Falla")]
    public void Handle_Validator()
    {
        // Arrange
        var query = new ConsultarUsuariosQuery();
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
