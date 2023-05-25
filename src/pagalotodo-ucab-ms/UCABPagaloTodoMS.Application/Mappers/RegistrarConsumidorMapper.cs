using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Mappers;
public class RegistrarConsumidorMapper
{
    public static RegistrarConsumidorResponse MapEntityAResponse( ConsumidorEntity entity)
    {
        var response = new RegistrarConsumidorResponse()
        {
            usuario = entity.usuario,
            password = entity.password,
            correo = entity.correo,
            nombre = entity.nombre,
            apellido = entity.apellido,
            preguntas_de_seguridad = entity.preguntas_de_seguridad,
            preguntas_de_seguridad2 = entity.preguntas_de_seguridad2,
            respuesta_de_seguridad = entity.respuesta_de_seguridad,
            respuesta_de_seguridad2 = entity.respuesta_de_seguridad2,   
            ci = entity.ci,
            estado = entity.estado,
        };
        return response;
    }

    public static ConsumidorEntity MapRequestEntity( RegistrarConsumidorRequest request)
    {
        var entity = new ConsumidorEntity()
        {
            usuario = request.usuario,
            password = request.password,
            correo = request.correo,
            nombre = request.nombre,
            apellido = request.apellido,
            preguntas_de_seguridad = request.preguntas_de_seguridad,
            preguntas_de_seguridad2 = request.preguntas_de_seguridad2,
            respuesta_de_seguridad = request.respuesta_de_seguridad,
            respuesta_de_seguridad2 = request.respuesta_de_seguridad2,
            ci = request.ci,
            estado = true,
        };
        return entity;
    }
}
