﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Application.Responses
{
    public class CambiarClaveUsuarioResponse
    {
        public Guid Id { get; set; }
        public string? newpassword { get; set; }

    }
}
