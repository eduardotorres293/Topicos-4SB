using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica3
{
    /// <summary>
    /// Clase personalizada que extiende un control de tipo UserControl y encapsula un botón con eventos adicionales
    /// Esta clase agrega funcionalidad a un botón permitiendo cambiar su color de fondo al pasar el mouse por encima y mostrando un cuadro de mensaje
    /// cuando se realiza un doble clic sobre el botón
    /// </summary>
    public partial class btnExtendido : UserControl
    {
        /// <summary>
        /// Obtiene o establece el mensaje que se mostrará cuando se haga doble clic en el botón
        /// Este mensaje se muestra en un cuadro de diálogo de confirmación con opciones de sí/no
        /// El valor predeterminado es "Se realizó una acción de doble click, ¿Correcto?"
        /// </summary>
        public string MensajeDobleClick { get; set; } = "Se realizó una acción de doble click, ¿Correcto?";

        /// <summary>
        /// Obtiene o establece el título que se mostrará en el cuadro de diálogo de confirmación
        /// cuando se haga doble clic en el botón. El valor predeterminado es "Evento de doble click"
        /// </summary>
        public string TituloDobleClick { get; set; } = "Evento de doble click";

        /// <summary>
        /// Constructor de la clase <see cref="btnExtendido"/>.
        /// Este constructor inicializa los componentes del control y asocia manejadores de eventos al botón
        /// para detectar interacciones del usuario como el paso del mouse y el clic del mouse
        /// </summary>
        public btnExtendido()
        {
            InitializeComponent();
            // Asigna los eventos de mouse a sus respectivos manejadores de eventos
            // El evento MouseEnter cambia el color de fondo cuando el mouse entra en el botón
            button1.MouseEnter += Button1_MouseEnter;

            // El evento MouseLeave cambia el color de fondo cuando el mouse sale del botón
            button1.MouseLeave += Button1_MouseLeave;

            // El evento MouseDown maneja el doble clic sobre el botón y muestra un cuadro de confirmación
            button1.MouseDown += Button1_MouseDown;
        }

        /// <summary>
        /// Manejador de eventos que se activa cuando el mouse entra en el área del botón
        /// Este método cambia el color de fondo del botón a un color gris claro para indicar que el mouse está sobre el botón
        /// </summary>
        /// <param name="sender">El objeto que genera el evento. En este caso, el botón</param>
        /// <param name="e">Los argumentos del evento que proporcionan información sobre el evento de entrada del mouse</param>
        public void Button1_MouseEnter(object sender, EventArgs e)
        {
            // Cambia el color de fondo del botón a gris claro al pasar el mouse por encima.
            button1.BackColor = Color.LightGray;
        }

        /// <summary>
        /// Manejador de eventos que se activa cuando el mouse sale del área del botón
        /// Este método restaura el color de fondo del botón a su valor predeterminado, eliminando el color gris claro
        /// </summary>
        /// <param name="sender">El objeto que genera el evento. En este caso, el botón</param>
        /// <param name="e">Los argumentos del evento que proporcionan información sobre el evento de salida del mouse</param>
        public void Button1_MouseLeave(object sender, EventArgs e)
        {
            // Restaura el color de fondo del botón a su valor predeterminado
            button1.BackColor = default(Color);
        }

        /// <summary>
        /// Manejador de eventos que se activa cuando el usuario presiona el botón con el mouse
        /// Este método detecta si el clic fue un doble clic y, en caso afirmativo, muestra un cuadro de mensaje
        /// preguntando al usuario si confirma la acción
        /// </summary>
        /// <param name="sender">El objeto que genera el evento. En este caso, el botón</param>
        /// <param name="e">Los argumentos del evento que proporcionan información sobre el clic del mouse, como el botón presionado y el número de clics</param>
        public void Button1_MouseDown(object sender, MouseEventArgs e)
        {
            // Verifica si el botón presionado fue el izquierdo del mouse y si el número de clics es 2 (lo que indica un doble clic)
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                // Si es un doble clic, se muestra un cuadro de mensaje de confirmación con las opciones de Sí o No
                DialogResult confirmacion = MessageBox.Show(MensajeDobleClick, TituloDobleClick, MessageBoxButtons.YesNo);

                // Si el usuario confirma la acción (selecciona Sí), se muestra un mensaje indicando que la acción fue confirmada
                if (confirmacion == DialogResult.Yes)
                {
                    MessageBox.Show("Acción confirmada");
                }
                // Si el usuario deniega la acción (selecciona No), se muestra un mensaje indicando que la acción fue denegada
                else
                {
                    MessageBox.Show("Acción denegada");
                }
            }
        }
    }
}
