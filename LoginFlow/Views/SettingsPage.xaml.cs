using Practica5.ViewModel;

namespace LoginFlow.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
        BindingContext = new ConfiguracionVM();
    }

	private async void LogoutButton_Clicked(object sender, EventArgs e)
	{
		if (await DisplayAlert("Are you sure?", "You will be logged out.", "Yes", "No"))
		{
            Preferences.Remove("UsuarioActualId");
            Preferences.Remove("UsuarioActualNombre");
            await SecureStorage.SetAsync("hasAuth", "false");
            await Shell.Current.GoToAsync("///login");
		}
	}
}