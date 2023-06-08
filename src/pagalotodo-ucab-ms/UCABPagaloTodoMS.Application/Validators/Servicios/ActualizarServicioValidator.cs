using FluentValidation;
using UCABPagaloTodoMS.Application.Commands;

namespace UCABPagaloTodoMS.Application.Validators.Servicios;

public class ActualizarServicioValidator : AbstractValidator<ActualizarServicioCommand>
{
    public ActualizarServicioValidator()
    {
        RuleFor(x => x._request.Id).NotEmpty().WithMessage("El campo Id es obligatorio.");

        RuleFor(x => x._request.nombre)
            .NotEmpty().When(x => x._request.nombre != null).WithMessage("El nombre del servicio no puede estar vacío.")
            .MaximumLength(30).When(x => x._request.nombre != null).WithMessage("El nombre del servicio debe tener como máximo 30 caracteres.")
            .Matches(@"[a-zA-Z]").When(x => x._request.nombre != null).WithMessage("El nombre del servicio debe contener al menos una letra.");

        RuleFor(x => x._request.descripcion)
            .NotEmpty().When(x => x._request.descripcion != null).WithMessage("La descripción del servicio no puede estar vacía.")
            .MaximumLength(35).When(x => x._request.descripcion != null).WithMessage("La descripción del servicio debe tener como máximo 35 caracteres.");

        RuleFor(x => x._request.monto)
            .NotEmpty().When(x => x._request.monto != null).WithMessage("El ID del prestador no puede estar vacío.")
            .GreaterThan(0).When(x => x._request.monto != null).WithMessage("El monto del servicio debe ser mayor que cero.");
    }
}

