using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Requests;
[ExcludeFromCodeCoverage]
public class AgregarPagoRequest
{
    public Double? monto { get; set; }
    public Guid? OpcionDePagoIdEntity { get; set; }

    public Guid? ConsumidorIdEntity { get; set; }

    public List<DetalleDePagoRequest>? detalledepago { get; set; }
}
