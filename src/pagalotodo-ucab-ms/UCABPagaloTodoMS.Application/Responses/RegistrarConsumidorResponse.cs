﻿namespace UCABPagaloTodoMS.Application.Responses;

public class RegistrarConsumidorResponse
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
    public int? ci { set; get; }


}
