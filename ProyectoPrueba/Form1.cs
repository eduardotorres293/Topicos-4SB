using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practica3;

namespace ProyectoPrueba
{
    /// <summary>
    /// Formulario principal de la aplicación que maneja la interacción con el usuario.
    /// En este formulario se validan los datos de entrada y se gestionan las acciones de los controles.
    /// </summary>
    public partial class Form1 : Form
    {
        private InputValidator inputValidator; // Instancia de la clase InputValidator para validar datos de entrada

        /// <summary>
        /// Constructor de la clase Form1.
        /// Inicializa los componentes del formulario y asocia el evento MouseDown al botón extendido.
        /// </summary>
        public Form1()
        {
            InitializeComponent(); // Inicializa los controles de la interfaz gráfica.
            inputValidator = new InputValidator(); // Inicializa el validador de entradas.
            btnExtendido1.Controls[0].MouseDown += BtnExtendido_MouseDown; // Asocia el evento MouseDown al primer control dentro de btnExtendido1.
        }

        /// <summary>
        /// Evento que se dispara cuando el botón extendido es presionado (doble clic).
        /// Valida los datos introducidos por el usuario y los guarda si son correctos.
        /// </summary>
        /// <param name="sender">El objeto que disparó el evento.</param>
        /// <param name="e">Argumentos del evento MouseDown.</param>
        private void BtnExtendido_MouseDown(object sender, MouseEventArgs e)
        {
            btnExtendido1.MensajeDobleClick = "Hay datos introducidos, ¿Continuar?"; // Mensaje de confirmación al hacer doble clic.
            btnExtendido1.TituloDobleClick = "Confirmar"; // Título de la ventana de confirmación.

            RFCValidator rfcValidator = new RFCValidator(); // Instancia de la clase RFCValidator para validar el RFC.

            // Verifica si el evento fue un doble clic.
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                // Obtiene los valores de los campos de texto.
                string nombre = txtNombre.Texto;
                string telefono = txtTelefono.Texto;
                string correo = txtCorreo.Texto;
                string rfc = txtRFC.Texto;

                // Valida que el nombre contenga solo letras.
                if (!inputValidator.EsSoloLetras(nombre))
                {
                    MessageBox.Show("El nombre debe contener letras"); // Muestra mensaje si el nombre no es válido.
                    return; // Detiene la ejecución si la validación falla.
                }

                // Valida que el teléfono contenga solo números.
                if (!inputValidator.EsSoloNumeros(telefono))
                {
                    MessageBox.Show("El teléfono debe contener números"); // Muestra mensaje si el teléfono no es válido.
                    return; // Detiene la ejecución si la validación falla.
                }

                rfc = rfcValidator.CorregirRFC(rfc); // Corrige el RFC antes de validarlo.

                // Valida si el RFC es válido.
                if (!rfcValidator.validarRFC(rfc))
                {
                    MessageBox.Show("El RFC ingresado es inválido o está vacío"); // Muestra mensaje si el RFC no es válido.
                    return; // Detiene la ejecución si la validación falla.
                }

                // Prepara los datos para mostrarlos.
                string datos = $"Nombre: {nombre}, Teléfono: {telefono}, Correo: {correo}, RFC: {rfc}";

                // Muestra una ventana de confirmación preguntando si se desean guardar los datos.
                DialogResult resultado = MessageBox.Show("¿Deseas guardar estos datos?", "Confirmación", MessageBoxButtons.YesNo);

                // Si el usuario acepta, agrega los datos a la lista.
                if (resultado == DialogResult.Yes)
                {
                    listBox1.Items.Add(datos); // Agrega los datos al ListBox.
                }
                else
                {
                    MessageBox.Show("Los datos no han sido guardados."); // Muestra mensaje si el usuario cancela.
                }
            }
        }
    }
}
