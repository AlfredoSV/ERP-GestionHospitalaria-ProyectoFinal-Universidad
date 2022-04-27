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
        UsuarioInfo ConsultarDetalleUsuario(Guid idUsuario);
        bool ActualizarUsuario(UsuarioInfo usuarioInfo);
        bool ActualizarRolDeUsuario(Guid idUsuario, string rol);
    }
}
