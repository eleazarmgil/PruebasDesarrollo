using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class DetalleDeOpcionEntity : BaseEntity
    {
        public string? nombre { get; set; }
        public string? descripcion { get; set; }

        //Relacion n a 1 con OpcionDePago
        [ForeignKey("OpcionDePagoEntity")]
        public Guid opcionDePagoEntityId { get; set; }
        public OpcionDePagoEntity opcionDePago { get; set; }
    }
}