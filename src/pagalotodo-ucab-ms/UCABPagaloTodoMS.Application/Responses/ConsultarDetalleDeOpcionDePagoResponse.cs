using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Responses;

[ExcludeFromCodeCoverage]
public class ConsultarDetalleDeOpcionDePagoResponse
{
    public string? nombre { get; set; }
    public string? tipo_dato { get; set; }

    public int? cant_caracteres { get; set; }

    public string? formato { get; set; }
}
