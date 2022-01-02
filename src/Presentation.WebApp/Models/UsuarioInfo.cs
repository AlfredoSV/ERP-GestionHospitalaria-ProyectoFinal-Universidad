using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models
{
    public class UsuarioInfo
    {
        public Guid Id { get; set; }
        public string Usuario_N { get; set; }

        [EmailAddress(ErrorMessage = "Es necesario ingresar un correo valido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar una dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar una edad")]
        [Range(1, 100, ErrorMessage = "En valor parea el campo edad tiene que se ser de 1 a 100")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un número de celular")]
        public string NumCelular { get; set; }
        public string Rol { get; set; }

        public string Foto { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un número de contacto")]
        public string NumDomicilio { get; set; }
        public Guid Id_EstadoCivil { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Sexo { get; set; }
    }
}
