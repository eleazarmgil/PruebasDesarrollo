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
        public PagoEntity? PagoEntity { set; get; }
        public int? ci { set; get; }

        //Relacion 1 a n con Pago
        public ICollection<PagoEntity>? Pago { get; set; }
    }
}
