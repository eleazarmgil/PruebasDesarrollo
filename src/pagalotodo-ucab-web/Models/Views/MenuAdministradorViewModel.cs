using UCABPagaloTodoWeb.Models.Responses;

namespace UCABPagaloTodoWeb.Models.Views
{
    public class MenuAdministradorViewModel : BaseViewModel
    {
        public LoginDataModel? loginDataModel { get; set; }

        public string obtenerUsuario()
        {
            return loginDataModel.usuario;
        }
        public LoginDataModel obtenerLoginDataModel() => loginDataModel;
    }
}
