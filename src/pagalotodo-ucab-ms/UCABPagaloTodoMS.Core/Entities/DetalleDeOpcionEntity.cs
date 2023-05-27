namespace UCABPagaloTodoMS.Core.Entities;
public class DetalleDeOpcionEntity : BaseEntity
{
    public string? nombre { get; set; }
    public string? tipo_dato { get; set; }

    public int? cant_caracteres { get; set; }

    public string? formato { get; set; }

    public Guid OpcionDePagoEntityId { get; set; }

    //Relacion n a 1 con OpcionDePago
    public OpcionDePagoEntity opcionDePago { get; set; } = null!;
}