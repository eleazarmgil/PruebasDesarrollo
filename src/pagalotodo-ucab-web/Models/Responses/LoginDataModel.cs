namespace UCABPagaloTodoWeb.Models.Responses
{
    public class LoginDataModel
    {
        public Guid id { get; set; }
        public string? discriminator { get; set; }
        public string? usuario { get; set; }
    }
}
