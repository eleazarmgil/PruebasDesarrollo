using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class PagoEntity : BaseEntity
    {
        public DetalleDePagoEntity DetalleDePagoEntity { get; set; }
        public Double? monto { get; set; }
        public DateOnly? nombre_completo { get; set; }
    }
}
