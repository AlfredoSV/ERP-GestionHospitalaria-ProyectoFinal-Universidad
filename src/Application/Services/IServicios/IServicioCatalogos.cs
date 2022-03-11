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
        public List<CatalogoEstatusCitas> ConsultarCatalogoEstatusCitasBd();

        public List<CatalogoAreasMedicas> ConsultarCatalogoAreaMedicaBd();

        public List<CatalogoEstadoCivil> ConsultarCatalogoEstadoCivilBd();

        public List<CatalogoTiposSagre> ConsultarCatalogoTiposSangreBd();

        public List<CatalogoProfesiones> ConsultarCatalogoProfesionesBd();

        public List<CatalogoTipoProducto> ConsultarTiposProductosBd();
        
    }
}
