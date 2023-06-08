using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Application.Requests;

public class ActualizarOpcionDePagoEstadoRequest
{
    public Guid? opciondepagoid { get; set; }

    public string? estado { get; set;}
    


}
