using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Application.Responses;

public class ConsultarOpPagoServicioResponse
{
    public Guid id_opcion_pago { set; get; }
    public string? nombre_opcion_pago {  get; set; }
}
