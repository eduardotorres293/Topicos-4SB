using System.Collections.ObjectModel;

namespace Practica_5;

public partial class ContactosPage : ContentPage
{
    public ObservableCollection<Contacto> Contactos { get; set; }
    public ContactosPage()
	{
		InitializeComponent();
        Contactos = new ObservableCollection<Contacto>
        {
            new Contacto { Nombre = "Juan Pérez", Telefono = "1234567890", Correo = "juan@correo.com" },
            new Contacto { Nombre = "Ana López", Telefono = "0987654321", Correo = "ana@correo.com" }
        };
        BindingContext = this;
    }
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
    
}