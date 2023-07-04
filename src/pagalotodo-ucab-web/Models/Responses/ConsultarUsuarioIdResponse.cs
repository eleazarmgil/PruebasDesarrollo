using UCABPagaloTodoWeb.Models.Responses.Data;
namespace UCABPagaloTodoWeb.Models.Responses
{
    public class ConsultarUsuarioIdResponse
    {
        public ActualizarUsuarioDataModel[]? data { get; set; }
        public string? operationId { get; set; }
        public string? operationName { get; set; }

    }
}
