using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Mappers;
public class RegistrarPrestadorMapper
{
    public static RegistrarPrestadorResponse MapEntityAResponse(PrestadorEntity entity)
    {
        var response = new RegistrarPrestadorResponse()
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
            rif = entity.rif,
            nombre_empresa = entity.nombre_empresa,
            estado = entity.estado,
        };
        return response;
    }

    public static PrestadorEntity MapRequestEntity(RegistrarPrestadorRequest request)
    {
        var entity = new PrestadorEntity()
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
            rif = request.rif,
            nombre_empresa = request.nombre_empresa,
            estado = true,
        };
        return entity;
    }
}
