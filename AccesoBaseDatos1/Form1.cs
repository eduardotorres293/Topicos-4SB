using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AccesoBaseDatos1
{
    public partial class Form1 : Form
    {
        private EjecutaComandoMySql ejecutaMySql = new EjecutaComandoMySql();
        private EjecutaComandoSqlServer ejecutaSqlServer = new EjecutaComandoSqlServer();

        private void EjecutaComando(string ConsultaSQL)
        {
            try
            {
                if (chkSQLServer.Checked)
                    ejecutaSqlServer.Ejecutar(ConsultaSQL);
                else if (chkMySQL.Checked)
                    ejecutaMySql.Ejecutar(ConsultaSQL);

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
            DataTable datos = chkSQLServer.Checked
                ? ejecutaSqlServer.ObtenerDatos("SELECT * FROM Alumnos")
                : ejecutaMySql.ObtenerDatos("SELECT * FROM Alumnos");

            if (datos != null)
            {
                dgvAlumnos.DataSource = datos;
                dgvAlumnos.Refresh();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCrearBD_Click(object sender, EventArgs e)
        {
            EjecutaComando("CREATE DATABASE ESCOLAR");
        }

        private void btnCreaTabla_Click(object sender, EventArgs e)
        {
            EjecutaComando("CREATE TABLE " +
                    "Alumnos (NoControl varchar(10), nombre varchar(50), carrera int)");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoControl.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCarrera.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            string consulta = $"INSERT INTO Alumnos (NoControl, Nombre, Carrera) VALUES ('{txtNoControl.Text}', '{txtNombre.Text}', {txtCarrera.Text})";
            EjecutaComando(consulta);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }
    }
}
