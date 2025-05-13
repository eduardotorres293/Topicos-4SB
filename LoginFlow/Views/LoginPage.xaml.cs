namespace LoginFlow.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }
    Dictionary<string, string> usuariosRegistrados = new();
    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private async void TapGestureRecognizerPwd_Tapped(object sender, TappedEventArgs e)
    {
        string usuario = await DisplayPromptAsync("Recuperar contraseña", "Ingresa tu usuario:");
        if (string.IsNullOrWhiteSpace(usuario)) return;

        if (usuariosRegistrados.ContainsKey(usuario))
        {
            string pwd = usuariosRegistrados[usuario];
            await DisplayAlert("Recuperación", $"Tu contraseña es: {pwd}", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Usuario no encontrado", "OK");
        }
    }

    private async void TapGestureRecognizerReg_Tapped(object sender, TappedEventArgs e)
    {
        string nuevoUsuario = await DisplayPromptAsync("Registro", "Ingresa un nombre de usuario:");
        if (string.IsNullOrWhiteSpace(nuevoUsuario)) return;

        string nuevaPassword = await DisplayPromptAsync("Registro", "Ingresa una contraseña:", "Registrar", "Cancelar", "", -1, Keyboard.Text);
        if (string.IsNullOrWhiteSpace(nuevaPassword)) return;

        if (usuariosRegistrados.ContainsKey(nuevoUsuario))
        {
            await DisplayAlert("Error", "El usuario ya está registrado", "OK");
        }
        else
        {
            usuariosRegistrados[nuevoUsuario] = nuevaPassword;
            await DisplayAlert("Registro exitoso", $"Usuario {nuevoUsuario} registrado", "OK");
        }
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (IsCredentialCorrect(Username.Text, Password.Text))
        {
            Preferences.Set("UsuarioActual", Username.Text.Trim());
            await SecureStorage.SetAsync("hasAuth", "true");
            await Shell.Current.GoToAsync("///home");
        }
        else
        {
            Preferences.Remove("UsuarioActual");
            await DisplayAlert("Login failed", "Username or password if invalid", "Try again");
        }
    }


    bool IsCredentialCorrect(string username, string password)
    {
        return (username == "admin" && password == "1234") ||
           (usuariosRegistrados.ContainsKey(username) && usuariosRegistrados[username] == password);
    }
}