﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class AdministradorEntity : UsuarioEntity
    {
        public ConciliacionEntity? conciliacion;
    }
}