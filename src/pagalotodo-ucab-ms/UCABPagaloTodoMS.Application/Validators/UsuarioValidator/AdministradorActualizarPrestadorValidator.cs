using FluentValidation;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Requests;


namespace UCABPagaloTodoMS.Application.Validators.UsuarioValidator;

public class AdministradorActualizarPrestadorValidator : AbstractValidator<AdministradorActualizarPrestadorCommand>
{
    public AdministradorActualizarPrestadorValidator()
    {
        RuleFor(x => x._request.Id).NotEmpty().WithMessage("El campo Id es obligatorio.");

        RuleFor(x => x._request.usuario)
            .NotEmpty().When(x => x._request.usuario != null).WithMessage("El nombre de usuario es requerido.")
            .Length(3, 20).When(x => x._request.usuario != null).WithMessage("El nombre de usuario debe tener entre 3 y 20 caracteres.")
            .Matches("^[a-zA-Z0-9]+$").When(x => x._request.usuario != null).WithMessage("El nombre de usuario solo puede contener letras y números.");

        RuleFor(x => x._request.password)
            .NotEmpty().When(x => x._request.password != null).WithMessage("La contraseña es requerida.")
            .Length(8, 20).When(x => x._request.password != null).WithMessage("La contraseña debe tener entre 8 y 20 caracteres.")
            .Matches("[A-Z]").When(x => x._request.password != null).WithMessage("La contraseña debe contener al menos una letra mayúscula.")
            .Matches("[a-z]").When(x => x._request.password != null).WithMessage("La contraseña debe contener al menos una letra minúscula.")
            .Matches("[0-9]").When(x => x._request.password != null).WithMessage("La contraseña debe contener al menos un número.")
            .Matches("[^a-zA-Z0-9]").When(x => x._request.password != null).WithMessage("La contraseña debe contener al menos un carácter especial.");

        RuleFor(x => x._request.correo).NotEmpty().When(x => x._request.correo != null).WithMessage("El campo correo no puede ser vacio")
                              .EmailAddress().When(x => x._request.correo != null).WithMessage("El campo correo debe ser una dirección de correo electrónico válida.");

        RuleFor(x => x._request.nombre).NotEmpty().When(x => x._request.nombre != null).WithMessage("El campo nombre no puede ser vacio.")
             .Matches("^[^0-9]+$").WithMessage("El nombre no puede contener números.");


        RuleFor(x => x._request.apellido).NotEmpty().When(x => x._request.apellido != null).WithMessage("El campo apellido no puede ser vacio.")
             .Matches("^[^0-9]+$").WithMessage("El nombre no puede contener números.");


        RuleFor(x => x._request.preguntas_de_seguridad)
            .NotEmpty().When(x => x._request.preguntas_de_seguridad != null).WithMessage("La pregunta de seguridad no puede estar vacía.")
            .Length(4, 50).When(x => x._request.preguntas_de_seguridad != null).WithMessage("La pregunta de seguridad debe tener entre 4 y 50 caracteres.");

        RuleFor(x => x._request.preguntas_de_seguridad2)
            .NotEmpty().When(x => x._request.preguntas_de_seguridad2 != null).WithMessage("La pregunta de seguridad 2 no puede estar vacía.")
            .Length(4, 50).When(x => x._request.preguntas_de_seguridad2 != null).WithMessage("La pregunta de seguridad 2 debe tener entre 4 y 50 caracteres.");

        RuleFor(x => x._request.respuesta_de_seguridad2)
            .NotEmpty().When(x => x._request.respuesta_de_seguridad2 != null).WithMessage("La respuestas de seguridad no puede estar vacía.")
            .Length(2, 20).When(x => x._request.respuesta_de_seguridad2 != null).WithMessage("La respuestas de seguridad debe tener entre 4 y 50 caracteres.");

        RuleFor(x => x._request.respuesta_de_seguridad)
            .NotEmpty().When(x => x._request.respuesta_de_seguridad != null).WithMessage("La respuestas de seguridad 2 no puede estar vacía.")
            .Length(2, 20).When(x => x._request.respuesta_de_seguridad != null).WithMessage("La pregunta de seguridad 2 debe tener entre 4 y 50 caracteres.");

        RuleFor(x => x._request.rif)
            .NotEmpty().When(x => x._request.rif != null).WithMessage("El RIF no puede estar vacío.")
            .Matches(@"^(J|G|V|E|P)-\d{8}$").When(x => x._request.rif != null).WithMessage("El RIF debe tener el formato J|G|V|E|P-XXXXXXX, J|G|V|E|P-XXXXXXXX");
        //Este Matches dice que la cadena debe comenzar con la instancia J o G o V o E o P, en la segunda posicion el guion -, y luego de 6 a 7 digitos numericos

        RuleFor(x => x._request.nombre_empresa)
            .NotEmpty().When(x => x._request.nombre_empresa != null).WithMessage("El nombre de la empresa no puede estar vacío.")
            .Length(2, 20).When(x => x._request.nombre_empresa != null).WithMessage("El nombre de la empresa debe tener entre 2 y 50 caracteres.");

        RuleFor(x => x._request.estado).NotEmpty().When(x => x._request.estado != null).WithMessage("El estado no puede estar vacío.")
            .Must(x => x is bool).WithMessage("El formato del estado no es válido.")
            .When(x => x._request.estado != null);


    }
}
