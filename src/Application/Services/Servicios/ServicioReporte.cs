using Application.IServicios;
using System.IO;
using System.IO;
using System;


namespace Application.Servicios
{
    public class ServicioReporte : IServicioReporte
    {
        public readonly IServicioCitas _servicioCitas;

        public ServicioReporte(IServicioCitas servicioCitas)
        {
            _servicioCitas = servicioCitas;
        }

        public MemoryStream GenerarReporteCitas()
        {
            MemoryStream docMemory = new MemoryStream();
            try
            {
       
                

            }
            catch (System.Exception e)
            {

                throw;
            }

            var base64 = Convert.ToBase64String(docMemory.ToArray());

            return docMemory;
            
;            
        }
    }
}
