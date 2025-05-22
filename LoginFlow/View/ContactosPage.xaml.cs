using Practica5.Model;
using Practica5.ViewModel;
namespace Practica5.View;

public partial class ContactosPage : ContentPage
{
	public ContactosPage()
	{
		InitializeComponent();
        BindingContext = new ContactosVM();
    }
}