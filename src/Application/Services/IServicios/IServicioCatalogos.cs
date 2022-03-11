using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServicios
{
    public interface IServicioCatalogos
    {
        public List<CatalogoEstatusCitas> ConsultarCatalogoEstatusCitas();

        public List<CatalogoAreasMedicas> ConsultarCatalogoAreaMedica();

        public List<CatalogoEstadoCivil> ConsultarCatalogoEstadoCivil();

        public List<CatalogoTiposSagre> ConsultarCatalogoTiposSangre();

        public List<CatalogoProfesiones> ConsultarCatalogoProfesiones();

        public List<CatalogoTipoProducto> ConsultarTiposProductos();
        
    }
}
