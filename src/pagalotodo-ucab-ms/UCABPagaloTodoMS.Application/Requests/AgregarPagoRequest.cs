

namespace UCABPagaloTodoMS.Application.Requests;

public class AgregarPagoRequest
{
    public Double? monto { get; set; }
    public Guid OpcionDePago_Id { get; set; }

    public Guid Consumidor_Id { get; set; }

    public List<DetalleDePagoRequest>? DetalleDePago { get; set; }
    


}
