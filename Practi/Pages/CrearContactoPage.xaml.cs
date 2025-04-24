namespace Proyecto5.Pages;

public partial class CrearContactoPage : ContentPage
{
	public CrearContactoPage()
	{
		InitializeComponent();
	}
    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        string nombre = entNombre.Text?.Trim();
        string telefono = entTelefono.Text?.Trim();
        string correo = entCorreo.Text?.Trim();
        string direccion = entDireccion.Text?.Trim();

        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(telefono))
        {
            await DisplayAlert("Error", "Se debe introducir como minimo un nombre y telefono", "OK");
            return;
        }

        var nuevoContacto = new ContactosPage.Contacto
        {
            Nombre = entNombre.Text,
            Telefono = entTelefono.Text,
            Correo = entCorreo.Text,
            Direccion = entDireccion.Text
        };

        ContactosPage.ListaContactos.Add(nuevoContacto);
        await DisplayAlert("Exito", "Contacto añadido correctamente.", "OK");
        await Navigation.PopAsync();
    }
}