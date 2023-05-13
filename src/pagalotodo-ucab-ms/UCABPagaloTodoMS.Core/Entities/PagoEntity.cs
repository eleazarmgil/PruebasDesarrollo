using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class PagoEntity
    {
        public List<DetalleDePagoEntity>? detalle_de_pago = new List<DetalleDePagoEntity>();

        public string? id { get; set; }
        public Double? monto { get; set; }
        public DateOnly? nombre_completo { get; set; }
    }
}
