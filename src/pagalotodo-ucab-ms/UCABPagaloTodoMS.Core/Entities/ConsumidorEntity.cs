using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class ConsumidorEntity : UsuarioEntity
    {
        public int? ci { set; get; }

        //Relacion n a 1 con Pago
        [ForeignKey("PagoEntity")]
        public Guid pagoEntityId { get; set; }
        public PagoEntity pago { get; set; }

    }
}
