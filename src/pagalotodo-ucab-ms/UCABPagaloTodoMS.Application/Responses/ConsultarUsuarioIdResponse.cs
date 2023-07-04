
namespace UCABPagaloTodoMS.Application.Responses;

public class ConsultarUsuarioIdResponse
{
    public string? Discriminator { set; get; }
    public bool? estado { set; get; }
    public Guid id_usuario { get; set; }
    public string? nombre { get; set; }
    public string? usuario { get; set; }
    public string? correo { get; set; }
    public string? ci { get; set; }
    public string? rif { get; set; }
}
