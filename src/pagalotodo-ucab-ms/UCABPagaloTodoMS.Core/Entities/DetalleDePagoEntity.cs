using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class DetalleDePagoEntity : BaseEntity
    {
        public string? detalle { get; set; }
        public string? nombre { get; set; }

        //Relacion n a 1 con Pago
        public PagoEntity pago { get; set; } = new PagoEntity();
    }
}
