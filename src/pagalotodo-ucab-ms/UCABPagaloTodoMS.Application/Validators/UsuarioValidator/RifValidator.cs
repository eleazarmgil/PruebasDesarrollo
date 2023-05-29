using UCABPagaloTodoMS.Application.Queries;
using UCABPagaloTodoMS.Application.Requests;
using FluentValidation;


namespace UCABPagaloTodoMS.Application.Validators.UsuarioValidator;

public class RifValidator: AbstractValidator<ConsultarPrestadorQuery>
{
    public RifValidator()
    {
        // Valido que los campos que lleguen del resquest de ConsultarPrestadorRequest sean correctos

        RuleFor(x => x._request.rif)
            .NotEmpty().WithMessage("El RIF no puede estar vacío.")
            .Matches(@"^(J|G|V|E|P)-\d{8}$").WithMessage("El RIF debe tener el formato J|G|V|E|P-XXXXXXX, J|G|V|E|P-XXXXXXXX");
        //Este Matches dice que la cadena debe comenzar con la instancia J o G o V o E o P, en la segunda posicion el guion -, y luego de 6 a 7 digitos numericos
    }
}