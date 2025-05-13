namespace Practica5;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;

        var registeredUsername = Preferences.Get("registeredUsername", "");
        var registeredPassword = Preferences.Get("registeredPassword", "");

        if (username == registeredUsername && password == registeredPassword)
        {
            await DisplayAlert("Éxito", "Ha ingresado correctamente", "OK");
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Error", "Los datos no son correctos", "OK");
        }
    }
    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Ingrese un usuario y contraseña", "OK");
            return;
        }

        Preferences.Set("registeredUsername", username);
        Preferences.Set("registeredPassword", password);

        await DisplayAlert("Registrado", "Se registró correctamente", "OK");
    }
    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string registeredUsername = Preferences.Get("registeredUsername", null);
        string registeredPassword = Preferences.Get("registeredPassword", null);

        if (!string.IsNullOrEmpty(registeredPassword))
        {
            await DisplayAlert("Recuperar contraseña", $"Tu contraseña es: {registeredPassword}", "OK");
        }
        else
        {
            await DisplayAlert("Error", "No hay contraseña registrada para este usuario.", "OK");
        }
    }

}