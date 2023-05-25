namespace UCABPagaloTodoMS.Core.Entities;
public class ConsumidorEntity : UsuarioEntity
{
    public int? ci { set; get; }

    //Relacion 1 a n con Pago
    public ICollection<PagoEntity>? Pago { get; set; }
}
