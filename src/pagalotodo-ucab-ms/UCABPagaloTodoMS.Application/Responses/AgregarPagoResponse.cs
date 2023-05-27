using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Application.Responses;

public class AgregarPagoResponse
{
    public Guid? OpcionDePago_Id { get; set; }
    public List<DetalleDePagoResponse>? DetalleDePago { get; set; }
}
