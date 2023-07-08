using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Responses;

public class ConsultarPagosConsumidorResponse
{
    public Guid id_pago { set; get; }
    public string? nombre_servicio { get; set; }
    public Double? monto { get; set; }
    public DateTime? fecha { get; set; }
 
}
