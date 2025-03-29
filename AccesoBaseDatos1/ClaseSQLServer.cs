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

        private string ObtenerCadenaConexion()
        {
            return $"Server={Servidor};Database={Basedatos};User Id={UsuarioId};Password={Password}";
        }

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
