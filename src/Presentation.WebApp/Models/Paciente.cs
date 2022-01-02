using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Presentation.WebApp.Models
{
    public class Paciente
    {
        [Required(ErrorMessage ="El campo nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo apellido paterno es requerido")]
        public string ApellidoP { get; set; }

        [Required(ErrorMessage = "El campo apellido materno es requerido")]
        public string ApellidoM {get; set;}

        [Required(ErrorMessage = "El campo edad es requerido")]
        [Range(1,120,ErrorMessage ="El campo edad no está dentro del rango")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo corre es requerido")]
        [EmailAddress(ErrorMessage ="El campo correo no tiene el formato  eun correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage ="El campo telefono movil es requerido")]
        [MaxLength(10,ErrorMessage = "El campo telefono movil debe tener máximo diez digitos")]
        [MinLength(10,ErrorMessage = "El campo telefono movil debe tener minimo diez digitos")]
        public string TelefonoM { get; set; }

        [Required(ErrorMessage = "El campo telefono del trabajo es requerido")]
        [MaxLength(10, ErrorMessage = "El campo telefono del trabajo debe tener máximo diez digitos")]
        [MinLength(10, ErrorMessage = "El campo telefono del trabajo debe tener minimo diez digitos")]
        public string TelefonoT { get; set; }

        [Required(ErrorMessage = "El campo telefono de domicilio es requerido")]
        [MaxLength(10, ErrorMessage = "El campo telefono de domicilio  debe tener máximo diez digitos")]
        [MinLength(10, ErrorMessage = "El campo telefono de domicilio  debe tener minimo diez digitos")]
        public string TelefonoD { get; set; }

        [Required(ErrorMessage = "El campo Curp  es requerido")]
        [RegularExpression(@"^[A-Z]{1}[AEIOU]{1}[A-Z]{2}[0-9]{2}(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[HM]{1}(AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE)[B-DF-HJ-NP-TV-Z]{3}[0-9A-Z]{1}[0-9]{1}$", ErrorMessage = "El campo curp no tiene el formato correcto")]
        public string Curp { get; set; }
    
        public string Sexo { get; set; }

      
        public string Comentarios { get; set; }

        [Required(ErrorMessage = "El campo calle es requerido")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "El campo colonia es requerido")]
        public string Colonia { get; set; }
        public string Delegacion { get; set; }

        public string NumInt { get; set; }

        [Required(ErrorMessage = "El campo número exterior es requerido")]
        public string NumExt { get; set; }

        [Required(ErrorMessage = "El campo entre qué calles es requerido")]
        public string EntreCalles { get; set; }

        public Guid Profesion { get; set; }

        public Guid EstadoCivil { get; set; }

        public Guid TipoSangre { get; set; }
        public string Estado { get; set; }

        [MaxLength(5, ErrorMessage = "El campo código postal del trabajo debe tener máximo cinco digitos")]
        [MinLength(5, ErrorMessage = "El campo código postal del trabajo debe tener minimo cinco digitos")]
        [Required(ErrorMessage = "El campo código postal es requerido")]
        public string Cp { get; set; }

        [Required(ErrorMessage = "El Referencia 1  es requerido")]
        public string Referencia1 { get; set; }


       
        public string Referencia2 { get; set; }


        [Required(ErrorMessage = "Favor de adjuntar una fotografia")]
        public IFormFile Fotografia { get; set; }

      
    }

    public class PacienteEdit
    {
        public PacienteEdit()
        {

        }
        public PacienteEdit(Guid id, string nombre, string apellidoP, string apellidoM, int edad, string correo, string telefonoM, string telefonoT, string telefonoD, string curp, string sexo, string comentarios, string calle, string colonia, string delegacion, string numInt, string numExt, string entreCalles, Guid profesion, Guid estadoCivil, Guid tipoSangre, string estado, string cp, string referencia1, string referencia2, IFormFile fotografia)
        {
            Id = id;
            Nombre = nombre;
            ApellidoP = apellidoP;
            ApellidoM = apellidoM;
            Edad = edad;
            Correo = correo;
            TelefonoM = telefonoM;
            TelefonoT = telefonoT;
            TelefonoD = telefonoD;
            Curp = curp;
            Sexo = sexo;
            Comentarios = comentarios;
            Calle = calle;
            Colonia = colonia;
            Delegacion = delegacion;
            NumInt = numInt;
            NumExt = numExt;
            EntreCalles = entreCalles;
            Profesion = profesion;
            EstadoCivil = estadoCivil;
            TipoSangre = tipoSangre;
            Estado = estado;
            Cp = cp;
            Referencia1 = referencia1;
            Referencia2 = referencia2;
            Fotografia = fotografia;
        }
        public static PacienteEdit Create(Guid id, string nombre, string apellidoP, string apellidoM, int edad, string correo, string telefonoM, string telefonoT, string telefonoD, string curp, string sexo, string comentarios, string calle, string colonia, string delegacion, string numInt, string numExt, string entreCalles, Guid profesion, Guid estadoCivil, Guid tipoSangre, string estado, string cp, string referencia1, string referencia2, IFormFile fotografia)
        {
            return new PacienteEdit( id,  nombre,  apellidoP,  apellidoM,  edad,  correo,  telefonoM,  telefonoT,  telefonoD,  curp,  sexo,  comentarios,  calle,  colonia,  delegacion,  numInt,  numExt,  entreCalles,  profesion,  estadoCivil,  tipoSangre,  estado,  cp,  referencia1,  referencia2,  fotografia);
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo apellido paterno es requerido")]
        public string ApellidoP { get; set; }

        [Required(ErrorMessage = "El campo apellido materno es requerido")]
        public string ApellidoM { get; set; }

        [Required(ErrorMessage = "El campo edad es requerido")]
        [Range(1, 120, ErrorMessage = "El campo edad no está dentro del rango")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo correo es requerido")]
        [EmailAddress(ErrorMessage = "El campo correo no tiene el formato  de correcto")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo telefono movil es requerido")]
        [MaxLength(10, ErrorMessage = "El campo telefono movil debe tener máximo diez digitos")]
        [MinLength(10, ErrorMessage = "El campo telefono movil debe tener minimo diez digitos")]
        public string TelefonoM { get; set; }

        [Required(ErrorMessage = "El campo telefono del trabajo es requerido")]
        [MaxLength(10, ErrorMessage = "El campo telefono del trabajo debe tener máximo diez digitos")]
        [MinLength(10, ErrorMessage = "El campo telefono del trabajo debe tener minimo diez digitos")]
        public string TelefonoT { get; set; }

        [Required(ErrorMessage = "El campo telefono de domicilio es requerido")]
        [MaxLength(10, ErrorMessage = "El campo telefono de domicilio  debe tener máximo diez digitos")]
        [MinLength(10, ErrorMessage = "El campo telefono de domicilio  debe tener minimo diez digitos")]
        public string TelefonoD { get; set; }

        [Required(ErrorMessage = "El campo Curp  es requerido")]
        [RegularExpression(@"^[A-Z]{1}[AEIOU]{1}[A-Z]{2}[0-9]{2}(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[HM]{1}(AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE)[B-DF-HJ-NP-TV-Z]{3}[0-9A-Z]{1}[0-9]{1}$", ErrorMessage = "El campo curp no tiene el formato correcto")]
        public string Curp { get; set; }

        public string Sexo { get; set; }


        public string Comentarios { get; set; }

        [Required(ErrorMessage = "El campo calle es requerido")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "El campo colonia es requerido")]
        public string Colonia { get; set; }
        public string Delegacion { get; set; }

        public string NumInt { get; set; }

        [Required(ErrorMessage = "El campo número exterior es requerido")]
        public string NumExt { get; set; }

        [Required(ErrorMessage = "El campo entre qué calles es requerido")]
        public string EntreCalles { get; set; }

        public Guid Profesion { get; set; }

        public Guid EstadoCivil { get; set; }

        public Guid TipoSangre { get; set; }
        public string Estado { get; set; }

        [MaxLength(5, ErrorMessage = "El campo código postal del trabajo debe tener máximo cinco digitos")]
        [MinLength(5, ErrorMessage = "El campo código postal del trabajo debe tener minimo cinco digitos")]
        [Required(ErrorMessage = "El campo código postal es requerido")]
        public string Cp { get; set; }

        [Required(ErrorMessage = "El Referencia 1  es requerido")]
        public string Referencia1 { get; set; }



        public string Referencia2 { get; set; }


        
        public IFormFile Fotografia { get; set; }


    }
}
