using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class PrestadorEntity : UsuarioEntity
    {
        public int? rif { set; get; }
        public string? nombre_empresa { set; get; }
        public bool? estado { set; get; }

        //Relacion 1 a n con DetalleDePago
        public ICollection<ServicioEntity>? servicios { get; set; }
    }
}
