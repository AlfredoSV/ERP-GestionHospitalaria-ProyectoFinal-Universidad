using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Presentation.WebApp.Models
{
    public class Doctor
    {
      
        public Guid Id { get; set; }

        [Required(ErrorMessage ="El campo nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo apellido paterno es requerido")]
        public string Apellidop { get; set; }

        [Required(ErrorMessage = "El campo apellido materno es requerido")]
        public string ApellidoM { get; set; }

        [Required(ErrorMessage = "El campo edad es requerido")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo dirección es requerido")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Telefono es requerido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo fotografía es requerido")]
        public string Sexo { get; set; }

        [EmailAddress(ErrorMessage ="El correo no es correcto")]
        [Required(ErrorMessage = "El campo Correo es requerido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo especialidad es requerido")]
        public string Especialidad { get; set; }

        [Required(ErrorMessage = "El campo fotografía es requerido")]
        public IFormFile Foto { get; set; }

        [Required(ErrorMessage = "El campo area asignado es requerido")]
        public Guid IdArea { get; set; }

        public string Nombre_Area { get; set; }

        [Required(ErrorMessage = "El campo estado civil es requerido")]
        public Guid IdEstadoCivil { get; set; }
        public string Nombre_Estado { get; set; }
    }
}
