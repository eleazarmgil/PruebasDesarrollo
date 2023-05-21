namespace UCABPagaloTodoMS.Core.Entities;

public class PagoEntity : BaseEntity
{
    public Double? monto { get; set; }
    public DateOnly? nombre_completo { get; set; }

    //Relacion n a 1 con Servicio
    public ServicioEntity servicio { get; set; } = new ServicioEntity();   

    //Relacion n a 1 con OpcionDePago
    public OpcionDePagoEntity opcionDePago { get; set; } = new OpcionDePagoEntity();

    //Relacion 1 a n con DetalleDePago
    public ICollection<DetalleDePagoEntity>? detalleDePago { get; set; }
    
    //Relacion n a 1 con Consumidor
    public ConsumidorEntity consumidor { get; set; } = new ConsumidorEntity();

    //Relacion n a 1 con Conciliacion
    public ConciliacionEntity? conciliacion { get; set; }


}
