using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Responses;

[ExcludeFromCodeCoverage]
public class LoginUsuarioResponse
{
    public Guid Id { get; set; }
    public string? discriminator { get; set; }
}
