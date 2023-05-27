using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Application.Responses;

public class ConsultarOpcionDePagoPorIdResponse
{
    public Guid? Id { get; set; }
    public string? nombre { get; set; }
    public string? estatus { get; set; }
}
