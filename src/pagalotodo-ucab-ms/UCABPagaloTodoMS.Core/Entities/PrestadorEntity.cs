namespace UCABPagaloTodoMS.Core.Entities;
public class PrestadorEntity : UsuarioEntity
{
    public int? rif { set; get; }
    public string? nombre_empresa { set; get; }

    //Relacion 1 a n con DetalleDePago
    public ICollection<ServicioEntity>? servicios { get; set; }
    //Relacion n a 1 con OpcionDePago
    public OpcionDePagoEntity? opcion_de_pago { get; set; }
}
