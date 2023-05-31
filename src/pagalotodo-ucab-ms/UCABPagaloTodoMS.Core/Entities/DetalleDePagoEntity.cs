using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Core.Entities;

[ExcludeFromCodeCoverage]
public class DetalleDePagoEntity : BaseEntity
{
    public string? detalle { get; set; }
    public string? nombre { get; set; }

    //Relacion n a 1 con Pago
    public PagoEntity? pago { get; set; }
}
