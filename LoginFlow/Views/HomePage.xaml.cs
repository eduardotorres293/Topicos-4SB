namespace LoginFlow.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();

        lblNombre.Text = Preferences.Get("UsuarioActual", "??");

    }
}