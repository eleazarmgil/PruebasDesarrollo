using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Responses;

[ExcludeFromCodeCoverage]
public class CambiarClaveUsuarioResponse
{
    public Guid Id { get; set; }
    public string? newpassword { get; set; }

}
