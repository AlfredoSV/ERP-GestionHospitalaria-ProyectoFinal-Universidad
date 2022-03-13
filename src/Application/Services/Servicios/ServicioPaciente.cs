using Application.Dtos;
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
    

    public class ServicioPaciente : IServicioPaciente
    {
        private readonly IRepositorioPacientes _repositorioPacientes;
        private readonly IServicioCatalogos _servicioCatalogos;
        public ServicioPaciente(IRepositorioPacientes repositorioPacientes,IServicioCatalogos servicioCatalogos)
        {
            _repositorioPacientes = repositorioPacientes;
            _servicioCatalogos = servicioCatalogos;
        }

        public IEnumerable<DtoGrafica> ConsultarPacientesPorProfesion()
        {
            return _repositorioPacientes.PacientesPorProfesion().GroupBy(info => info.NombreProfesion)
                      .Select(group => new DtoGrafica
                      {
                          Metrica = group.Key,
                          Total = group.Count()
                      })
                      .OrderBy(x => x.Metrica); ;
        }

        public Paciente ConsultarDetalleGeneralPacienteBD(Guid id)
        {
            return _repositorioPacientes.DetalleGeneralPaciente(id);
        }

        public Paciente ConsultarDetallePacienteBD(Guid id)
        {
            return _repositorioPacientes.DetallePaciente(id);
        }

        public IEnumerable<DtoGrafica> ConsultarPacientesPorEstadoCivil()
        {
            return  _repositorioPacientes.Pacientes().GroupBy(info => info.EstadoCivil)
                       .Select(group => new DtoGrafica
                       {
                           Metrica = _servicioCatalogos.ConsultarCatalogoEstadoCivil().Where(x => x.IdEstado == group.Key).Select(x => x.Nombre_Estado).FirstOrDefault(),
                           Total = group.Count()
                       })
                       .OrderBy(x => x.Metrica);
        }
        public List<Paciente> ConsultarPacientesBD()
        {
            
            return _repositorioPacientes.Pacientes();
        }

        public bool EliminarPacienteBD(Guid id)
        {
            return _repositorioPacientes.EliminarPaciente(id);
        }

        public bool GuardarNuevoPacienteBD(Paciente paciente)
        {
            return _repositorioPacientes.GuardarPaciente(paciente);
        }

        public bool GuardarNuevoPacienteEditadoBD(Guid id, Paciente paciente)
        {
            return _repositorioPacientes.GuardarPacienteEditado(id, paciente);
        }
    }
}
