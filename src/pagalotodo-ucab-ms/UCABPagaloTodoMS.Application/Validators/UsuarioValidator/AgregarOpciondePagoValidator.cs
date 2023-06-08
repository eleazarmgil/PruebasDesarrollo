using FluentValidation;
using UCABPagaloTodoMS.Application.Commands;
using static UCABPagaloTodoMS.Application.Requests.DetalleDeOpcionRequest;

namespace UCABPagaloTodoMS.Application.Validators
{
    public class AgregarOpcionPagoValidator : AbstractValidator<AgregarOpcionPagoCommand>
    {
        public AgregarOpcionPagoValidator()
        {

            RuleFor(x => x._request.nombre)
                .NotEmpty().WithMessage("El nombre de la opción de pago es requerido.")
                .MaximumLength(20).WithMessage("El nombre de la opción de pago no puede tener más de 20 caracteres.")
               .Matches("^[^0-9]+$").WithMessage("El nombre de la opcion de pago no puede contener números.");



            RuleFor(x => x._request.ServicioEntityId)
                .NotEmpty().WithMessage("El ID del prestador no puede estar vacío.")
                .Must(x => Guid.TryParse(x.ToString(), out _)).WithMessage("El ID del prestador debe ser un GUID válido.");

            RuleForEach(x => x._request.detalleDeOpcion)
                .NotNull().WithMessage("La lista de detalles de opción no debe ser nula.")
                .ChildRules(detalle =>
                {
                    detalle.RuleFor(x => x.nombre)
                        .NotEmpty().WithMessage("El nombre del detalle de opción es requerido.")
                        .MaximumLength(15).WithMessage("El nombredel detalle de opción no puede tener más de 50 caracteres.")
                        .Matches("^[^0-9]+$").WithMessage("El nombre del detalle no puede contener números.");


                    detalle.RuleFor(x => x.formato)
                         .NotEmpty().WithMessage("El formato del detalle de opción es requerido.")
                         .Must(x => Enum.IsDefined(typeof(formato_dato), x) && (int)x >= 0 && (int)x <= 7)
                         .WithMessage("El formato del detalle de opción solo puede contener números 0 para Cedula 1 Telefono 2 Corre 3 Referencia de pago 4 Alfabetico 5 Alfanumerico 6 Numerico 7 Decimal.");
                });
        }
    }
} 