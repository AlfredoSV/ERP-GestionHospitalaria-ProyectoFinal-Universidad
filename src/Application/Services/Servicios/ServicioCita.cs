using Application.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepositorios;
using Domain;

namespace Application.Servicios
{

    public class ServicioCita : IServicioCitas
    {
        private readonly IRepositorioCitas _repositorioCitas;
        public ServicioCita(IRepositorioCitas repositorioCitas)
        {
            _repositorioCitas = repositorioCitas;
        }

        public Cita ConsultarDetalleCita(Guid id)
        {
            return _repositorioCitas.ConsultarDetalleCita(id);
        }

        public bool CrearNuevaCita(Cita cita)
        {
            return _repositorioCitas.CrearNuevaCita(cita);
        }

        public bool EditarCita(Guid id, Cita cita)
        {
            return _repositorioCitas.EditarCita(id, cita);
        }

        public bool EliminarCita(Guid id)
        {
            return _repositorioCitas.EliminarCita(id);
        }

        public List<Cita> ListarCitas()
        {
            return _repositorioCitas.ListarCitas();

        }

        public List<Cita> ListarCitasGraficas()
        {
            return _repositorioCitas.ListarCitasGraficas();
        }


    }
}
