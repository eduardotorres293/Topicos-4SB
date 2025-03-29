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

namespace Practica2
{
    public partial class Form1 : Form
    {
        // Clase de lista que permite guardar las imagenes para mostrarlas despues
        private string[] imagenes;
        public Form1()
        {
            InitializeComponent();
            CargarImagenes();
            MostrarImagen();
            this.Resize += Form1_Resize;
        }

        // Función que permite cargar las imagenes desde una carpeta asignada, para despues mostrarlas mediante otra función
        private void CargarImagenes()
        {
            string carpeta = Path.Combine(Application.StartupPath, @"..\..\Imagenes"); // Mediante un Path se crea la ruta a la carpeta de imagenes que est+a junto a la solución
            // Primero verifica si dicha carpeta existe mediante el uso del directorio
            if (Directory.Exists(carpeta))
            {
                // Se usa la variable imagenes, y se le asigna en base a la imagen que haya conseguido en la carpeta
                imagenes = Directory.GetFiles(carpeta, "*.jpg") // Para archivos jpg
                    .Concat(Directory.GetFiles(carpeta, "*.png")) // Para archivos png
                    .Concat(Directory.GetFiles(carpeta, "*.jpeg")) // Para archivos jpeg
                    .Concat(Directory.GetFiles(carpeta, "*.jfif")) // Para archivos jfif (archivos raros de ver, pero pueden llegar a ser utilizados)
                    .Concat(Directory.GetFiles(carpeta, "*.gif")) // Para archivos gif, que requieran movimiento
                    .ToArray();
                // Este es una forma de verificar si no hay archivos en el programa
                if (imagenes.Length == 0) // Si el tamaño de las imagenes es igual a 0, entonces se muestra el label cuyo texto es "No hay imagenes para mostrar"
                {
                    label1.Visible = true; // Se hace true
                }
                else
                {
                    label1.Visible = false; // Si no es el caso, entonces no se muestra dicho label
                }
            }
            // Si dicha carpeta no existe, entonces se hace un mensaje de error donde menciona que no hay una carpeta asignada o no existe
            else
            {
                MessageBox.Show("La carpeta no existe o no está asignada");
                imagenes = new string[0];
            }
        }

        // Esta función permite redimensionar el form 1 para que se adapten las imagenes a su tamaño
        private void Form1_Resize(object sender, EventArgs e)
        {
            int anchoPanel = flowLayoutPanel2.Width;
            int numeroDeImagenesPorFila = anchoPanel / 220;
            if (numeroDeImagenesPorFila == 0)
            {
                numeroDeImagenesPorFila = 1; 
            }
            int nuevoAncho = (anchoPanel / numeroDeImagenesPorFila) - 10;

            foreach (PictureBox pictureBox in flowLayoutPanel2.Controls)
            {
                pictureBox.Width = nuevoAncho;
                pictureBox.Height = nuevoAncho;
            }
        }
        // Y esta función permite mostrar las imagenes
        private void MostrarImagen()
        {
            // Primero se limpia el layout y despues se verifica que si haya imagenes mediante un if
            flowLayoutPanel2.Controls.Clear();

            if (imagenes.Length > 0)
            {
                foreach (var imagen in imagenes)
                {
                    // Se crea una nueva pictureBox por cada imagen que haya
                    PictureBox pictureBox = new PictureBox
                    {
                        // Se utiliza la localización de la imagen conseguida con la ruta
                        ImageLocation = imagen,
                        SizeMode = PictureBoxSizeMode.StretchImage, //Se asigna a la picture box la propiedad de ajustar imagen, que permitirá mostrar las imagenes en pequeño
                        Width = 200, //Se le dan dimensiones a cada pictureBox, se 200x200
                        Height = 200,
                        Margin = new Padding(10) // Y un margen de 10 px para que no esten todas pegadas
                    };
                    // Mediante esta funcion Click se le permite a la imagen que, cuando se presione, abrir la funcion abrirForm con dicha imagen
                    pictureBox.Click += (sender, e) => abrirForm(imagen);
                    flowLayoutPanel2.Controls.Add(pictureBox);
                }
            }
        }
        // Esta funcion permite mostrar la imagen a mayor tamaño
        private void abrirForm(string imagen)
        {
            // Primero se consigue el nombre de la imagen en cuestion pero sin usar su extension, con el puro nombre.
            // Es decir, sin .png ni .jpg
            string nombreImagen = Path.GetFileNameWithoutExtension(imagen);
            // Despues se crea un constructor con el form de la imagen con los parametros que hayan de la imagen y su nombre
            imagenGrande imagenFormulario = new imagenGrande(imagen, nombreImagen);
            // Con esto se llama al formulario
            imagenFormulario.Show();
        }
        // Este boton permite abrir la carpeta de las imagenes para poder interactuar con ellas desde el explorador de archivos
        private void button3_Click(object sender, EventArgs e)
        {
            // Se busca abrir la carpeta de vuelta, utilizando la ruta de Path
            string openFolder = Path.Combine(Application.StartupPath, @"..\..\Imagenes");
            // Se abre mediante el uso del sistema
            System.Diagnostics.Process.Start(openFolder);
        }
        // Este boton permite refrescar la galeria, permitiendo actualizarla en caso de errores
        private void button1_Click(object sender, EventArgs e)
        {
            // Simplemente se vuelven a llamar las mismas funciones
            CargarImagenes();
            MostrarImagen();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // Se crea una instancia del OpenFileDialog
            // Primero se filtran solo las posibles imagenes
            openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.gif;*.tiff";
            openFileDialog.Title = "Seleccionar una imagen"; // Se le pone un titulo a la ventana emergente

            // Mostrar el cuadro de diálogo para seleccionar una imagen
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Se obtiene la ruta de la imagen, y despues se le asigna la carpeta de destino
                string imagenSeleccionada = openFileDialog.FileName;
                string imagesFolder = Path.Combine(Application.StartupPath, @"..\..\Imagenes");

                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                // Obtener el nombre del archivo (sin la ruta completa) y despues se pone en la carpeta destino
                string nombreImagen = Path.GetFileName(imagenSeleccionada);
                string rutaDestino = Path.Combine(imagesFolder, nombreImagen);

                try
                {
                    // Se copia la imagen a la carpeta final
                    File.Copy(imagenSeleccionada, rutaDestino, true);
                }
                catch
                {
                    MessageBox.Show("Ocurrió un error al copiar la imagen");
                }
            }
            CargarImagenes();
            MostrarImagen();
        }
    }
}
