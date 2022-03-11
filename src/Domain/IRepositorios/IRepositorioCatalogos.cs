using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositorios
{
    public interface IRepositorioCatalogos
    {
        public List<CatalogoEstatusCitas> ListCatalogoEstatusCitas();

        public List<CatalogoAreasMedicas> ListCatalogoAreaMedica();

        public List<CatalogoEstadoCivil> ListCatalogoEstadoCivil();

        public List<CatalogoTiposSagre> ListCatalogoTiposSangre();

        public List<CatalogoProfesiones> ListCatalogoProfesion();

        public List<CatalogoTipoProducto> ListCatalogoTipoProductos();
        
    }
}
