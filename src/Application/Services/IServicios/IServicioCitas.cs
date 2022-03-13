using Application.Dtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServicios
{
    public interface IServicioCitas
    {
        public List<Cita> ConsultarCitas(int pagina, int tamanioPag);
        Cita ConsultarDetalleCita(Guid id);
        IEnumerable<DtoGrafica> ConsultarCitasGraficas();
        bool CrearNuevaCita(Cita cita);
        bool EditarCita(Guid id, Cita cita);
        bool EliminarCita(Guid id);

    }
}
