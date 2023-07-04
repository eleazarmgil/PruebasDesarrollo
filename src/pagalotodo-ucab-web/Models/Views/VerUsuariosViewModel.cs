using System.Runtime.CompilerServices;
using UCABPagaloTodoWeb.Models.Responses;

namespace UCABPagaloTodoWeb.Models.Views
{
    public class VerUsuariosViewModel : IBaseViewModel
    {
        private LoginDataModel? loginDataModel { get; set; }
        private ConsultarUsuariosResponse? consultarUsuarioResponse { get; set; }

        public string obtenerUsuario() => loginDataModel.usuario;

        public LoginDataModel obtenerLoginDataModel() => loginDataModel;

        public UsuarioDataModel[] obtenerUsuarios() => consultarUsuarioResponse.data;

        public VerUsuariosViewModel(LoginDataModel _loginDataModel, ConsultarUsuariosResponse _consultarUsuarioResponse) {
            loginDataModel= _loginDataModel;
            consultarUsuarioResponse= _consultarUsuarioResponse;
        }
    }
}
