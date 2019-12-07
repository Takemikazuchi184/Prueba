using System;
using System.Collections.Generic;
using Entidades.ControlEscolarApp;
using ConexionBd;
using System.Data;

namespace AccesoDatos.ControlEscolarApp
{
    public class UsuariosAccesoDatos
    {
        Conexion _conexion;

        public UsuariosAccesoDatos()
        {
            _conexion = new Conexion("localhost", "sa", "Mexico", "escolar");
        }

        public void Eliminar(int idUsuario)
        {
            string cadena = string.Format("Delete from usuario where idusuario = {0}", idUsuario);
            _conexion.EjecutarConsulta(cadena);
        }

        public void Guardar(Usuarios usuario)
        {
            if (usuario.IdUsuario == 0)
            {
                string cadena = string.Format("INSERT INTO usuario VALUES('{0}','{1}','{2}')", usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno);
                _conexion.EjecutarConsulta(cadena);
            }
            else
            {
                
                string consulta = string.Format("update usuario set nombre ='{0}', apellidopaterno = '{1}', apellidomaterno ='{2}' where idusuario ={3}"
                    ,usuario.Nombre,usuario.ApellidoPaterno,usuario.ApellidoMaterno,usuario.IdUsuario);
                _conexion.EjecutarConsulta(consulta);
            }
        }

        public List<Usuarios> ObtenerLista(string filtro)
        {
            var list = new List<Usuarios>();
            string consulta = string.Format("select * from usuario where nombre like '%{0}%'", filtro);
            var ds = _conexion.ObtenerDatos(consulta, "usuario");
            var dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var usuario = new Usuarios
                {
                    IdUsuario = Convert.ToInt32(row["idusuario"]),
                    Nombre = row["nombre"].ToString(),
                    ApellidoMaterno = row["apellidomaterno"].ToString(),
                    ApellidoPaterno = row["apellidopaterno"].ToString()
                };

                list.Add(usuario);

            }

            return list;

        }
    }
}
