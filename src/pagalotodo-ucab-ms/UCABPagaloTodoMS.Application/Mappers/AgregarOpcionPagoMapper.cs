using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Mappers;
public class AgregarOpcionPagoMapper
{
    public static AgregarOpcionPagoResponse MapEntityAResponse(OpcionDePagoEntity entity)
    {
        var response = new AgregarOpcionPagoResponse()
        {
            nombre = entity.nombre,
            estatus = entity.estatus,
            ServicioEntityId = entity.ServicioEntityId,


};
        return response;
    }

    public static OpcionDePagoEntity MapRequestEntity(AgregarOpcionPagoRequest request)
    {
        var entity = new OpcionDePagoEntity() // inicializo una nueva opcion de pago
        {
            // Relleno los atributos de opciion de pago segun mi request
            nombre = request.nombre,
            estatus = "Proximamente",
            ServicioEntityId = request.ServicioEntityId,
            detalleDeOpcion = new List<DetalleDeOpcionEntity>() //creo una nueva lista de detalle de opcion

        };
            if (request.detalleDeOpcion != null) // reviso que la lista del request no este vacia
        {
            foreach (var detalle in request.detalleDeOpcion) 
                
                //  toma cada detalle en mi request y lo guarda en su entidad detalle de opcion entity
            {
                var detalleEntity = new DetalleDeOpcionEntity()
                {
                    nombre = detalle.nombre,
                    tipo_dato = detalle.tipo_dato,
                    cant_caracteres = detalle.cant_caracteres,
                    formato = detalle.formato,
                    OpcionDePagoEntityId = entity.Id
                };
                entity.detalleDeOpcion.Add(detalleEntity);
                // se llena la lista entidad con los elementos del request
            }
        }

    
        return entity;
    }
}
