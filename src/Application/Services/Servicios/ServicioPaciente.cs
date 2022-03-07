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
        public ServicioPaciente(IRepositorioPacientes repositorioPacientes)
        {
            _repositorioPacientes = repositorioPacientes;
        }

        public List<Paciente> ConssultarPacientesPorProfesionBD()
        {
            return _repositorioPacientes.PacientesPorProfesion();
        }

        public Paciente ConsultarDetalleGeneralPacienteBD(Guid id)
        {
            return _repositorioPacientes.DetalleGeneralPaciente(id);
        }

        public Paciente ConsultarDetallePacienteBD(Guid id)
        {
            return _repositorioPacientes.DetallePaciente(id);
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
