using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Requests;
using FluentValidation;

namespace UCABPagaloTodoMS.Application.Validators.UsuarioValidator;

public class UsuarioValidator : AbstractValidator<ConsultarPreguntasDeSeguridadQuery>
{
    public UsuarioValidator()
    {
        // Valido que los campos que lleguen del resquest de LoginUsuario sean correctos

        RuleFor(x => x._request.usuario)
            .NotEmpty().WithMessage("El nombre de usuario es requerido.")
            .Length(3, 20).WithMessage("El nombre de usuario debe tener entre 3 y 20 caracteres.")
            .Matches("^[a-zA-Z0-9]+$").WithMessage("El nombre de usuario solo puede contener letras y números.");

    }
}
