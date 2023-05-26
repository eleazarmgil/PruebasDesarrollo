﻿using UCABPagaloTodoMS.Core.Entities;

namespace UCABPagaloTodoMS.Application.Responses;

public class ConsultarServicioEmpresaResponse
{

    public string? nombre_prestador { get; set; }
    public string? nombre_empresa { get; set; }
    public Guid id_servicio { get; set; }
    public string? nombre { get; set; }
    public string? descripcion { get; set; }
    public double? monto { get; set; }

    public Guid id_prestador { get; set; }


}

