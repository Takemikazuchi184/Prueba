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
    public class OEstadosAccesoDatos
    {
        Conexion _conexion;

        public OEstadosAccesoDatos()
        {
            _conexion = new Conexion("localhost", "sa", "Mexico", "escolar");
        }

        public List<Estados> ObtenerListaEst()
        {
            var list1 = new List<Estados>();
            string consulta = string.Format("select * from Estados");
            var ds = _conexion.ObtenerDatos(consulta, "Estados");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var Estado = new Estados
                {
                    Codigo = row["codigo"].ToString(),
                    Nombre = row["nombre"].ToString(),
                    
                };

                list1.Add(Estado);

            }

            return list1;

        }

    }

    
}
