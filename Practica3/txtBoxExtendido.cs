using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica3
{
    /// <summary>
    /// Control de usuario personalizado que extiende un TextBox con validación del tipo de entrada (números, palabras o ambos).
    /// Este control permite configurar qué tipo de caracteres se pueden ingresar en el TextBox según el modo de entrada elegido.
    /// </summary>
    public partial class txtBoxExtendido : UserControl
    {
        /// <summary>
        /// Constructor de la clase <see cref="txtBoxExtendido"/>.
        /// Inicializa los componentes del control y asigna el manejador de eventos para validar la entrada de texto.
        /// </summary>
        public txtBoxExtendido()
        {
            InitializeComponent();
            // Asocia el evento KeyPress al método que valida la entrada de texto.
            textBox1.KeyPress += TxtInput_KeyPress;
        }

        /// <summary>
        /// Enum que define los modos posibles de entrada para el control: solo números, solo palabras o ambos.
        /// </summary>
        public enum valor
        {
            /// <summary>
            /// Solo se permiten números.
            /// </summary>
            NumbersOnly,

            /// <summary>
            /// Solo se permiten palabras (letras).
            /// </summary>
            WordsOnly,

            /// <summary>
            /// Se permiten tanto números como palabras.
            /// </summary>
            Both
        }

        /// <summary>
        /// Almacena el modo de entrada actual. El valor predeterminado es 'Both', es decir, se permiten tanto números como letras.
        /// </summary>
        public valor modoElegido = valor.Both;

        /// <summary>
        /// Propiedad para definir el modo de entrada del TextBox. Permite elegir si se aceptan números, palabras o ambos.
        /// </summary>
        [Category("Behavior")]
        [Description("Define si solo se aceptan números, letras o ambos.")]
        [DefaultValue(valor.Both)]
        public valor ModoDeEntrada
        {
            get { return modoElegido; }
            set { modoElegido = value; }
        }

        /// <summary>
        /// Propiedad que obtiene o establece el texto del TextBox.
        /// </summary>
        public string Texto
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        /// <summary>
        /// Evento que se activa cuando el usuario presiona una tecla dentro del TextBox.
        /// Este evento valida el carácter ingresado según el modo de entrada seleccionado (números, letras o ambos).
        /// </summary>
        /// <param name="sender">El objeto que genera el evento. En este caso, el TextBox.</param>
        /// <param name="e">Los argumentos del evento que contienen información sobre la tecla presionada.</param>
        public void TxtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool esInvalido = false;

            // Dependiendo del modo de entrada, se validan los caracteres permitidos.
            switch (modoElegido)
            {
                case valor.NumbersOnly:
                    // Si el modo es 'NumbersOnly', se permiten solo números.
                    if ((e.KeyChar >= 65 && e.KeyChar <= 122) && !char.IsControl(e.KeyChar))
                    {
                        // Si se ingresa un carácter no numérico, se marca como inválido y se bloquea la tecla.
                        e.Handled = true;
                        esInvalido = true;
                    }
                    break;

                case valor.WordsOnly:
                    // Si el modo es 'WordsOnly', se permiten solo letras.
                    if (!(e.KeyChar >= 65 && e.KeyChar <= 122) && !char.IsControl(e.KeyChar))
                    {
                        // Si se ingresa un carácter que no es una letra, se marca como inválido y se bloquea la tecla.
                        e.Handled = true;
                        esInvalido = true;
                    }
                    break;

                case valor.Both:
                    // Si el modo es 'Both', se permiten tanto números como letras, por lo que no se bloquea ninguna tecla.
                    break;
            }

            // Si la entrada es inválida, se cambia el color de fondo del TextBox a rosa y su borde a un estilo simple.
            if (esInvalido)
            {
                textBox1.BackColor = Color.LightPink;
                textBox1.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                // Si la entrada es válida, se restaura el color de fondo a su valor predeterminado y el borde a un estilo tridimensional.
                textBox1.BackColor = default(Color);
                textBox1.BorderStyle = BorderStyle.Fixed3D;
            }
        }
    }
}

