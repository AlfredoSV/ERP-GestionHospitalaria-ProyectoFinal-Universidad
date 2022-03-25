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
        bool InsertarProducto(Producto data);
        bool EditarProducto(Producto data);
        bool EliminarProductoPorId(Guid id);
    }
}
