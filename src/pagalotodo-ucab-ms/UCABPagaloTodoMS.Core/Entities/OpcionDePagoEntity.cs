using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class OpcionDePagoEntity : BaseEntity
    {
        public List<PagoEntity> pago = new List<PagoEntity>();
        public List<DetalleDeOpcionEntity> detalle_de_opcion = new List<DetalleDeOpcionEntity>();

        public string? nombre { get; set; }
        public int? estatus { get; set; }

    }
}
