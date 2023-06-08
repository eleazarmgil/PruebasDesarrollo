using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Requests;
using FluentValidation;
namespace UCABPagaloTodoMS.Application.Validators.UsuarioValidator;

public class ActualizarOpcionDePagoEstado : AbstractValidator<ActualizarOpcionDePagoEstadoCommand>
{
    public ActualizarOpcionDePagoEstado()
    {

        RuleFor(x => x._request.estado)
          .NotEmpty().WithMessage("El estado no puede estar vacío.")
          .Must(x => x == "Inactiva" || x == "Proximamente" || x == "Activa").WithMessage("El estado debe ser 'inactiva', 'proximamente' o 'activa'.");
    }
}