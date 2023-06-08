using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Core.Entities;
[ExcludeFromCodeCoverage]
public class ConsumidorEntity : UsuarioEntity
{
    public string? ci { set; get; }

    //Relacion 1 a n con Pago
    public ICollection<PagoEntity>? Pago { get; set; }
}
