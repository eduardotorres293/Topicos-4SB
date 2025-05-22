using Practica5.ViewModel;
using Practica5.Model;

namespace Practica5.View;

[QueryProperty(nameof(Contacto), "Contacto")]
public partial class DetalleContactoPage : ContentPage
{

    private readonly DetalleContactoVM _viewModel;
    public Contacto Contacto
    {
        get => _viewModel.Contacto!;
        set => _viewModel.Contacto = value;
    }

    public DetalleContactoPage()
    {
        InitializeComponent();
        _viewModel = new DetalleContactoVM();
        BindingContext = _viewModel;
    }
}
