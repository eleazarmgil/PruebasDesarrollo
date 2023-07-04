
namespace UCABPagaloTodoMS.Application.Responses;

public class ConsultarUsuarioIdResponse
{
    public Guid id_usuario { get; set; }
    public string? usuario { get; set; }
    public string? ci { get; set; }
    public string? rif { get; set; }
    public string? nombre_empresa { get; set; }
    public string? correo { get; set; }
    public string? nombre { get; set; }

    public bool? estado { set; get; }

    public string? Discriminator { set; get; }
}
