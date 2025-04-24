using System.Collections.ObjectModel;

namespace Proyecto5.Pages;

public partial class ContactosPage : ContentPage
{
    public static ObservableCollection<Contacto> ListaContactos { get; set; } = new ObservableCollection<Contacto>();

    public ContactosPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public ObservableCollection<Contacto> Contactos => ListaContactos;

    public class Contacto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
    private async void AgregarContacto_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearContactoPage());
    }
}