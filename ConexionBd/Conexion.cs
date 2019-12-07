using System.Data.SqlClient;
using System.Data;

namespace ConexionBd
{
    public class Conexion
    {
        SqlConnection _conn;

        public Conexion(string server, string user, string password, string database)
        {
            SqlConnectionStringBuilder chaings = new SqlConnectionStringBuilder();
            chaings.DataSource = server;
            chaings.InitialCatalog = database;
            chaings.UserID = user;
            chaings.Password = password;
            _conn = new SqlConnection(chaings.ToString());
        }

        public void EjecutarConsulta(string cadena)
        {
            _conn.Open();
            SqlCommand cmm = new SqlCommand(cadena, _conn);
            cmm.ExecuteNonQuery();
            _conn.Close();
        }

        public DataSet ObtenerDatos(string cadena, string tabla)
        {
            var ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cadena, _conn);
            da.Fill(ds, tabla);

            return ds;
        }

        public int Existe(string cadena)
        {
            var res = 0;

            var Conexion = new SqlConnection
             ("Data Source= DESKTOP-SF4MOEM; " +
             "Initial Catalog=escolar; " +
             "User ID=sa; Password=Mexico");
            var Inserta = new SqlCommand(cadena, Conexion);
            try
            {
                Conexion.Open();
                res = int.Parse(Inserta.ExecuteScalar().ToString());
                Conexion.Close();
            }
            catch (System.Exception)
            {

                Conexion.Close();
            }

            return res;

        }

    }
}
