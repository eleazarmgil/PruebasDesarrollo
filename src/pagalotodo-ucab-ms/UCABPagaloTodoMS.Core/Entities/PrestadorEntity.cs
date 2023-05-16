﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class PrestadorEntity : UsuarioEntity
    {
        public ServicioEntity servicio { get; set; }
        public OpcionDePagoEntity opcion_de_pago { get; set; }


        public int? rif { set; get; }
        public string? nombre_empresa { set; get; }
        public bool? estado { set; get; }
    }
}