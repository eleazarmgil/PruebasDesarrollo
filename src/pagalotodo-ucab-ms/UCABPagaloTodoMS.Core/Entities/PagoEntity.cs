namespace UCABPagaloTodoMS.Core.Entities;
public class PagoEntity : BaseEntity
{
    public Double? monto { get; set; }
    public DateOnly? fecha { get; set; }

    //Relacion n a 1 con OpcionDePago
    public OpcionDePagoEntity opcionDePago { get; set; } = new OpcionDePagoEntity();// opcion de pago debe existir primero

    //Relacion 1 a n con DetalleDePago
    public ICollection<DetalleDePagoEntity>? detalleDePago { get; set; }

    //Relacion n a 1 con Consumidor
    public ConsumidorEntity consumidor { get; set; } = new ConsumidorEntity();

  


}
