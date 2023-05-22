namespace UCABPagaloTodoMS.Application.Requests;
public class CambiarClaveUsuarioRequest
{
    public string? usuario { set; get; }
    public string? password { set; get; }
    public string? newpassword { set; get; }

}
