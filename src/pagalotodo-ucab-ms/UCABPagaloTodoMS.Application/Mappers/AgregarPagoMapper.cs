using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Mappers;

public class AgregarPagoMapper
{
    public static AgregarPagoResponse MapEntityAResponse(PagoEntity entity)
    {
        var response = new AgregarPagoResponse()
        {

            OpcionDePagoIdEntity = entity.opcionDePagoId,

        };

        return response;
    }

    public static PagoEntity MapRequestEntity(AgregarPagoRequest request)
    {
        var entity = new PagoEntity() 
        {
            
            monto = request.monto,
            fecha = DateTime.Now,
            opcionDePagoId = request.OpcionDePagoIdEntity,
            ConsumidorId = request.ConsumidorIdEntity,

        };
       


        return entity;
    }
}
