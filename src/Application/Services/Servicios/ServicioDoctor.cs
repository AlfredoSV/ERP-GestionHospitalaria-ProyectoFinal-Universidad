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
    public class ServicioDoctor : IServicioDoctor
    {
        private readonly IRepositorioDoctores _repositorioDoctores;
        public ServicioDoctor(IRepositorioDoctores repositorioDoctores)
        {
            _repositorioDoctores = repositorioDoctores;
        }

        public Doctor ConsultarDetalleDoctor(Guid id)
        {
            return _repositorioDoctores.ConsultarDetalleDoctorDb(id);
        }

        public List<Doctor> ConsultarDoctores()
        {
            return _repositorioDoctores.ConsultarDoctoresDb();
        }

        public bool EditarDoctor(Doctor doctor)
        {
            return _repositorioDoctores.EditarDoctorBd(doctor);
        }

        public bool EliminarDoctor(Guid id)
        {
            return _repositorioDoctores.EliminarDoctorBd(id);
        }

        public void RegistrarDoctor(Doctor doctor)
        {
            _repositorioDoctores.GuardarDoctorBd(doctor);
        }


    }
}
