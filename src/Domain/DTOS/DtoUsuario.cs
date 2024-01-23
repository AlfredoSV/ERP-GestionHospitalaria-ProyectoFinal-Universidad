
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class DtoUsuario
    {
        public DtoUsuario(Guid id, string usuario_N, string correo, string direccion, int edad, string numCelular, string rol, string fotoT, string numDomicilio, Guid id_EstadoCivil, string nombre, string apellidoP, string apellidoM, string sexo)
        {
            Id = id;
            Usuario_N = usuario_N;
            Correo = correo;
            Direccion = direccion;
            Edad = edad;
            NumCelular = numCelular;
            Rol = rol;
            FotoT = fotoT;
            NumDomicilio = numDomicilio;
            Id_EstadoCivil = id_EstadoCivil;
            Nombre = nombre;
            ApellidoP = apellidoP;
            ApellidoM = apellidoM;
            Sexo = sexo;
        }

        public Guid Id { get; set; }
        public string Usuario_N { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string NumCelular { get; set; }
        public string Rol { get; set; }
        public string FotoT { get; set; }
        public string NumDomicilio { get; set; }
        public Guid Id_EstadoCivil { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Sexo { get; set; }
    }
}
