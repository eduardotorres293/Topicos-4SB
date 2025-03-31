using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AccesoBaseDatos1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Instancia para ejecutar comandos en MySQL.
        /// </summary>
        private ClaseMySQL ejecutaMySql = new ClaseMySQL();

        /// <summary>
        /// Instancia para ejecutar comandos en SQL Server.
        /// </summary>
        private ClaseSQLServer ejecutaSqlServer = new ClaseSQLServer();

        /// <summary>
        /// Ejecuta un comando SQL en la base de datos seleccionada.
        /// </summary>
        /// <param name="ConsultaSQL">Consulta SQL a ejecutar.</param>
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

        /// <summary>
        /// Llena el DataGridView con los datos de la tabla "Alumnos".
        /// </summary>
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

        /// <summary>
        /// Constructor de la clase Form1.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea una base de datos llamada "ESCOLAR".
        /// </summary>
        private void btnCrearBD_Click(object sender, EventArgs e)
        {
            EjecutaComando("CREATE DATABASE ESCOLAR");
        }

        /// <summary>
        /// Crea la tabla "Alumnos" en la base de datos seleccionada.
        /// </summary>
        private void btnCreaTabla_Click(object sender, EventArgs e)
        {
            EjecutaComando("CREATE TABLE Alumnos (NoControl varchar(10), nombre varchar(50), carrera int)");
        }

        /// <summary>
        /// Inserta un nuevo alumno en la base de datos.
        /// </summary>
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

        /// <summary>
        /// Elimina un alumno de la base de datos mediante su número de control.
        /// </summary>
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

        /// <summary>
        /// Actualiza la información de un alumno en la base de datos.
        /// </summary>
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

        /// <summary>
        /// Busca un alumno en la base de datos mediante su número de control.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta cuando el formulario carga, llena el DataGridView.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        /// <summary>
        /// Refresca los datos en el DataGridView.
        /// </summary>
        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }
    }
}
