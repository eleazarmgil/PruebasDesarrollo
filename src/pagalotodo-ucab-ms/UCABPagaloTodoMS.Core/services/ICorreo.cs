
namespace UCABPagaloTodoMS.Core.Services
{
    public interface ICorreo
    {
        void EnviaCorreoUsuario(string correo_para_quien, string asunto_del_correo, string cuerpo_del_mensaje);
    }
}
