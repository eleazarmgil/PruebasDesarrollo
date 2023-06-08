using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Requests;
using FluentValidation;
namespace UCABPagaloTodoMS.Application.Validators.UsuarioValidator;

public class ConsultarOpcionDePagoPorIdValidator : AbstractValidator<ConsultarOpcionDePagoPorIdQuery>
{
    public ConsultarOpcionDePagoPorIdValidator()
    {
        RuleFor(x => x._request.opciondepago_id)
             .NotEmpty().WithMessage("El ID del prestador no puede estar vacío.")
             .Must(x => Guid.TryParse(x.ToString(), out _)).WithMessage("El ID del prestador debe ser un GUID válido.");
    }
}