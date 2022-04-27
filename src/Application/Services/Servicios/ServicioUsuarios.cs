using Application.IServicios;
using Domain;
using Domain.DTOS;
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
        public bool ActualizarDatosUsuario(DtoUsuario dtoUsuario)
        {
            var usuario = UsuarioInfo.Create(dtoUsuario.Id, dtoUsuario.Usuario_N, dtoUsuario.Correo,
                dtoUsuario.Direccion, dtoUsuario.Edad, dtoUsuario.NumCelular, dtoUsuario.Rol, dtoUsuario.FotoT,
                dtoUsuario.NumDomicilio, dtoUsuario.Id_EstadoCivil, dtoUsuario.Nombre, dtoUsuario.ApellidoP,
                dtoUsuario.ApellidoM, dtoUsuario.Sexo);
            return _repositorioUsuarios.ActualizarUsuario(usuario);
        }

        public bool ActualizarRolDeUsuario(Guid idUsuario, string rol)
        {
            return _repositorioUsuarios.ActualizarRolDeUsuario(idUsuario, rol);
        }

        public UsuarioInfo DetalleUsuario(Guid idUsuario)
        {
            return _repositorioUsuarios.ConsultarDetalleUsuario(idUsuario);
        }

        public List<Usuario> ListarUsuarios()
        {
            return _repositorioUsuarios.ConsultarUsuarios();
        }
    }
}
