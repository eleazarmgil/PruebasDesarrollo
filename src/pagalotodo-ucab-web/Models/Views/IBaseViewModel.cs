using UCABPagaloTodoWeb.Models.Responses;

namespace UCABPagaloTodoWeb.Models.Views
{
    public interface IBaseViewModel
    {
        string obtenerUsuario();

        LoginDataModel obtenerLoginDataModel();
    }
}
