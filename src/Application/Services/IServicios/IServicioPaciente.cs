using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServicios
{
    public interface IServicioPaciente
    {
        public List<Paciente> ConsultarPacientesBD();
        public List<Paciente> ConssultarPacientesPorProfesionBD();
        public Paciente ConsultarDetallePacienteBD(Guid id);
        public Paciente ConsultarDetalleGeneralPacienteBD(Guid id);
        public bool GuardarNuevoPacienteBD(Paciente paciente);
        public bool GuardarNuevoPacienteEditadoBD(Guid id, Paciente paciente);
        public bool EliminarPacienteBD(Guid id);


    }
}
