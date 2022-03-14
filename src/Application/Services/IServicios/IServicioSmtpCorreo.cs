using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServicios
{
    public interface IServicioSmtpCorreo
    {
        Task EnviarCorreoAsync(string email, string subject, string message, bool isBodyHtml);

     
    }
}
