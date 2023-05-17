using System.Net.Mail;

namespace UCABPagaloTodoMS.Infrastructure.Correo
{
    public class EnviarCorreo
    {
        public void EnviaCorreoUsuario(string correo_para_quien, string asunto_del_correo, string cuerpo_del_mensaje)
        {
            MailMessage mensaje = new MailMessage("pagalotodo2023@gmail.com", correo_para_quien, asunto_del_correo, cuerpo_del_mensaje);
            SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587); //Creo la variable que envia correo atravez del protocolo SMTP
            cliente.UseDefaultCredentials = false;
            cliente.EnableSsl = true;
            cliente.Credentials = new System.Net.NetworkCredential("pagalotodo2023@gmail.com", "Ucab.123");

            try
            {
                cliente.Send(mensaje);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al enviar el correo electrónico: {0}", e.Message);
            }
        }
    }
}
