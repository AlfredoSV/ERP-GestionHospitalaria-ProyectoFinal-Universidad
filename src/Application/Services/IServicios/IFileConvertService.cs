using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServicios
{
    public interface IFileConvertService
    {
        string ConvertToBase64(Stream file, int w = 256);
        MemoryStream ReadImagen(MemoryStream ms, int w);
        string CovertPDFToBase64(IFormFile file);
    }
}
