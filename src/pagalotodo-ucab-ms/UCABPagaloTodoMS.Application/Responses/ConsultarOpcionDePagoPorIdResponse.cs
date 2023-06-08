using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Responses;

[ExcludeFromCodeCoverage]
public class ConsultarOpcionDePagoPorIdResponse
{
    public Guid? Id { get; set; }
    public string? nombre { get; set; }
    public string? estatus { get; set; }
    public List<DetalleDeOpcionDePagoResponse>? detalledeopciondepago { get; set; }
}
