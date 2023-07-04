namespace UCABPagaloTodoWeb.Models.Responses
{
    public class LoginDataModel
    {
        public Guid id { get; set; }
        public string? discriminator { get; set; }
        public string? usuario { get; set; }

        public LoginDataModel()
        {
            id= Guid.NewGuid();
            discriminator= string.Empty;
            usuario= string.Empty;
        }
        public LoginDataModel(Guid id, string? discriminator, string? usuario)
        {
            this.id = id;
            this.discriminator = discriminator;
            this.usuario = usuario;
        }
    }
}
