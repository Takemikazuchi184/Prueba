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
    public class UsuarioManejador
    {
        private UsuariosAccesoDatos _usuariosAccesoDatos;
        public UsuarioManejador()
        {
            _usuariosAccesoDatos = new UsuariosAccesoDatos();
        }
        public void Eliminar(int idUsuario)
        {
            _usuariosAccesoDatos.Eliminar(idUsuario);
        }

        public void Guardar(Usuarios usuario)
        {
            _usuariosAccesoDatos.Guardar(usuario);
        }

        private bool NombreValido(string nombre)
        {
            var regex = new Regex(@"^[A-Z]*$||\s$");
            var match = regex.Match(nombre);
            if (match.Success)
            {
                return true;
            }
            return false;
        }

        public List<Usuarios> ObtenerLista(string filtro)
        {
            var list = new List<Usuarios>();
            list = _usuariosAccesoDatos.ObtenerLista(filtro);
            return list;
        }

        public Tuple<bool, string> EsUsuarioValido(Usuarios usuario)
        {
            string Msj = "";
            bool valido = true;

            if (usuario.Nombre.Length ==0)
            {
                Msj = "El nombre de usuario esta vacio";
                valido = false;
            }
            else if (!NombreValido(usuario.Nombre))
            {
                Msj = "El escribe un formato valido para el nombre";
                valido = false;

            }
            else if (usuario.Nombre.Length >15)
            {
                Msj = "La longitud para nombre de usuario es maximo 15 Caracteres";
                valido = false;
            }
            

            return Tuple.Create(valido, Msj);
        }

    }
}
