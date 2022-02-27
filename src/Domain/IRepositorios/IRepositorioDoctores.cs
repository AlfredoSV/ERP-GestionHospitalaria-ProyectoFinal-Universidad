using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositorios
{
    public interface IRepositorioDoctores
    {
        List<Doctor> ConsultarDoctoresDb();
        Doctor ConsultarDetalleDoctorDb(Guid id);
        bool GuardarDoctorBd(Doctor data);
        bool EditarDoctorBd(Doctor data);
        bool EliminarDoctorBd(Guid id);


    }
}
