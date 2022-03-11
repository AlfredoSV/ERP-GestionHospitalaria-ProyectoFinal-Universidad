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

        public List<CatalogoAreasMedicas> ConsultarCatalogoAreaMedica()
        {
            return _repositorioCatalogos.ListCatalogoAreaMedica();
        }

        public List<CatalogoEstadoCivil> ConsultarCatalogoEstadoCivil()
        {
            return _repositorioCatalogos.ListCatalogoEstadoCivil();
        }

        public List<CatalogoEstatusCitas> ConsultarCatalogoEstatusCitas()
        {
            return _repositorioCatalogos.ListCatalogoEstatusCitas();
        }

        public List<CatalogoProfesiones> ConsultarCatalogoProfesiones()
        {
            return _repositorioCatalogos.ListCatalogoProfesion();
        }

        public List<CatalogoTiposSagre> ConsultarCatalogoTiposSangre()
        {
            return _repositorioCatalogos.ListCatalogoTiposSangre();

        }

        public List<CatalogoTipoProducto> ConsultarTiposProductos()
        {
            return _repositorioCatalogos.ListCatalogoTipoProductos();
        }
    }
}
