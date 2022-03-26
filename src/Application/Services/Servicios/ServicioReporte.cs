using Application.IServicios;
using System.IO;
using System.IO;
using System;
using Application.Dtos;

namespace Application.Servicios
{
    public class ServicioReporte : IServicioReporte
    {
        public readonly IServicioCitas _servicioCitas;

        public ServicioReporte(IServicioCitas servicioCitas)
        {
            _servicioCitas = servicioCitas;
        }

        public DtoReporteCitas ConsultarReporteCitas()
        {
            var citas = _servicioCitas.ConsultarCitas();

            return new DtoReporteCitas("Alfredo", DateTime.Now.AddMonths(1).ToString(), DateTime.Now.AddMonths(1).ToString(), citas, citas);
        }
    }
}
