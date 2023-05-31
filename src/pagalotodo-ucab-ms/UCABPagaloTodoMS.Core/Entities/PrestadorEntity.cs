using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Core.Entities;

[ExcludeFromCodeCoverage]
public class PrestadorEntity : UsuarioEntity
{
    public string? rif { set; get; }
    public string? nombre_empresa { set; get; }

    //Relacion 1 a n con DetalleDePago
    public ICollection<ServicioEntity>? servicios { get; set; }
 
}
