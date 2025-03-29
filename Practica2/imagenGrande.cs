using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica2
{
    public partial class imagenGrande : Form
    {
        public imagenGrande(string imagenPath, string nombreImagen)
        {
            InitializeComponent();
            // Se utiliza el camino que se haya creado a la carpeta, y se le asigna el nombre
            pictureBox1.ImageLocation = imagenPath;
            this.Text = nombreImagen;

            // Permite hacer que la imagen utilice el modo zoom, que permite ser mas estetica que redimensionarla de forma bruta
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.Resize += imgGrande_Resize;
        }

        // Esta función permite la redimensión del form, haciendo que se adapte al tamaño que se le de. Hay que tener en cuenta de que la
        // dimensión minima dada es de 1280x720
        private void imgGrande_Resize(object sender, EventArgs e)
        {
            pictureBox1.Width = this.ClientSize.Width;
            pictureBox1.Height = this.ClientSize.Height;

            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2;
        }
    }
}
