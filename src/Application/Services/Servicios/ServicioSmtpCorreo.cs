using Application.IServicios;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Application.Servicios
{
    public class ServicioSmtpCorreo : IServicioSmtpCorreo
    {
        private SmtpClient client { get; set; }
        private MailMessage mail { get; set; }

        public ServicioSmtpCorreo (string fromName, string fromAddress, string host, int port, string userName, string password)
        {
            client = new SmtpClient();
            client.Host = host;
            client.Port = port;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(userName, password);
            client.TargetName = "STARTTLS/smtp.office365.com";
            client.EnableSsl = true;

            mail = new MailMessage();
            mail.From = new MailAddress(fromAddress, fromName);
        }

        public async Task EnviarCorreoAsync(string email, string subject, string message, bool isBodyHtml)
        {
            mail.Subject = subject;
            mail.IsBodyHtml = isBodyHtml;
            mail.Body = message;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.To.Add(email);

            try
            {
                client.Send(mail);
                await Task.FromResult(0);
                client.Dispose();
                mail.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
