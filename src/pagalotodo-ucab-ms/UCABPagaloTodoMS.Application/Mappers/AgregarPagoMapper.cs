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

            Id = entity.Id,

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
            //detalleDePago = new List<DetalleDePagoEntity>()

        };

       /* if (request.detalledepago != null) // reviso que la lista del request no este vacia
        {
            foreach (var detalle in request.detalledepago)

            //  toma cada detalle en mi request y lo guarda en su entidad detalle de opcion entity
            {
                var detalleEntity = new DetalleDePagoEntity()
                {
                   detalle = detalle.detalle,
                };
                entity.detalleDePago.Add(detalleEntity);
                // se llena la lista entidad con los elementos del request
            }
        }*/



        return entity;
    }
}
