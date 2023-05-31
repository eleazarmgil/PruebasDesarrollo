using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Requests;

[ExcludeFromCodeCoverage]
public class ValoresRequest
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Identificacion { get; set;}
}
