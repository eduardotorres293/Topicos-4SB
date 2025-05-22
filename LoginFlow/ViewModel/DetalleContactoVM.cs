using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Practica5.Model;

namespace Practica5.ViewModel
{
    [QueryProperty(nameof(Contacto), "Contacto")]
    public class DetalleContactoVM : BaseVM
    {
        private Contacto? _contacto;
        public Contacto? Contacto
        {
            get => _contacto;
            set => SetProperty(ref _contacto, value);
        }
        public ICommand EliminarContactoCommand { get; }

        public DetalleContactoVM()
        {
            EliminarContactoCommand = new Command(async () => await EliminarContacto());
        }

        private async Task EliminarContacto()
        {
            if (Contacto == null)
                return;

            bool confirmacion = await Application.Current.MainPage.DisplayAlert(
                "Confirmar eliminación",
                $"¿Estás seguro de eliminar a {Contacto.Nombre}?",
                "Sí", "Cancelar");

            if (!confirmacion)
                return;

            if (ViewModel.ContactosVM.ListaContactos.Contains(Contacto))
            {
                ViewModel.ContactosVM.ListaContactos.Remove(Contacto);
            }

            await Application.Current.MainPage.DisplayAlert("Éxito", "Contacto eliminado", "OK");

            await Shell.Current.GoToAsync("..");
        }
    }

}
