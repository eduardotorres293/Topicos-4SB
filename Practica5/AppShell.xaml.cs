using Practica5.View;

namespace Practica5
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DetalleContactoPage), typeof(DetalleContactoPage));
        }
    }
}
