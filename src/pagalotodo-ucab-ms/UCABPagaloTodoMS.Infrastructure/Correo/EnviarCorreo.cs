using System.Net;
using System.Net.Mail;

namespace UCABPagaloTodoMS.Infrastructure.Correo;
public class EnviarCorreo
{
    public void EnviaCorreoUsuario(string destinatario, string asunto, string mensaje)
    {
        // Configuración del servidor SMTP
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("pagalotodo2023@gmail.com", "Ucab.123");

        // Creación del mensaje de correo electrónico
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("tucorreo@gmail.com");
        mailMessage.To.Add(destinatario);
        mailMessage.Subject = asunto;
        mailMessage.Body = mensaje;

        // Envío del mensaje
        //smtpClient.Send(mailMessage);
    }
}
