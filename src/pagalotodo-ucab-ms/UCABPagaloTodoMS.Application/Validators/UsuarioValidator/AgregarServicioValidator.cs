using FluentValidation;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Requests;

public class AgregarServicioValidator : AbstractValidator<AgregarRegistrarServicioCommand>
{
    public AgregarServicioValidator()
    {

        RuleFor(x => x._request.PrestadorEntityId)
            .NotEmpty().WithMessage("El ID del prestador no puede estar vacío.")
            .Must(x => Guid.TryParse(x.ToString(), out _)).WithMessage("El ID del prestador debe ser un GUID válido.");

        RuleFor(x => x._request.nombre)
            .NotEmpty().WithMessage("El nombre del servicio no puede estar vacío.")
            .MaximumLength(30).WithMessage("El nombre del servicio debe tener como máximo 30 caracteres.")
            .Matches(@"[a-zA-Z]").WithMessage("El nombre del servicio debe contener al menos una letra.");

        RuleFor(x => x._request.descripcion)
            .NotEmpty().WithMessage("La descripción del servicio no puede estar vacía.")
            .MaximumLength(35).WithMessage("La descripción del servicio debe tener como máximo 35 caracteres.");

        RuleFor(x => x._request.monto)
            .NotEmpty().WithMessage("El ID del prestador no puede estar vacío.")
            .GreaterThan(0).WithMessage("El monto del servicio debe ser mayor que cero.");
    }

}

