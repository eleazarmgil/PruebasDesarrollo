using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Responses;

[ExcludeFromCodeCoverage]
public class ConsultarServiciosResponse
{
    public string? nombre_prestador { get; set; }
    public Guid id_servicio { get; set; }
    public string? nombre { get; set; }
    public string? descripcion { get; set; }
    public double? monto { get; set; }
    public Guid id_prestador { get; set; }

}

