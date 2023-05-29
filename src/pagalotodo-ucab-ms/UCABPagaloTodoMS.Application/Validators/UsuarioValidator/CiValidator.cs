using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Requests;
using FluentValidation;
namespace UCABPagaloTodoMS.Application.Validators.UsuarioValidator;

public class CiValidator : AbstractValidator<ConsultarConsumidorQuery>
{
    public CiValidator()
    {
        RuleFor(x => x._request.ci)
            .NotEmpty().WithMessage("La cédula no puede estar vacía.")
            .Matches(@"^(V|E)-\d{6,7}$").WithMessage("La cédula debe tener el formato V-XXXXXXX, V-XXXXXXXX, E-XXXXXX o E-XXXXXXX");
            //Este Matches dice que la cadena debe comenzar con la instancia V o E, en la segunda posicion el guion -, y luego de 6 a 7 digitos numericos
    }
}
