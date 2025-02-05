using Application.IServicios;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Application.Servicios
{
    public class ServicioSmtpCorreo : IServicioSmtpCorreo
    {
        private SmtpClient _cliente;
        private MailMessage _mail;

        public ServicioSmtpCorreo(string fromName, string fromAddress, string host, int port, string userName, string password)
        {
            _cliente = new SmtpClient();
            _cliente.Host = host;
            _cliente.Port = port;
            _cliente.UseDefaultCredentials = false;
            _cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            _cliente.Credentials = new NetworkCredential(userName, password);
            _cliente.TargetName = "STARTTLS/smtp.office365.com";
            _cliente.EnableSsl = true;

            _mail = new MailMessage();
            _mail.From = new MailAddress(fromAddress, fromName);
        }

        public async Task EnviarCorreoAsync(string email, string subject, string message,
            bool isBodyHtml)
        {
            _mail.Subject = subject;
            _mail.IsBodyHtml = isBodyHtml;
            _mail.Body = message;
            _mail.BodyEncoding = System.Text.Encoding.UTF8;
            _mail.SubjectEncoding = System.Text.Encoding.UTF8;
            _mail.To.Add(email);

            try
            {
                await _cliente.SendMailAsync(_mail);
                _cliente.Dispose();
                _mail.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
