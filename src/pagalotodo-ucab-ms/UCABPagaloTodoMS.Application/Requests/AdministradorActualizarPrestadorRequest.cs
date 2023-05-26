﻿namespace UCABPagaloTodoMS.Application.Requests;
public class AdministradorActualizarPrestadorRequest
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
    public int? rif { set; get; }
    public string? nombre_empresa { set; get; }
    public bool? estado { set; get; }
}