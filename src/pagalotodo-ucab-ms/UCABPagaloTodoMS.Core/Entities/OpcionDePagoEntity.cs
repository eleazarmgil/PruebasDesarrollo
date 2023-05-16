﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class OpcionDePagoEntity : BaseEntity
    {
        public PagoEntity PagoEntity { get; set; }
        public DetalleDeOpcionEntity DetalleDeOpcionEntity { get; set; }

        public string? nombre { get; set; }
        public int? estatus { get; set; }

    }
}