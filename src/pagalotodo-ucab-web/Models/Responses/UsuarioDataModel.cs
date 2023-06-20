namespace UCABPagaloTodoWeb.Models.Responses
{
    public class UsuarioDataModel
    {
        public Guid id_usuario { get; set; }
        public string? usuario { get; set; }
        public string? correo { get; set; }
        public string? nombre { get; set; }
        public bool? estado { set; get; }
        public string? Discriminator { set; get; }
    }
}
