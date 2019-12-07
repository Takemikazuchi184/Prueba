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
    public class MunicipioAccessoDatos
    {
        Conexion _conexion;

        public MunicipioAccessoDatos()
        {
            _conexion = new Conexion("localhost", "sa", "Mexico", "escolar");
        }

        public List<Municipios> ObtenerListaMuni(string filtro)
        {
            var list1 = new List<Municipios>();
            string consulta = string.Format("select * from municipios where fk_codigo = '{0}'", filtro);
            var ds = _conexion.ObtenerDatos(consulta, "municipios");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var Muni = new Municipios
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = row["nombre"].ToString(),
                    Code = row["fk_codigo"].ToString(),

                };

                list1.Add(Muni);

            }

            return list1;

        }
    }
}