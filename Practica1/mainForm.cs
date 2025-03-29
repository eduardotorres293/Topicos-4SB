using System.Drawing.Drawing2D;

namespace Practica1
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        private void mainForm_Load(object sender, EventArgs e)
        {
            CargarContactos();
        }

        private void CargarContactos()
        {
            string blocContactos = Path.Combine(Application.StartupPath, "Contactos.txt");

            if (File.Exists(blocContactos))
            {
                string[] lineas = File.ReadAllLines(blocContactos);
                listBox1.Items.Clear();
                foreach (var linea in lineas)
                {
                    listBox1.Items.Add(linea);
                }
            }
            else
            {
                MessageBox.Show("No hay contactos guardados");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formAgregar agregar = new formAgregar();
            agregar.DatosGuardados += CargarContactos;
            agregar.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            string blocContactos = Path.Combine(Application.StartupPath, "Contactos.txt");

            if (File.Exists(blocContactos))
            {
                File.WriteAllText(blocContactos, string.Empty);
                listBox1.Items.Clear();

                MessageBox.Show("La lista de contactos ha sido vaciada.");
            }
            else
            {
                MessageBox.Show("No se ha encontrado el archivo de contactos.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string ctoSeleccionado = listBox1.SelectedItem.ToString();

                DialogResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar este contacto?", "Eliminar contacto", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    string blocContactos = Path.Combine(Application.StartupPath, "Contactos.txt");
                    var lineas = File.ReadAllLines(blocContactos).Where(linea => linea != ctoSeleccionado).ToArray();
                    File.WriteAllLines(blocContactos, lineas);
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(lineas);
                    MessageBox.Show("Contacto eliminado correctamente");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un contacto");
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creado por José Eduardo Torres Iturbe" + Environment.NewLine + "Grupo 4sB" + 
                Environment.NewLine + "Matricula: 23760375" + Environment.NewLine + Environment.NewLine + "Este programa fue hecho con el " +
                "propósito de funcionar como un gestor de contactos, donde el usuario pueda agregar e interactuar con los " +
                "contactos que se introduzcan mediante el uso de componentes gráficos.");
        }
    }
}