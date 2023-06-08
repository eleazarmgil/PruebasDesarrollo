using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Responses;

[ExcludeFromCodeCoverage]
public class AgregarOpcionPagoResponse
{
    public string? nombre { get; set; }
    public string? estatus { get; set; }

    public Guid? ServicioEntityId { get; set; }

}
