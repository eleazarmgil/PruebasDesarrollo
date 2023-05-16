using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class DetalleDeOpcionEntity : BaseEntity
    {
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
    }
}