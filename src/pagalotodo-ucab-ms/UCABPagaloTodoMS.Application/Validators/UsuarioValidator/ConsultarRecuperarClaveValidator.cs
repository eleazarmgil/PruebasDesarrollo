using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Requests;
using FluentValidation;

namespace UCABPagaloTodoMS.Application.Validators.UsuarioValidator
{
    public class ConsultarRecuperarClaveValidator : AbstractValidator<ConsultarRecuperarClaveQuery>
    {
        public ConsultarRecuperarClaveValidator()
        {
            RuleFor(x => x._request.usuario)
                .NotEmpty().WithMessage("El nombre de usuario es requerido.")
                .Length(3, 20).WithMessage("El nombre de usuario debe tener entre 3 y 20 caracteres.")
                .Matches("^[a-zA-Z0-9]+$").WithMessage("El nombre de usuario solo puede contener letras y números.");

            RuleFor(x => x._request.respuesta_de_seguridad)
                .NotEmpty().WithMessage("La respuesta de seguridad es requerida.")
                .Length(3, 50).WithMessage("La respuesta de seguridad debe tener entre 3 y 50 caracteres.");

            RuleFor(x => x._request.respuesta_de_seguridad2)
                .NotEmpty().WithMessage("La respuesta de seguridad es requerida.")
                .Length(3, 50).WithMessage("La respuesta de seguridad debe tener entre 3 y 50 caracteres.");

        }

    }
}
