using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class PrestadorEntity : UsuarioEntity
    {
        public List<ServicioEntity> servicio = new List<ServicioEntity>();
        public List<OpcionDePagoEntity> opcion_de_pago = new List<OpcionDePagoEntity>();


        public int? rif { set; get; }
        public string? nombre_empresa { set; get; }
        public bool? estado { set; get; }
    }
}
