using LoginFlow.ViewModel;
using Practica5.Model;

namespace LoginFlow.View;

[QueryProperty(nameof(Contacto), "Contacto")]
public partial class EditarContactoPage : ContentPage
{
    private readonly EditarContactoVM _viewModel;

    public Contacto Contacto
    {
        get => _viewModel.Contacto;
        set => _viewModel.Contacto = value;
    }

    public EditarContactoPage()
    {
        InitializeComponent();
        _viewModel = new EditarContactoVM();
        BindingContext = _viewModel;
    }
}