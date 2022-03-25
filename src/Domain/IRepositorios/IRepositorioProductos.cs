using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositorios
{
    public interface IRepositorioProductos
    {
        List<Producto> ConsultarProductos();
        Producto ConsultarDetalleProductoPorId(Guid id);
        bool InsertarProducto(Producto producto);
        bool EditarProducto(Producto producto);
        bool EliminarProductoPorId(Guid id);
    }
}
