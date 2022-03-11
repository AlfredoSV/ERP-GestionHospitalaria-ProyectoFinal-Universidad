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
    public class ServicioCatalogos : IServicioCatalogos
    {
        private IRepositorioCatalogos _repositorioCatalogos;
        public ServicioCatalogos(IRepositorioCatalogos repositorioCatalogos)
        {
            _repositorioCatalogos = repositorioCatalogos;
        }

        public List<CatalogoAreasMedicas> ConsultarCatalogoAreaMedicaBd()
        {
            return _repositorioCatalogos.ListCatMed();
        }

        public List<CatalogoEstadoCivil> ConsultarCatalogoEstadoCivilBd()
        {
            return _repositorioCatalogos.ListCatEstadoCivil();
        }

        public List<CatalogoEstatusCitas> ConsultarCatalogoEstatusCitasBd()
        {
            return _repositorioCatalogos.ListCatEst();
        }

        public List<CatalogoProfesiones> ConsultarCatalogoProfesionesBd()
        {
            return _repositorioCatalogos.ListCatProfesion();
        }

        public List<CatalogoTiposSagre> ConsultarCatalogoTiposSangreBd()
        {
            return _repositorioCatalogos.ListCatTiposSangre();

        }

        public List<CatalogoTipoProducto> ConsultarTiposProductosBd()
        {
            return _repositorioCatalogos.ListCatTipoProductos();
        }
    }
}
