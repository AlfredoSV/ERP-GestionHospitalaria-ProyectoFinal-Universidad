using Application.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepositorios;
using Domain;
using Application.Dtos;

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

        public List<Cita> ConsultarCitasPaginadas(int pagina, int tamanioPag,string busqueda,bool ordernado)
        {
            List<Cita> listaCitas = _repositorioCitas.ListarCitasPaginadas(pagina,tamanioPag);

            if(!busqueda.Equals(string.Empty)){
                listaCitas = listaCitas.Where(c => c.NombrePaciente.Contains(busqueda)).ToList();
            }
            if(ordernado){
                listaCitas = listaCitas.OrderBy(c => c.NombrePaciente).ToList();
            }

            return listaCitas;

        }

        public List<Cita> ConsultarCitas()
        {

            return _repositorioCitas.ListarCitas();

        }
        public IEnumerable<DtoGrafica> ConsultarCitasGraficas()
        {
            return _repositorioCitas.ListarCitasGraficas().GroupBy(info => info.EstatusCita)
                        .Select(group => new DtoGrafica
                        {
                            Metrica = group.Key,
                            Total = group.Count()
                        })
                        .OrderBy(x => x.Metrica); 
        }


    }
}
