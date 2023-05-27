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
            OpcionDePago_Id = entity.OpcionDePagoIdEntity,
            DetalleDePago = new List<DetalleDePagoResponse>()
        };

        return response;
    }

    public static PagoEntity MapRequestEntity(AgregarPagoRequest request)
    {
        var entity = new PagoEntity() 
        {

            
            OpcionDePagoIdEntity = request.OpcionDePago_Id,
           
        };

        return entity;
    }
}
