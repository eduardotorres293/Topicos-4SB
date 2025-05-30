using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Practica5.Model;
using Practica5.ViewModel;
using AgendaApp.Datos;

namespace LoginFlow.ViewModel
{
    [QueryProperty(nameof(Contacto), "Contacto")]
    public class EditarContactoVM : BaseVM
    {
        private readonly ContactoDatabase _database;

        private Contacto _contacto;
        public Contacto Contacto
        {
            get => _contacto;
            set => SetProperty(ref _contacto, value);
        }

        public ICommand GuardarCambiosCommand { get; }

        public EditarContactoVM()
        {
            _database = new ContactoDatabase();
            GuardarCambiosCommand = new Command(async () => await GuardarCambios());
        }

        private async Task GuardarCambios()
        {
            if (string.IsNullOrWhiteSpace(Contacto?.Nombre) || string.IsNullOrWhiteSpace(Contacto?.Telefono))
            {
                await Shell.Current.DisplayAlert("Error", "Nombre y teléfono son obligatorios.", "OK");
                return;
            }

            await _database.GuardarContactoAsync(Contacto);

            var existente = ContactosVM.ListaContactos.FirstOrDefault(c => c.Id == Contacto.Id);
            if (existente != null)
            {
                int index = ContactosVM.ListaContactos.IndexOf(existente);
                ContactosVM.ListaContactos[index] = Contacto;
            }

            await Shell.Current.DisplayAlert("Éxito", "Contacto actualizado correctamente", "OK");
        }
    }
}
