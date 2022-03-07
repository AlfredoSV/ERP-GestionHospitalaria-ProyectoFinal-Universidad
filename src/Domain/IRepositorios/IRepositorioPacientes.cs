using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositorios
{
    public interface IRepositorioPacientes
    {
        List<Paciente> Pacientes();
        List<Paciente> PacientesPorProfesion();
        Paciente DetallePaciente(Guid id);
        Paciente DetalleGeneralPaciente(Guid id);
        bool GuardarPaciente(Paciente paciente);
        bool GuardarPacienteEditado(Guid id, Paciente paciente);
        public bool EliminarPaciente(Guid id);
    }
}
