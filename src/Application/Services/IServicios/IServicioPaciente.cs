using Application.Dtos;
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
        IEnumerable<DtoGrafica> ConsultarPacientesPorEstadoCivil();
        List<Paciente> ConsultarPacientesBD();
        IEnumerable<DtoGrafica> ConsultarPacientesPorProfesion();
        Paciente ConsultarDetallePacienteBD(Guid id);
        Paciente ConsultarDetalleGeneralPacienteBD(Guid id);
        bool GuardarNuevoPacienteBD(Paciente paciente);
        bool GuardarNuevoPacienteEditadoBD(Guid id, Paciente paciente);
        bool EliminarPacienteBD(Guid id);


    }
}
