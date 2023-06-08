using MediatR;
using FluentValidation;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Tests.MockData;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Application.Handlers.Queries;
using FluentValidation.Results;
using Moq;
using Xunit;

namespace UCABPagaloTodoMS.Tests.UnitTestsApplication.Handlers.Queries.Servicios;
public class ConsultarServiciosHandlerTest
{
    private readonly ConsultarServiciosQueryHandler _handler;
    private readonly Mock<ILogger<ConsultarServiciosQueryHandler>> _loggerMock;
    private readonly Mock<IUCABPagaloTodoDbContext> _dbContextMock;
    private readonly Mock<IMediator> _mediatorMock;
    private Mock<IDbContextTransactionProxy> _mockTransaccion;
    private Mock<IValidator<ConsultarServiciosQuery>> _mockVali;
    private Mock<IRequestHandler<ConsultarServiciosQuery, List<ConsultarServiciosResponse>>> _mockHandler;

    public ConsultarServiciosHandlerTest()
    {
        _mockHandler = new Mock<IRequestHandler<ConsultarServiciosQuery, List<ConsultarServiciosResponse>>>();
        _mockVali = new Mock<IValidator<ConsultarServiciosQuery>>();
        _mediatorMock = new Mock<IMediator>();
        _loggerMock = new Mock<ILogger<ConsultarServiciosQueryHandler>>();
        _dbContextMock = new Mock<IUCABPagaloTodoDbContext>();
        _handler = new ConsultarServiciosQueryHandler(_dbContextMock.Object, _loggerMock.Object);
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
        var response = BuildDataContextFaker.BuildGuidConsultarServiciosResponse;
        var query = new ConsultarServiciosQuery();
        var cancellationToken = new CancellationToken();

        _mockHandler.Setup(x => x.Handle(query, cancellationToken))
                   .ReturnsAsync(response);
        // Act
        var result = await _mockHandler.Object.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<ConsultarServiciosResponse>>(result);
    }

    [Fact(DisplayName = "ConsultarServiciosQueryHandler Query Null Cach(Execption)")]
    public void Handle_CatchException()
    {
        // Arrange
        ConsultarServiciosQuery request = null;
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact(DisplayName = "ConsultarServiciosQueryHandler Handle Validator Falla")]
    public void Handle_Validator()
    {
        // Arrange
        var query = new ConsultarServiciosQuery();
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
