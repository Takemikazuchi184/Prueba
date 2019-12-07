using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ControlEscolarApp
{
    public class Alumnos
    {
        private string _numero_control;
        private string _nombre;
        private string _apellidop;
        private string _apellidom;
        private string _sexo;
        private string _nacimiento;
        private string _correo;
        private string _telefono;
        private string _estado;
        private string _municipio;
        private string _domicilio;


        public string Numero_control { get => _numero_control; set => _numero_control = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellidop { get => _apellidop; set => _apellidop = value; }
        public string Apellidom { get => _apellidom; set => _apellidom = value; }
        public string Sexo { get => _sexo; set => _sexo = value; }

        public string Nacimiento { get => _nacimiento; set => _nacimiento = value; }

        public string Correo { get => _correo; set => _correo = value; }

        public string Telefono { get => _telefono; set => _telefono = value; }

        public string Estado { get => _estado; set => _estado = value; }

        public string Municipio { get => _municipio; set => _municipio = value; }

        public string Domicilio { get => _domicilio; set => _domicilio = value; }


    }
}