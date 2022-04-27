using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Presentation.WebApp.Models
{
    public class UsuarioInfoViewModel
    {
        [Required(ErrorMessage = "Es necesario el identificador")]
        public Guid Id { get; set; }
        public string Usuario_N { get; set; }

        [EmailAddress(ErrorMessage = "Es necesario ingresar un correo valido")]
        [Required(ErrorMessage = "Es necesario ingresar un correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar una dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar una edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un número de celular")]
        public string NumCelular { get; set; }
        public string Rol { get; set; }

        public string FotoT { get; set; }

        public IFormFile FotoFile { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un número de contacto")]
        public string NumDomicilio { get; set; }
        public Guid Id_EstadoCivil { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Sexo { get; set; }
    }
}
