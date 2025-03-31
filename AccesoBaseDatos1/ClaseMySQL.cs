using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AccesoBaseDatos1
{
    internal class ClaseMySQL
    {
        private string Servidor = "localhost";
        private string Basedatos = "sys";
        private string UsuarioId = "root";
        private string Password = "";

        /// <summary>
        /// Obtiene la cadena de conexión para MySQL.
        /// </summary>
        /// <returns>Cadena de conexión a MySQL.</returns>
        private string ObtenerCadenaConexion()
        {
            return $"Server={Servidor};Database={Basedatos};User Id={UsuarioId};Password={Password}";
        }

        /// <summary>
        /// Ejecuta un comando SQL en MySQL.
        /// </summary>
        /// <param name="ConsultaSQL">Consulta SQL a ejecutar.</param>
        public void EjecutarComando(string ConsultaSQL)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ObtenerCadenaConexion()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(ConsultaSQL, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show($"Error MySQL: {Ex.Message}");
            }
        }

        /// <summary>
        /// Obtiene datos de MySQL según la consulta dada.
        /// </summary>
        /// <param name="consulta">Consulta SQL para obtener datos.</param>
        /// <returns>DataTable con los resultados de la consulta.</returns>
        public DataTable ObtenerDatos(string consulta)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ObtenerCadenaConexion()))
                {
                    conn.Open();
                    using (MySqlDataAdapter adp = new MySqlDataAdapter(consulta, conn))
                    {
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show($"Error MySQL: {Ex.Message}");
                return null;
            }
        }
    }
}
