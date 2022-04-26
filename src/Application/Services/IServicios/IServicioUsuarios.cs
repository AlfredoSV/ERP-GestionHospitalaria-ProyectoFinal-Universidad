using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServicios
{
    public interface IServicioUsuarios
    {
        List<Usuario> ListarUsuarios();
        UsuarioInfo DetalleUsuario(Guid idUsuario);
        bool ActualizarDatosUsuario(UsuarioInfo usuarioInfo, string nombreUsuario);
        bool ActualizarRolDeUsuario(string nombreUsuario, string rol);
    }
}
