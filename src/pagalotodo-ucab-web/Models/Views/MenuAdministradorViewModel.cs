using UCABPagaloTodoWeb.Models.Responses;

namespace UCABPagaloTodoWeb.Models.Views
{
    public class MenuAdministradorViewModel : IBaseViewModel
    {
        private LoginDataModel? loginDataModel { get; set; }

        public MenuAdministradorViewModel(LoginDataModel _loginDataModel) 
        {
            loginDataModel = _loginDataModel;
        }
        public string obtenerUsuario()
        {
            return loginDataModel.usuario;
        }
        public LoginDataModel obtenerLoginDataModel() => loginDataModel;
    }
}
