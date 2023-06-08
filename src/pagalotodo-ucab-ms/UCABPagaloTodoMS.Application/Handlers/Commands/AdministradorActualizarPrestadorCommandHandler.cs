using MediatR;
using Microsoft.Extensions.Logging;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Core.Database;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Core.Entities;
using UCABPagaloTodoMS.Application.Validators.UsuarioValidator;
using FluentValidation.Results;
using UCABPagaloTodoMS.Application.Excepciones;
using System.Text;



namespace UCABPagaloTodoMS.Application.Handlers.Commands;
public class AdministradorActualizarPrestadorCommandHandler : IRequestHandler<AdministradorActualizarPrestadorCommand, Guid>
{
    private readonly IUCABPagaloTodoDbContext _dbContext;
    private readonly ILogger<AdministradorActualizarPrestadorCommandHandler> _logger;

    public AdministradorActualizarPrestadorCommandHandler(IUCABPagaloTodoDbContext dbContext, ILogger<AdministradorActualizarPrestadorCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> Handle(AdministradorActualizarPrestadorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._request == null)
            {
                _logger.LogWarning("ActualizarPrestadorCommandHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));
            }
            else
            {
                var validator = new AdministradorActualizarPrestadorValidator();
                ValidationResult result = validator.Validate(request);
                //Llamo a validator del LoginUsuario y verifico 
                if (result.IsValid)
                {
                    return await HandleAsync(request);

                }
                else
                {
                    var errorMessages = new StringBuilder("Registro fallido: ");

                    foreach (var error in result.Errors) //Muestra los errores
                    {
                        errorMessages.AppendLine($"{error.ErrorMessage}");
                    }
                    throw new ValidationException($"Error en campos del {nameof(request)} campos invalidos {errorMessages.ToString()}");
                }
            }
        }
        catch (ValidationException)
        {
            _logger.LogWarning("ActualizarPrestadorCommandHandler.Handle: ValidationException ");
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<Guid> HandleAsync(AdministradorActualizarPrestadorCommand request)
    {
        var transaccion = _dbContext.BeginTransaction();
        try
        {
            _logger.LogInformation("ActualizarPrestadorCommandHandler.HandleAsync {Request}", request);

            var usuario_bd = _dbContext.Prestador.FirstOrDefault(c => c.Id == request._request.Id);

            if (usuario_bd == null)
            {
                return await HandleAsync(request);
            }

            // Actualiza las propiedades del usuario
            foreach (var propiedad in typeof(AdministradorActualizarPrestadorRequest).GetProperties())
            {
                var valor = propiedad.GetValue(request._request);
                if (valor != null)
                {
                    typeof(PrestadorEntity).GetProperty(propiedad.Name)?.SetValue(usuario_bd, valor);
                }
            }

            _dbContext.Usuario.Update(usuario_bd);
            await _dbContext.SaveEfContextChanges("APP");
            transaccion.Commit();
            _logger.LogInformation("ActualizarPrestadorCommandHandler.HandleAsync {Response}", usuario_bd.Id);

            return usuario_bd.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en ActualizarPrestadorCommandHandler.HandleAsync. {Mensaje}", ex.Message);
            transaccion.Rollback();
            throw;
        }

    }
}

