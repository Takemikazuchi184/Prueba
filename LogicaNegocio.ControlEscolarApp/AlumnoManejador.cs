using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.ControlEscolarApp;
using AccesoDatos.ControlEscolarApp;
using System.Text.RegularExpressions;

namespace LogicaNegocio.ControlEscolarApp
{
    public class AlumnoManejador
    {
        private AlumnosAccesoDatos _AlumnoAccesoDatos;
        public AlumnoManejador()
        {
            _AlumnoAccesoDatos = new AlumnosAccesoDatos();
        }
        public void EliminarAlum(string numeroControl)
        {
            _AlumnoAccesoDatos.EliminarAlum(numeroControl);
        }
        public void GuardarAlum(Alumnos alumno)
        {
            _AlumnoAccesoDatos.GuardarAlum(alumno);
        }
        public List<Alumnos> ObtenerListaAlu(string filtro)
        {
            var list1 = new List<Alumnos>();
            list1 = _AlumnoAccesoDatos.ObtenerListaAlu(filtro);
            return list1;
        }


    }
}
