namespace LoginFlow.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        string nombreUsuario = Preferences.Get("UsuarioActualNombre", "??");

        lblNombre.Text = $"Bienvenido, {nombreUsuario}!";
    }
}