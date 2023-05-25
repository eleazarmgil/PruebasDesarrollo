namespace UCABPagaloTodoMS.Core.Entities;
public class ServicioEntity : BaseEntity

{
    public string? nombre { set; get; }
    public string? descripcion { set; get; }
    public double? monto { set; get; }

    public Guid PrestadorEntityId { get; set; }

    //Relacion 1 a n con Pago
    public ICollection<PagoEntity>? pago { get; set; }

    //Relacion n a 1 con Conciliacion
    public PrestadorEntity prestador { get; set; } = null!;

    
}
