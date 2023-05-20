using System.Net;
using System.Net.Mail;

namespace UCABPagaloTodoMS.Infrastructure.Correo
{
    public class EnviarCorreo
    {
        public void EnviaCorreoUsuario(string correo_para_quien, string asunto_del_correo, string cuerpo_del_mensaje)
        {
            SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587); //Creo la variable que envia correo atravez del protocolo SMTP
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = new System.Net.NetworkCredential("pagalotodo2023@gmail.com", "ybzosbdiwygeqsah");
            cliente.EnableSsl = true;

            MailMessage message = new MailMessage();
            message.From = new MailAddress("pagalotodo2023@gmail.com");

            message.To.Add(correo_para_quien);
            message.Subject = asunto_del_correo;
            message.Body = cuerpo_del_mensaje;
            message.IsBodyHtml = true;


            try
            {
                cliente.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al enviar el correo electrónico: {0}", e.Message);
            }
        }
    }
}
