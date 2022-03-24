using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositorios
{
    public interface IRepositorioUsuarios
    {
        List<Usuario> ConsultarUsuarios();
        UsuarioInfo ConsultarDetalleUsuario(string nombreUsuario);
        bool ActualizarUsuario(UsuarioInfo usuarioInfo, string nombreUsuario);
        bool ActualizarRolDeUsuario(string nombreUsuario, string rol);
    }
}
