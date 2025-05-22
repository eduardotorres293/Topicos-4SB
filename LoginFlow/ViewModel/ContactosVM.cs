using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Practica5.Model;
using Practica5.View;
using System.Diagnostics;

namespace Practica5.ViewModel
{
    internal class ContactosVM : BaseVM
    {
        public static ObservableCollection<Contacto> ListaContactos { get; } = new ObservableCollection<Contacto>
        {
            new Contacto { Nombre = "Juan Pérez", Telefono = "123456789", Correo = "juan@ejemplo.com", Direccion = "Calle 123" },
            new Contacto { Nombre = "Ana Gómez", Telefono = "987654321", Correo = "ana@ejemplo.com", Direccion = "Avenida 456" }
        };

        public ObservableCollection<Contacto> Contactos => ListaContactos;

        public ICommand MostrarDetalleCommand { get; }

        public ContactosVM()
        {
            MostrarDetalleCommand = new Command<Contacto>(MostrarDetalle);
        }

        private async void MostrarDetalle(Contacto contacto)
        {
            if (contacto == null)
                return;

            try
            {
                await Shell.Current.GoToAsync("DetalleContactoPage", true, new Dictionary<string, object>
                {
                    { "Contacto", contacto }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al navegar: {ex.Message}");
            }
        }
    }
}
