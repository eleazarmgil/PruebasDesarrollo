﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class UsuarioEntity : BaseEntity
    {
        public string? usuario { get; set; }
        public string? password { get; set; }
        public string? correo { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? preguntas_de_seguridad { set; get; }
        public string? preguntas_de_seguridad2 { set; get; }
        public string? respuesta_de_seguridad { set; get; }
        public string? respuesta_de_seguridad2 { set; get; }

    }
}
