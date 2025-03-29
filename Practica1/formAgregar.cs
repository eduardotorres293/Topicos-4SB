using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practica1
{
    public partial class formAgregar : Form
    {
        
        public event Action DatosGuardados;
        public formAgregar()
        {
            InitializeComponent();
        }
        private void txtTelefono_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 122) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) 
                || string.IsNullOrWhiteSpace(txtCorreoElectronico.Text))
            {
                MessageBox.Show("Es obligatorio rellenar todos los campos");
            }
            else
            {
                string textoNombre = txtNombre.Text;
                string textoTelefono = txtTelefono.Text;
                string textoCorreo = txtCorreoElectronico.Text;

                DialogResult result = MessageBox.Show("¿Estás seguro de qué deseas " +
                    "guardar a este contacto?", "Guardar contacto", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    string blocContactos = Path.Combine(Application.StartupPath, "Contactos.txt");
                    string linea = "Nombre del contacto: " + textoNombre + ", Número de teléfono: " 
                        + textoTelefono + ", Correo Electrónico: " + textoCorreo;

                    using (StreamWriter sw = new StreamWriter(blocContactos, true, Encoding.UTF8))
                    {
                        sw.WriteLine(linea);
                    }

                    DatosGuardados?.Invoke();

                    MessageBox.Show("Datos guardados correctamente");
                    txtCorreoElectronico.Clear();
                    txtTelefono.Clear();
                    txtNombre.Clear();
                }
                else
                {
                    MessageBox.Show("Los datos no fueron guardados");
                }
            }
        }
    }
}
