using Practica5.ViewModel;

namespace Practica5.View;

public partial class CrearContactoPage : ContentPage
{
	public CrearContactoPage()
	{
		InitializeComponent();
        BindingContext = new CrearContactoVM();
    }
}