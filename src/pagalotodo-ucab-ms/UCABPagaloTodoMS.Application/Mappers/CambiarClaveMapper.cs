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
    public static class CambiarClaveMapper
    {
        public static CambiarClaveUsuarioResponse MapEntityAResponse(UsuarioEntity entity)
        {
            var response = new CambiarClaveUsuarioResponse()
            {
                Id = entity.Id,
            };
            return response;
        }

        public static UsuarioEntity MapRequestEntity(CambiarClaveUsuarioRequest request)
        {
            var entity = new UsuarioEntity()
            {
                usuario = request.usuario,
                password = request.password,
            };
            return entity;
        }
    }
}
