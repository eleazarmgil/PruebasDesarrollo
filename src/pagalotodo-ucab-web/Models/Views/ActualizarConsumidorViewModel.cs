using UCABPagaloTodoWeb.Models.Responses;
using UCABPagaloTodoWeb.Models.Responses.Data;

namespace UCABPagaloTodoWeb.Models.Views
{
    public class ActualizarConsumidorViewModel:IBaseViewModel
    {
        private LoginDataModel loginDataModel {  get; set; }

        public ActualizarUsuarioDataModel actualizarUsuarioIdResponse { get; set; }

		public ActualizarConsumidorViewModel()
		{
			loginDataModel = new LoginDataModel();
			actualizarUsuarioIdResponse = new ActualizarUsuarioDataModel();
		}
		public ActualizarConsumidorViewModel(LoginDataModel _loginDataModel, ActualizarUsuarioDataModel _actualizarUsuarioIdResponse)
        {
            loginDataModel = _loginDataModel;
            actualizarUsuarioIdResponse = _actualizarUsuarioIdResponse;
        }
        
        public LoginDataModel obtenerLoginDataModel() => loginDataModel;

        public string obtenerUsuario() => loginDataModel.usuario;
    }
}
