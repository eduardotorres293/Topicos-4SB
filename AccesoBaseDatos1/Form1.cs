using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AccesoBaseDatos1
{
    public partial class Form1 : Form
    {
        private string Servidor = "ACARDENAS\\SQLDEVELOP2008R2";
        private string Basedatos = "ESCOLAR";
        private string UsuarioId = "sa";
        private string Password = "sa2024";

        private void EjecutaComando(string ConsultaSQL)
        {
            try
            {
                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                if(chkSQLServer.Checked)
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = ConsultaSQL;
                    cmd.ExecuteNonQuery();
                }

                llenarGrid();

            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }
        private void llenarGrid()
        {
            try
            {
                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                if (chkSQLServer.Checked)
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();

                    string sqlQuery = "select * from Alumnos";
                    SqlDataAdapter adp = new SqlDataAdapter(sqlQuery, conn);

                    DataSet ds = new DataSet();
                    adp.Fill(ds, "Alumnos");
                    dgvAlumnos.DataSource = ds.Tables[0];
                }

                dgvAlumnos.Refresh();
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCrearBD_Click(object sender, EventArgs e)
        {
            try
            {              
                string strConn = $"Server={Servidor};" +
                    $"Database=master;" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                if (chkSQLServer.Checked)
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CREATE DATABASE ESCOLAR";
                    cmd.ExecuteNonQuery();

                }


            }
            catch (SqlException  Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex )
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private void btnCreaTabla_Click(object sender, EventArgs e)
        {
            EjecutaComando("CREATE TABLE " +
                    "Alumnos (NoControl varchar(10), nombre varchar(50), carrera int)");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length == 0 ||
                    txtNombre.Text.Trim().Length == 0 ||
                    txtCarrera.Text.Trim().Length == 0)
                {
                    string strConn = $"Server={Servidor};" +
                        $"Database={Basedatos};" +
                        $"User Id={UsuarioId};" +
                        $"Password={Password}";

                    if (chkSQLServer.Checked)
                    {
                        SqlConnection conn = new SqlConnection(strConn);
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO " +
                            "Alumnos (NoControl, nombre, carrera) " +
                            "VALUES ('" + txtNoControl.Text +
                            "', '" + txtNombre.Text +
                            "', " + txtCarrera.Text + ")";
                        cmd.ExecuteNonQuery();
                    }

                    llenarGrid();
                }

            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chkSQLServer.Checked = true;
            llenarGrid();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }
    }
}
