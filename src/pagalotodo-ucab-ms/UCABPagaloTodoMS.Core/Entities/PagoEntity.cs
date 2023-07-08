using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Core.Entities;
[ExcludeFromCodeCoverage]
public class PagoEntity : BaseEntity
{
    public Double? monto { get; set; }
    public DateTime? fecha { get; set; }

    public Guid? opcionDePagoId { get; set; }

    //Relacion n a 1 con OpcionDePago
    public OpcionDePagoEntity OpcionDePago { get; set; } = null!;// opcion de pago debe existir primero

    //Relacion 1 a n con DetalleDePago
    public ICollection<DetalleDePagoEntity>? detalleDePago { get; set; }

    public Guid? ConsumidorId { get; set; }

    //Relacion n a 1 con Consumidor
    public ConsumidorEntity Consumidor { get; set; } = null!;

    public Guid? ServicioEntityId { get; set; }
}
