using UCABPagaloTodoWeb.Models.Responses;

namespace UCABPagaloTodoWeb.Models.Views
{
    public class ConsultarUsuariosViewModel : BaseViewModel
    {
        public LoginDataModel? loginDataModel { get; set; }
        public ConsultarUsuarioResponse? consultarUsuarioResponse { get; set; }

        public string obtenerUsuario() => loginDataModel.usuario;
    }
}
