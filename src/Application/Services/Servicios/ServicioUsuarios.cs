using Application.IServicios;
using Domain;
using Domain.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicios
{
    public class ServicioUsuarios : IServicioUsuarios
    {
        private readonly IRepositorioUsuarios _repositorioUsuarios;
        public ServicioUsuarios(IRepositorioUsuarios repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }
        public bool ActualizarDatosUsuario(UsuarioInfo usuarioInfo, string nombreUsuario)
        {
            return _repositorioUsuarios.ActualizarUsuario(usuarioInfo, nombreUsuario);
        }

        public bool ActualizarRolDeUsuario(string nombreUsuario, string rol)
        {
            return _repositorioUsuarios.ActualizarRolDeUsuario(nombreUsuario, rol);
        }

        public UsuarioInfo DetalleUsuario(string nombreUsuario)
        {
            return _repositorioUsuarios.ConsultarDetalleUsuario(nombreUsuario);
        }

        public List<Usuario> ListarUsuarios()
        {
            return _repositorioUsuarios.ConsultarUsuarios();
        }
    }
}
