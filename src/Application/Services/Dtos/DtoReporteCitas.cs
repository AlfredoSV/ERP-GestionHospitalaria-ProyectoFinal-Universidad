using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class DtoReporteCitas
    {
        private string _usuario;
        private string _fechaIncioReporte;
        private string _fechaFinReporte;
        private IEnumerable<Cita> _citasCerradas;
        private IEnumerable<Cita> _citasCanceladas;

        public DtoReporteCitas(string usuario, string fechaIncioReporte, string fechaFinReporte, List<Cita> citasCerradas, List<Cita> citasCanceladas)
        {
            _usuario = usuario;
            _fechaIncioReporte = fechaIncioReporte;
            _fechaFinReporte = fechaFinReporte;
            _citasCerradas = citasCerradas;
            _citasCanceladas = citasCanceladas;
        }

        public string Usuario { get => _usuario; private set { } }
        public string FechaIncioReporte { get => _fechaIncioReporte; private set { } }
        public string FechaFinReporte { get => _fechaFinReporte; private set { } }
        public IEnumerable<Cita> CitasCerradas { get => _citasCerradas; private set { } }
        public IEnumerable<Cita> CitasCanceladas { get => _citasCanceladas; private set { } }
    }
}
