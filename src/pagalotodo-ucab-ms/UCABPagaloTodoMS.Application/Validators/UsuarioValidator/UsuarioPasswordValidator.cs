using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Requests;
using FluentValidation;

namespace UCABPagaloTodoMS.Application.Validators.UsuarioValidator;

public class UsuarioPasswordValidator : AbstractValidator<ConsultarLoginUsuarioQuery>
{
    public UsuarioPasswordValidator()
    {
        // Valido que los campos que lleguen del resquest de LoginUsuario sean correctos

        RuleFor(x => x._request.usuario)
            .NotEmpty().WithMessage("El nombre de usuario es requerido.")
            .Length(3, 20).WithMessage("El nombre de usuario debe tener entre 3 y 20 caracteres.")
            .Matches("^[a-zA-Z0-9]+$").WithMessage("El nombre de usuario solo puede contener letras y números.");

        RuleFor(x => x._request.password)
            .NotEmpty().WithMessage("La contraseña es requerida.")
            .Length(8, 20).WithMessage("La contraseña debe tener entre 8 y 20 caracteres.")
            .Matches("[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
            .Matches("[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula.")
            .Matches("[0-9]").WithMessage("La contraseña debe contener al menos un número.")
            .Matches("[^a-zA-Z0-9]").WithMessage("La contraseña debe contener al menos un carácter especial.");
    }
}
