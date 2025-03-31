using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AccesoBaseDatos1
{
    internal class ClaseSQLServer
    {
        private string Servidor = "DESKTOP-CC63E9C\\TEW_SQLEXPRESS";
        private string Basedatos = "master";
        private string UsuarioId = "sa";
        private string Password = "1234";

        /// <summary>
        /// Obtiene la cadena de conexión para SQL Server.
        /// </summary>
        /// <returns>Cadena de conexión a SQL Server.</returns>
        private string ObtenerCadenaConexion()
        {
            return $"Server={Servidor};Database={Basedatos};User Id={UsuarioId};Password={Password}";
        }

        /// <summary>
        /// Ejecuta un comando SQL en SQL Server.
        /// </summary>
        /// <param name="ConsultaSQL">Consulta SQL a ejecutar.</param>
        public void EjecutarComando(string ConsultaSQL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ObtenerCadenaConexion()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(ConsultaSQL, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show($"Error SQL Server: {Ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene datos de SQL Server según la consulta dada.
        /// </summary>
        /// <param name="consulta">Consulta SQL para obtener datos.</param>
        /// <returns>DataTable con los resultados de la consulta.</returns>
        public DataTable ObtenerDatos(string consulta)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ObtenerCadenaConexion()))
                {
                    conn.Open();
                    using (SqlDataAdapter adp = new SqlDataAdapter(consulta, conn))
                    {
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show($"Error SQL Server: {Ex.Message}");
                return null;
            }
        }
    }
}
