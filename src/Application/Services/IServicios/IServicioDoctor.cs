using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServicios
{
    public interface IServicioDoctor
    {
        List<Doctor> ConsultarDoctores();
        Doctor ConsultarDetalleDoctor();
        void RegistrarDoctor();
        void EditarDoctor();
        void EliminarDoctor();
    }
}
