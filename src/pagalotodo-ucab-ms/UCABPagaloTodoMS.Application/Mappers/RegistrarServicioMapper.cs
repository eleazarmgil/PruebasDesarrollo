using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Mappers
{
    public class RegistrarServicioMapper
    {
        public static RegistrarServicioResponse MapEntityAResponse(ServicioEntity entity)
        {
            var response = new RegistrarServicioResponse()
            {
                PrestadorEntityId = entity.PrestadorEntityId,
                nombre = entity.nombre,
                descripcion = entity.descripcion,
                monto = entity.monto,

    };
            return response;
        }
        public static ServicioEntity MapRequestEntity(RegistrarServicioRequest request)
        {
            var entity = new ServicioEntity()
            {
                nombre = request.nombre,
                descripcion = request.descripcion,
                monto = request.monto,
                PrestadorEntityId = request.PrestadorEntityId,
            };
            return entity;
        }
    }
}
