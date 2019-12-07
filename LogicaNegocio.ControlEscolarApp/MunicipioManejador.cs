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
    public class MunicipioManejador
    {
        private MunicipioAccessoDatos _municipioAccessoDatos;

        public MunicipioManejador()
        {
            _municipioAccessoDatos = new MunicipioAccessoDatos();
        }
        public List<Municipios> ObtenerListaMuni(string filtro)
        {
            var list1 = new List<Municipios>();
            list1 = _municipioAccessoDatos.ObtenerListaMuni(filtro);
            return list1;
        }
    }
}
