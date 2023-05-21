using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class PagoEntity : BaseEntity
    {
        public Double? monto { get; set; }
        public DateOnly? nombre_completo { get; set; }

        //Relacion 1 a n con Servicio
        public ICollection<ServicioEntity>? servicio { get; set; }

        //Relacion n a 1 con OpcionDePago
        [ForeignKey("OpcionDePagoEntity")]
        public Guid opcionDePagoEntityId { get; set; }
        public OpcionDePagoEntity opcionDePago { get; set; } = new OpcionDePagoEntity();

        //Relacion 1 a n con DetalleDePago
        public ICollection<DetalleDePagoEntity>? detalleDePago { get; set; }
        
        //Relacion n a 1 con Consumidor
        [ForeignKey("ConsumidorEntity")]
        public Guid ConsumidorEntityId { get; set; }
        public ConsumidorEntity consumidor { get; set; } = new ConsumidorEntity();

        

        //Relacion n a 1 con Conciliacion
        [ForeignKey("ConciliacionEntity")]
        public Guid? ConciliacionEntityId { get; set; }
        public ConciliacionEntity? conciliacion { get; set; }


    }
}
