using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositorios
{
    public interface IRepositorioCitas
    {
        List<Cita> ListarCitas();
        List<Cita> ListarCitasGraficas();
        Cita ConsultarDetalleCita(Guid id);
        bool CrearNuevaCita(Cita data);
        bool EditarCita(Guid id, Cita data);
        bool EliminarCita(Guid id);
    }
}
