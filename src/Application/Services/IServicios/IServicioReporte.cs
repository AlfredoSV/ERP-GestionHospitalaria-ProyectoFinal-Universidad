using Application.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServicios
{
    public interface IServicioReporte
    {
       DtoReporteCitas ConsultarReporteCitas(); 
    }
}
