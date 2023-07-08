using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Application.Responses;

public class ConsultarPagosPrestadorResponse
{
    public Guid id_pago { set; get; }
    public string? nombre_servicio { get; set; }
    public Double? monto { get; set; }
    public DateTime? fecha { get; set; }
}
