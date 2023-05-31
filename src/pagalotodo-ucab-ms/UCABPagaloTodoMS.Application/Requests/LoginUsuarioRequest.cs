using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Requests;

[ExcludeFromCodeCoverage]
public class LoginUsuarioRequest
{
    public string? usuario {set;get;}
    public string? password { set;get;}
}
