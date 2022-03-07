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

        public List<Paciente> ConsultarPacientesBD()
        {
            return _repositorioPacientes.ConsultarPacientes();
        }
    }
}
