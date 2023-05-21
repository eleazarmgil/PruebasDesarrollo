using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class ConciliacionEntity : BaseEntity
    {
        public DateTime? fecha { set; get; }
        //public Dictionary<string, string>? archivo { set; get; }

        //Relacion 1 a n con Pago
        public ICollection<PagoEntity>? pagos { get; set; }

        //Relacion n a 1 con Administrador
        [ForeignKey("AdministradorEntity")]
        public Guid AdministradorEntityId { get; set; }
        public AdministradorEntity administrador { get; set; }

    }
}