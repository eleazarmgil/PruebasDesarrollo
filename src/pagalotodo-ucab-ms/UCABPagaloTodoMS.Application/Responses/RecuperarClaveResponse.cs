using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Responses;

[ExcludeFromCodeCoverage]
public class RecuperarClaveResponse
{
    public Guid Id { get; set; }
    public string? password { get; set; }
}
