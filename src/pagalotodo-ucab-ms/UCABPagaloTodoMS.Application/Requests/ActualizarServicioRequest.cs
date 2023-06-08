using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Requests;

[ExcludeFromCodeCoverage]
public class ActualizarServicioRequest
{
    public Guid Id { get; set; }
    public string? nombre { get; set; }
    public string? descripcion { get; set; }
    public double? monto { get; set; }
}
