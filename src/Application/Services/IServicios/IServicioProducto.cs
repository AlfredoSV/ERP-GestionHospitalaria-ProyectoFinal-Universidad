using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServicios
{
    public interface IServicioProducto
    {
        List<Producto> ConsultarProductos();
        Producto ConsultarDetalleProducto(Guid id);
        bool GuardarNuevoProducto(Producto producto);
        bool EditarProducto(Producto producto);
        bool EliminarProducto(Guid id);
    }
}
