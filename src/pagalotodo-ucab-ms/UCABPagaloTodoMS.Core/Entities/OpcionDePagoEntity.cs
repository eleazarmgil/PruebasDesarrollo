namespace UCABPagaloTodoMS.Core.Entities;
public class OpcionDePagoEntity : BaseEntity
{
    public string? nombre { get; set; }
    public string? estatus { get; set; }

    public Guid? ServicioEntityId { get; set; }

    public ServicioEntity servicio { get; set; } = null!;

    //Relacion 1 a n con DetalleDeOpcion
    public ICollection<DetalleDeOpcionEntity>? detalleDeOpcion { get; set; }

    //Relacion 1 a n con Pago
    public ICollection<PagoEntity>? pagos { get; set; }
}
