using Moq;
using Xunit;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Tests.MockData;
using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Infrastructure.Utils;
using UCABPagaloTodoMS.Application.Excepciones;
using UCABPagaloTodoMS.Application.Handlers.Queries;
using System.Threading;
using FluentValidation.Results;
using UCABPagaloTodoMS.Application.Requests;
using System.Linq.Expressions;

namespace UCABPagaloTodoMS.Tests.UnitTestsApplication.Handlers.Queries.Usuarios;

public class LoginUsuarioHandlerTest
{
    private readonly ConsultarLoginUsuarioQueryHandler _handler;

    private readonly Mock<ILogger<ConsultarLoginUsuarioQueryHandler>> _loggerMock;
    private readonly Mock<IUCABPagaloTodoDbContext> _dbContextMock;
    private readonly Mock<IMediator> _mediatorMock;
    private Mock<IDbContextTransactionProxy> _mockTransaccion;
    private Mock<IValidator<ConsultarLoginUsuarioQuery>> _mockVali;
    private Mock<IRequestHandler<ConsultarLoginUsuarioQuery, List<LoginUsuarioResponse>>> _mockHandler;


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                             Handler
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public LoginUsuarioHandlerTest()
    {
        _mockHandler = new Mock<IRequestHandler<ConsultarLoginUsuarioQuery, List<LoginUsuarioResponse>>>();
        _mockVali = new Mock<IValidator<ConsultarLoginUsuarioQuery>>();
        _mediatorMock = new Mock<IMediator>();
        _loggerMock = new Mock<ILogger<ConsultarLoginUsuarioQueryHandler>>();
        _dbContextMock = new Mock<IUCABPagaloTodoDbContext>();
        _handler = new ConsultarLoginUsuarioQueryHandler(_dbContextMock.Object, _loggerMock.Object);
        DataSeed.DataSeed.SetupDbContextData(_dbContextMock);
        _mockTransaccion = new Mock<IDbContextTransactionProxy>();
    }

    [Fact(DisplayName = "Handler pasa")]
    public async Task Handle_pasa()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildLoginUsuarioRequest();
        var response = BuildDataContextFaker.BuildListaLoginUsuarioResponse;
        var query = new ConsultarLoginUsuarioQuery(request);
        var cancellationToken = new CancellationToken();

        _mockHandler.Setup(x => x.Handle(query, cancellationToken))
                   .ReturnsAsync(response);
        // Act
        var result = await _mockHandler.Object.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<LoginUsuarioResponse>>(result);
    }

    [Fact(DisplayName = "ConsultarLoginUsuarioQueryHandler Query Null Cach(Execption)")]
    public void Handle_CatchException()
    {
        // Arrange
        ConsultarLoginUsuarioQuery request = null;
        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact(DisplayName = "ConsultarLoginUsuarioQueryHandler Handle Validator Falla")]
    public void Handle_Validator()
    {
        // Arrange
        var request = BuildDataContextFaker.BuildLoginUsuarioRequest();
        var query = new ConsultarLoginUsuarioQuery(request);
        var cancellationToken = new CancellationToken();

        _mockVali.Setup(x => x.Validate(query))
             .Returns(new ValidationResult(new[] { new ValidationFailure("usuario", "El nombre de usuario es requerido.") }));


        var result = _mockHandler.Object.Handle(query, cancellationToken);
        // Act & Assert
        Assert.NotNull(() => result);
        Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(query, cancellationToken));
        //Assert.ThrowsAsync<ValidatorException>(() => _handler.Handle(query, cancellationToken ));
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                             HandlerAsync
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

  



}
