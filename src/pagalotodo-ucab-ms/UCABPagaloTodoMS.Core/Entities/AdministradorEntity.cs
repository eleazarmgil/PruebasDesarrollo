﻿namespace UCABPagaloTodoMS.Core.Entities;
public class AdministradorEntity : UsuarioEntity
{
    //Relacion 1 a n con Conciliacion
    public ICollection<ConciliacionEntity>? conciliacion { get; set; }
}