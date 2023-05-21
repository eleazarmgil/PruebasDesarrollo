using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class ServicioEntity : BaseEntity
    {
        public string? nombre { set; get; }
        public string? descripcion { set; get; }
        public double? monto { set; get; }

        //Relacion 1 a n con Pago
        public ICollection<PagoEntity>? pagos { get; set; }

        //Relacion n a 1 con Conciliacion
        [ForeignKey("PrestadorEntity")]
        public Guid prestadorEntityId { get; set; }
        public PrestadorEntity prestador { get; set; }
    }
}
