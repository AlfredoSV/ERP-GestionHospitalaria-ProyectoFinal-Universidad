using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models
{
    public class Cita
    {
       
        public Guid PacienteId { get; set; }

        [Required(ErrorMessage = "El campo estatus es requerido")]
        public Guid idEstaus { get; set; }

        [Required(ErrorMessage ="El campo Area médica es requerido")]
        public Guid idArea { get; set; }
        [Required(ErrorMessage = "El campo Fecha es requerido")]

        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo Observaciones es requerido")]
        public string Observaciones { get; set; }
    }
}
