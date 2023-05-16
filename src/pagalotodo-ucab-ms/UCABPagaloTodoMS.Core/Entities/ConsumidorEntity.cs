using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class ConsumidorEntity : UsuarioEntity
    {
        public PagoEntity PagoEntity { set; get; }
        public int? ci { set; get; }

    }
}
