
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Presentation.WebApp.Models
{
    public class Producto
    {
        public Guid Id { get; set; }
   
     
        [Required(ErrorMessage ="El campo nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo descripción es requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo tipo producto es requerido")]
        public Guid IdTipoProducto { get; set; }
        [Required(ErrorMessage = "El campo precio es requerido")]
        public float Precio { get; set; }
        [Required(ErrorMessage = "El campo cantidad es requerido")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El campo fotografia del producto es requerido")]
        public IFormFile Foto { get; set; }
    }


}
