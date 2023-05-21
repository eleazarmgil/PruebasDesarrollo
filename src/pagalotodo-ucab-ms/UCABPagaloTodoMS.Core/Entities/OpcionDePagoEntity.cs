using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class OpcionDePagoEntity : BaseEntity
    {
        public string? nombre { get; set; }
        public int? estatus { get; set; }
        
        //Relacion 1 a n con DetalleDeOpcion
        public ICollection<DetalleDeOpcionEntity>? detalleDeOpcion { get; set; }

        //Relacion 1 a n con Pago
        public ICollection<PagoEntity>? pagos { get; set; }
    }
}