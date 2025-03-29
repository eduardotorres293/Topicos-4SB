using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AccesoBaseDatos1
{
    public partial class Form1 : Form
    {
        private ClaseMySQL ejecutaMySql = new ClaseMySQL();
        private ClaseSQLServer ejecutaSqlServer = new ClaseSQLServer();

        private void EjecutaComando(string ConsultaSQL)
        {
            try
            {
                if (chkSQLServer.Checked)
                    ejecutaSqlServer.EjecutarComando(ConsultaSQL);
                else if (chkMySQL.Checked)
                    ejecutaMySql.EjecutarComando(ConsultaSQL);

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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoControl.Text))
            {
                MessageBox.Show("Debe ingresar un número de control válido");
                return;
            }

            string consulta = $"DELETE FROM Alumnos WHERE NoControl = '{txtNoControl.Text}'";
            EjecutaComando(consulta);
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoControl.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCarrera.Text))
            {
                MessageBox.Show("Es necesario llenar todos los campos");
                return;
            }

            string consulta = $"UPDATE Alumnos SET Nombre = '{txtNombre.Text}', Carrera = {txtCarrera.Text} WHERE NoControl = '{txtNoControl.Text}'";
            EjecutaComando(consulta);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoControl.Text))
            {
                MessageBox.Show("Ingrese un número de control válido para buscar");
                return;
            }

            DataTable datos = chkSQLServer.Checked
                ? ejecutaSqlServer.ObtenerDatos($"SELECT * FROM Alumnos WHERE NoControl = '{txtNoControl.Text}'")
                : ejecutaMySql.ObtenerDatos($"SELECT * FROM Alumnos WHERE NoControl = '{txtNoControl.Text}'");

            if (datos.Rows.Count > 0)
            {
                dgvAlumnos.DataSource = datos;
                dgvAlumnos.Refresh();
            }
            else
            {
                MessageBox.Show("No se encontraron registros.");
            }
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
