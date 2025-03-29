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

        private string ObtenerCadenaConexion()
        {
            return $"Server={Servidor};Database={Basedatos};User Id={UsuarioId};Password={Password}";
        }

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
