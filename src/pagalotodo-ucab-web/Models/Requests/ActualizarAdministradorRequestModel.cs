namespace UCABPagaloTodoWeb.Models.Requests
{
    public class ActualizarAdministradorRequestModel
    {
        public Guid Id { get; set; }
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
