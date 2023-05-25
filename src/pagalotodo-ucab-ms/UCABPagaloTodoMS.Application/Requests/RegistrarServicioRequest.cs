namespace UCABPagaloTodoMS.Application.Requests;
public class RegistrarServicioRequest
{
    public Guid PrestadorEntityId { get; set; }
    public string? nombre { get; set; }

    public string? descripcion { set; get; }
    public double? monto { set; get; }
}
