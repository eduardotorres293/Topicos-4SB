using AgendaApp.Datos;
using LoginFlow.Model;

namespace LoginFlow.Views;

public partial class LoginPage : ContentPage
{
    private readonly ContactoDatabase _db = new();
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

        string correoIngresado = await DisplayPromptAsync("Registro", "Ingresa tu correo:");
        if (string.IsNullOrWhiteSpace(correoIngresado)) return;

        string nuevaPassword = await DisplayPromptAsync("Registro", "Ingresa una contraseña:", "Registrar", "Cancelar", "", -1, Keyboard.Text);
        if (string.IsNullOrWhiteSpace(nuevaPassword)) return;

        if (await _db.UsuarioExisteAsync(nuevoUsuario))
        {
            await DisplayAlert("Error", "El usuario ya está registrado", "OK");
        }
        else
        {
            await _db.RegistrarUsuarioAsync(new Usuario
            {
                Nombre = nuevoUsuario,
                Correo = correoIngresado,
                Password = nuevaPassword
            });
            await DisplayAlert("Registro exitoso", $"Usuario {nuevoUsuario} registrado", "OK");
        }
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (await IsCredentialCorrect(Username.Text, Password.Text))
        {
            await SecureStorage.SetAsync("hasAuth", "true");
            await Shell.Current.GoToAsync("///home");
        }
        else
        {
            Preferences.Remove("UsuarioActualId");
            Preferences.Remove("UsuarioActualNombre");
            await DisplayAlert("Login failed", "Username or password is invalid", "Try again");
        }
    }
    private async Task<bool> IsCredentialCorrect(string username, string password)
    {
        var usuario = await _db.ValidarUsuarioAsync(username, password);
        if (usuario != null)
        {
            Preferences.Set("UsuarioActualId", usuario.Id);
            Preferences.Set("UsuarioActualNombre", usuario.Nombre);
            return true;
        }
        return false;
    }
}