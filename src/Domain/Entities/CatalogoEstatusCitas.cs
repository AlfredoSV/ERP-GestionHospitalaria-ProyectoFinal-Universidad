using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CatalogoEstatusCitas
    {
        public Guid IdEstatus { get; set; }
        public string Nombre_Estatus { get; set; }
        public string Descripcion { get; set; }

    }

    public class CatalogoTipoProducto
    {
        public Guid IdTipo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }
}
