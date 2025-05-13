using Practica5.ViewModel;

namespace Practica5.View;

public partial class DetalleContactoPage : ContentPage
{
	public DetalleContactoPage()
	{
		InitializeComponent();
        BindingContext = new DetalleContactoVM();
    }
    private async void OnVolverClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}