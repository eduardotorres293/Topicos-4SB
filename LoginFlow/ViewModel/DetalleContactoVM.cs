using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Practica5.Model;
using AgendaApp.Datos;

namespace Practica5.ViewModel
{
    [QueryProperty(nameof(Contacto), "Contacto")]
    public class DetalleContactoVM : BaseVM
    {
        private readonly ContactoDatabase _database;
        private Contacto? _contacto;
        public Contacto? Contacto
        {
            get => _contacto;
            set => SetProperty(ref _contacto, value);
        }
        public ICommand EliminarContactoCommand { get; }
        public ICommand EditarContactoCommand { get; }

        public DetalleContactoVM()
        {
            EliminarContactoCommand = new Command(async () => await EliminarContacto());
            EditarContactoCommand = new Command(async () => await EditarContacto());
            _database = new ContactoDatabase();
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

            await _database.EliminarContactoAsync(Contacto);
            var contactoGuard = ContactosVM.ListaContactos.FirstOrDefault(c => c.Id == Contacto.Id);
            if (contactoGuard != null)
            {
                ContactosVM.ListaContactos.Remove(contactoGuard);
            }

            await Application.Current.MainPage.DisplayAlert("Éxito", "Contacto eliminado", "OK");

            await Shell.Current.GoToAsync("..");
        }
        private async Task EditarContacto()
        {
            if (Contacto == null)
                return;

            await Shell.Current.GoToAsync("EditarContactoPage", true, new Dictionary<string, object>
            {
                { "Contacto", Contacto }
            });
        }
    }

}
