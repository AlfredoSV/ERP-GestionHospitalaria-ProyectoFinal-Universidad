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
        List<Cita> ConsultarCitasPaginadas(int pagina, int tamanioPag,string busqueda,bool ordernado);
        List<Cita> ConsultarCitas();
        Cita ConsultarDetalleCita(Guid id);
        IEnumerable<DtoGrafica> ConsultarCitasGraficas();
        bool CrearNuevaCita(Cita cita);
        bool EditarCita(Guid id, Cita cita);
        bool EliminarCita(Guid id);

    }
}
