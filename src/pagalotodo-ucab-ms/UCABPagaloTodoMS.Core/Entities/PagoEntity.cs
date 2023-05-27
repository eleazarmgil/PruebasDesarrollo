namespace UCABPagaloTodoMS.Core.Entities;
public class PagoEntity : BaseEntity
{
    public Double? monto { get; set; }
    public DateTime? fecha { get; set; }

    public Guid? OpcionDePagoIdEntity { get; set; }

    //Relacion n a 1 con OpcionDePago
    public OpcionDePagoEntity OpcionDePago { get; set; } = null!;// opcion de pago debe existir primero

    //Relacion 1 a n con DetalleDePago
    public ICollection<DetalleDePagoEntity>? detalleDePago { get; set; }

    public Guid? ConsumidorIdEntity { get; set; }

    //Relacion n a 1 con Consumidor
    public ConsumidorEntity Consumidor { get; set; } = null!;

  


}
