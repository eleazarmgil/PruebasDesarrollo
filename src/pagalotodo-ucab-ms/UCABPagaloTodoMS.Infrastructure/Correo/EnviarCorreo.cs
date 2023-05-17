using System.Net.Mail;

namespace UCABPagaloTodoMS.Infrastructure.Correo
{
    public class EnviarCorreo
    {
        public void enviarCorreo(string from, string to, string subject, string body)
        {
            MailMessage message = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("tu-correo@gmail.com", "tu-contraseña-de-correo");

            try
            {
                client.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al enviar el correo electrónico: {0}", e.Message);
            }
        }

        public void CambiarClave(string nuevaClave, string usuario)
        {
            // Lógica para cambiar la clave aquí
            enviarCorreo("tu-correo@gmail.com", "destinatario@gmail.com", "Cambio de clave", "Tu clave ha sido cambiada exitosamente");
        }
    }
}
