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
    public class EstadoManejador
    {
        private OEstadosAccesoDatos _EstadoAcceso;

        public EstadoManejador()
        {
            _EstadoAcceso = new OEstadosAccesoDatos();
        }

        public List<Estados> ObtenerListaEst()
        {
            var list1 = new List<Estados>();
            list1 = _EstadoAcceso.ObtenerListaEst();
            return list1;
        }
    }
}
