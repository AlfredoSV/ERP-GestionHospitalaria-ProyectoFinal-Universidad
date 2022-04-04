using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models
{
    public class CitaModelViewEditar
    {
       
        public Guid PacienteId { get; set; }

        [Required(ErrorMessage = "El campo estatus es requerido")]
        public Guid IdEstaus { get; set; }

        [Required(ErrorMessage ="El campo Area médica es requerido")]
        public Guid IdArea { get; set; }
        [Required(ErrorMessage = "El campo Fecha es requerido")]

        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo Observaciones es requerido")]
        public string Observaciones { get; set; }

        public Guid Id { get; set; }
        [Required(ErrorMessage = "El campo Observaciones es requerido")]
        public string NombrePaciente { get; set; }


    }
}
