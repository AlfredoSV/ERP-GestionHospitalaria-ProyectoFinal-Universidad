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
    public class ServicioProducto : IServicioProducto
    {
        private readonly IRepositorioProductos _repositorioProductos;
        public ServicioProducto(IRepositorioProductos repositorioProductos)
        {
            _repositorioProductos = repositorioProductos;
        }
        public Producto ConsultarDetalleProducto(Guid id)
        {
            return _repositorioProductos.ConsultarDetalleProductoPorId(id);
        }

        public List<Producto> ConsultarProductos()
        {
            return _repositorioProductos.ConsultarProductos();
        }

        public bool EditarProducto(Producto producto)
        {
            return _repositorioProductos.EditarProducto(producto);
        }

        public bool EliminarProducto(Guid id)
        {
            return _repositorioProductos.EliminarProductoPorId(id);
        }

        public bool GuardarNuevoProducto(Producto producto)
        {
            return _repositorioProductos.EditarProducto(producto);
        }
    }
}
