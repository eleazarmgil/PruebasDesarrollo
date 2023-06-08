using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Responses;

[ExcludeFromCodeCoverage]
public class DetalleDeOpcionDePagoResponse
{
    public string? nombre { get; set; }
    public string? formato { get; set; }

}
