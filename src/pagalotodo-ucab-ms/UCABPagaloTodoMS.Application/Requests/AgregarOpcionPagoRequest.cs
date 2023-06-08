using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Requests;
[ExcludeFromCodeCoverage]
public class AgregarOpcionPagoRequest
{
    public string? nombre { get; set; }

    public Guid? ServicioEntityId { get; set; }

    public List<DetalleDeOpcionRequest>? detalleDeOpcion { get; set; } 


}
