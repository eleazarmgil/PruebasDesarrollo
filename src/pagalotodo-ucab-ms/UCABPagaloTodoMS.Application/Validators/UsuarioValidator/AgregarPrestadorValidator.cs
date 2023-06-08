﻿using FluentValidation;
using UCABPagaloTodoMS.Application.Commands;
using UCABPagaloTodoMS.Application.Requests;

public class AgregarPrestadorValidator : AbstractValidator<AgregarRegistrarPrestadorCommand>
{
    public AgregarPrestadorValidator()
    {
        RuleFor(x => x._request.password)
            .NotEmpty().WithMessage("La contraseña es requerida.")
            .Length(8, 20).WithMessage("La contraseña debe tener entre 8 y 20 caracteres.")
            .Matches("[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
            .Matches("[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula.")
            .Matches("[0-9]").WithMessage("La contraseña debe contener al menos un número.")
            .Matches("[^a-zA-Z0-9]").WithMessage("La contraseña debe contener al menos un carácter especial.");

        RuleFor(x => x._request.correo).NotEmpty().WithMessage("El campo correo no puede ser vacio")
                              .EmailAddress().WithMessage("El campo correo debe ser una dirección de correo electrónico válida.");

        RuleFor(x => x._request.nombre).NotEmpty().WithMessage("El campo nombre no puede ser vacio.")
            .Matches("^[^0-9]+$").WithMessage("El nombre no puede contener números.");

        RuleFor(x => x._request.apellido).NotEmpty().WithMessage("El campo apellido no puede ser vacio.")
            .Matches("^[^0-9]+$").WithMessage("El nombre no puede contener números.");

        RuleFor(x => x._request.preguntas_de_seguridad)
            .NotEmpty().WithMessage("La pregunta de seguridad no puede estar vacía.")
            .Length(4, 50).WithMessage("La pregunta de seguridad debe tener entre 4 y 50 caracteres.");

        RuleFor(x => x._request.preguntas_de_seguridad2)
            .NotEmpty().WithMessage("La pregunta de seguridad 2 no puede estar vacía.")
            .Length(4, 50).WithMessage("La pregunta de seguridad 2 debe tener entre 4 y 50 caracteres.");

        RuleFor(x => x._request.respuesta_de_seguridad)
            .NotEmpty().WithMessage("La respuestas de seguridad no puede estar vacía.")
            .Length(2, 50).WithMessage("La respuestas de seguridad debe tener entre 4 y 50 caracteres.");

        RuleFor(x => x._request.respuesta_de_seguridad2)
            .NotEmpty().WithMessage("La respuestas de seguridad 2 no puede estar vacía.")
            .Length(2, 50).WithMessage("La pregunta de seguridad 2 debe tener entre 4 y 50 caracteres.");

        RuleFor(x => x._request.rif)
            .NotEmpty().WithMessage("El RIF no puede estar vacío.")
            .Matches(@"^(J|G|V|E|P)-\d{8}$").WithMessage("El RIF debe tener el formato J|G|V|E|P-XXXXXXX, J|G|V|E|P-XXXXXXXX");
        //Este Matches dice que la cadena debe comenzar con la instancia J o G o V o E o P, en la segunda posicion el guion -, y luego de 6 a 7 digitos numericos
    }
}
