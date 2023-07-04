using UCABPagaloTodoWeb.Models.Responses;

namespace UCABPagaloTodoWeb.Models.Views
{
    public class ActualizarConsumidorViewModel:IBaseViewModel
    {
        private LoginDataModel loginDataModel {  get; set; }

        public ActualizarConsumidorViewModel(LoginDataModel _loginDataModel)
        {
            loginDataModel = _loginDataModel; 
        }

        public LoginDataModel obtenerLoginDataModel() => loginDataModel;

        public string obtenerUsuario() => loginDataModel.usuario;
    }
}
