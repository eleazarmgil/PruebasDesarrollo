﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Application.Requests;

public class DetalleDePagoRequest
{
    public string? detalle { get; set; }
    public string? nombre { get; set; }
}
