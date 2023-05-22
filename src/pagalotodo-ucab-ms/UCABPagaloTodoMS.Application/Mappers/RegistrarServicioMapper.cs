using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                id = entity.id,
                nombre = entity.nombre,
               
            };
            return response;
        }
        public static ServicioEntity MapRequestEntity(RegistrarServicioRequest request)
        {
            var entity = new ServicioEntity()
            {
                id = request.id,
                nombre = request.nombre,
            };
            return entity;
        }
    }
}
