namespace UCABPagaloTodoMS.Core.Entities;
public class ConciliacionEntity : BaseEntity
{
    public DateTime? fecha { set; get; }

    //Relacion 1 a n con Pago
    public ICollection<PagoEntity>? pagos { get; set; }

    //Relacion n a 1 con Administrador
    public AdministradorEntity administrador { get; set; } = new AdministradorEntity();
}