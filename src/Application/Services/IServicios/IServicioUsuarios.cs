using Domain;
using Domain.DTOS;
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
        bool ActualizarDatosUsuario(DtoUsuario dtoUsuario);
        bool ActualizarRolDeUsuario(Guid idUsuario, string rol);
    }
}
