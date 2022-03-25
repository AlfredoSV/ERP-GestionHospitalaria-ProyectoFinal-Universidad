using Application.IServicios;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout;

namespace Application.Servicios
{
    public class ServicioReporte : IServicioReporte
    {
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
          

            return docMemory;
            
;            
        }
    }
}
