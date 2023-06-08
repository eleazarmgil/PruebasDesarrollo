using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Requests;
[ExcludeFromCodeCoverage]
public class RecuperarClaveRequest
{
    public string? usuario { get; set; }
    public string? respuesta_de_seguridad { set; get; }
    public string? respuesta_de_seguridad2 { set; get; }
}
