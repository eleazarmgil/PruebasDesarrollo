using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Application.Responses;

public class ConsultarDetalleDeOpcionDePagoResponse
{
    public string? nombre { get; set; }
    public string? tipo_dato { get; set; }

    public int? cant_caracteres { get; set; }

    public string? formato { get; set; }
}
