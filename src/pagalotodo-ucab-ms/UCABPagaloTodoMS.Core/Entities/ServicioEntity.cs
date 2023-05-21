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

        //Relacion n a 1 con Conciliacion
        [ForeignKey("ServicioEntity")]
        public Guid servicioEntityId { get; set; }
        public ServicioEntity servicio { get; set; }

        //Relacion n a 1 con Conciliacion
        [ForeignKey("PrestadorEntity")]
        public Guid prestadorEntityId { get; set; }
        public PrestadorEntity prestador { get; set; }
    }
}
