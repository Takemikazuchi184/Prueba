using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.ControlEscolarApp;
using ConexionBd;
using System.Data;

namespace AccesoDatos.ControlEscolarApp
{
    public class AlumnosAccesoDatos
    {
        Conexion _conexion;

        public AlumnosAccesoDatos()
        {
            _conexion = new Conexion("localhost", "sa", "Mexico", "escolar");
        }

        public void EliminarAlum(string numeroControl)
        {
            string cadena = string.Format("Delete from Alumnos where Numero_control = {0}", numeroControl);
            _conexion.EjecutarConsulta(cadena);
        }

        public void GuardarAlum(Alumnos alumno)
        {
            if (GetNumero(alumno.Numero_control) == 0)
            {
                string cadena = string.Format("Insert into Alumnos values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", alumno.Numero_control, alumno.Nombre, alumno.Apellidop, alumno.Apellidom,alumno.Sexo,alumno.Nacimiento,alumno.Correo,alumno.Telefono,alumno.Estado,alumno.Municipio,alumno.Domicilio);
                _conexion.EjecutarConsulta(cadena);
            }
            else
            {
                string cadena = string.Format("update Alumnos set Nombre='{0}', Apellidop='{1}', Apellidom='{2}' where Numero_control='{3}'", alumno.Nombre, alumno.Apellidop, alumno.Apellidom, alumno.Numero_control);
                _conexion.EjecutarConsulta(cadena);
            }
        }

        public void Existe(string Control)
        {
            
            _conexion.EjecutarConsulta("select count(*) from Alumnos where Numero_control = '" + Control + "'");
            
        }
        public List<Alumnos> ObtenerListaAlu(string filtro)
        {
            var list1 = new List<Alumnos>();
            string consulta = string.Format("select * from Alumnos where nombre like '%{0}%'", filtro);
            var ds = _conexion.ObtenerDatos(consulta, "Alumnos");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var alumno = new Alumnos
                {
                    Numero_control = row["Numero_control"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Apellidop = row["Apellidop"].ToString(),
                    Apellidom = row["Apellidom"].ToString(),
                    Sexo = row["Sexo"].ToString(),
                    Nacimiento = row["Nacimiento"].ToString(),
                    Correo = row["Correo"].ToString(),
                    Telefono = row["Telefono"].ToString(),
                    Estado = row["Estado"].ToString(),
                    Municipio = row["Municipio"].ToString(),
                    Domicilio = row["Domicilio"].ToString()
                };

                list1.Add(alumno);

            }

            return list1;

        }


        public int GetNumero(string control)
        {

            var res = _conexion.Existe("select count(*) from Alumnos where Numero_control = '"+control+"'");
            return res;
        }

    }
}
