
using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Requests;
[ExcludeFromCodeCoverage]
public class DetalleDeOpcionRequest
{
    public string? nombre { get; set; }
    public formato_dato? formato { get; set; }

    public enum formato_dato
    {
        Cedula,//0
        Telefono,//1
        Correo,//2
        ReferenciaPago,//3
        Alfabetico,//4
        Alfanumerico,//5
        Numerico,//6
        Decimal,//7
    }

    // este enum funciona colocando la posicion del formato detro de el ejemplo: quiero que sea tipo cedula coloco la posicion 0 


}
