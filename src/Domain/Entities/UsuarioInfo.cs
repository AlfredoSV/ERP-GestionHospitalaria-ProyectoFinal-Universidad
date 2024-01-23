
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;


namespace Domain
{
    public class UsuarioInfo
    {
        public UsuarioInfo() { }
        public UsuarioInfo(Guid id, string usuario_N, string correo, string direccion, int edad, string numCelular, string rol, string foto, string numDomicilio, Guid id_EstadoCivil, string nombre, string apellidoP, string apellidoM, string sexo)
        {
            Id = id;
            Usuario_N = usuario_N;
            Correo = correo;
            Direccion = direccion;
            Edad = edad;
            NumCelular = numCelular;
            Rol = rol;
            FotoT = foto;
            NumDomicilio = numDomicilio;
            Id_EstadoCivil = id_EstadoCivil;
            Nombre = nombre;
            ApellidoP = apellidoP;
            ApellidoM = apellidoM;
            Sexo = sexo;
        }

        public static UsuarioInfo Create(Guid id, string usuario_N, string correo, string direccion, int edad, string numCelular, string rol, string foto, string numDomicilio, Guid id_EstadoCivil, string nombre, string apellidoP, string apellidoM, string sexo)
        {
            return new UsuarioInfo(id, usuario_N, correo, direccion, edad, numCelular, rol, foto, numDomicilio, id_EstadoCivil, nombre, apellidoP, apellidoM, sexo);
        }

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

        public FormFile FotoFile { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un número de contacto")]
        public string NumDomicilio { get; set; }
        public Guid Id_EstadoCivil { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Sexo { get; set; }
    }
}
