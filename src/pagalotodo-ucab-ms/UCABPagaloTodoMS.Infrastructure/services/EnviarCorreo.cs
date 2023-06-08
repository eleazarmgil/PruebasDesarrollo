using Microsoft.Extensions.Logging;
using System.Net.Mail;
using UCABPagaloTodoMS.Core.Services;

namespace UCABPagaloTodoMS.Infrastructure.Correo;
public class EnviarCorreo : ICorreo 
{
    private SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587); //Creo la variable que envia correo atravez del protocolo SMTP
    private string correo = "pagalotodo2023@gmail.com";
    private string clave = "ybzosbdiwygeqsah";

    public void EnviaCorreoUsuario(string correo_para_quien, string asunto_del_correo, string cuerpo_del_mensaje)
    {
        cliente.UseDefaultCredentials = false;
        cliente.Credentials = new System.Net.NetworkCredential(correo, clave);
        cliente.EnableSsl = true;

        MailMessage message = new MailMessage();
        message.From = new MailAddress(correo);

        message.To.Add(correo_para_quien);
        message.Subject = asunto_del_correo;
        message.Body = cuerpo_del_mensaje;
        message.IsBodyHtml = true;

        try
        {
            cliente.Send(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
