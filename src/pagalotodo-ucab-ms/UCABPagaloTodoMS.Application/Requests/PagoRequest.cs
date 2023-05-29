using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Application.Requests;

public class PagoRequest
{
    public Double? monto { get; set; }
    public Guid? OpcionDePagoIdEntity { get; set; }

    public Guid? ConsumidorIdEntity { get; set; }
}
