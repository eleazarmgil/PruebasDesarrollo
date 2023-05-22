namespace UCABPagaloTodoMS.Core.Entities;
public class DetalleDeOpcionEntity : BaseEntity
{
    public string? nombre { get; set; }
    public string? descripcion { get; set; }

    //Relacion n a 1 con OpcionDePago
    public OpcionDePagoEntity opcionDePago { get; set; } = new OpcionDePagoEntity();
}