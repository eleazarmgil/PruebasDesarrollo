
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Responses;

public class AgregarOpcionPagoResponse
{
    public string? nombre { get; set; }
    public string? estatus { get; set; }

    public Guid? ServicioEntityId { get; set; }

}
