using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Requests;

[ExcludeFromCodeCoverage]
public class ConsultarPrestadorRequest
{
    public string? rif { set; get; }
}
