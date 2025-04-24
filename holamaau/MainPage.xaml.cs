namespace Practica5
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void IrListaContactos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactosPage());
        }

        private async void IrCrearContacto(object sender, EventArgs e)
        {
            // Aquí puedes enlazar con otra página para crear un contacto
        }

        private async void IrConfiguracion(object sender, EventArgs e)
        {
            // Aquí puedes enlazar con una página de configuración
        }
    }
}
