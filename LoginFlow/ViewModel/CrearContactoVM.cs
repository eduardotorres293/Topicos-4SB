using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Practica5.Model;

namespace Practica5.ViewModel
{
    internal class CrearContactoVM : BaseVM
    {
        private string _nombre;
        private string _telefono;
        private string _correo;
        private string _direccion;

        public string Nombre { get => _nombre; set => SetProperty(ref _nombre, value); }
        public string Telefono { get => _telefono; set => SetProperty(ref _telefono, value); }
        public string Correo { get => _correo; set => SetProperty(ref _correo, value); }
        public string Direccion { get => _direccion; set => SetProperty(ref _direccion, value); }

        public ICommand GuardarContactoCommand { get; }

        public CrearContactoVM()
        {
            GuardarContactoCommand = new Command(GuardarContacto);
        }

        private async void GuardarContacto()
        {
            var nuevoContacto = new Contacto
            {
                Nombre = this.Nombre,
                Telefono = this.Telefono,
                Correo = this.Correo,
                Direccion = this.Direccion
            };

            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Telefono))
            {
                await Shell.Current.DisplayAlert("Error", "Se debe introducir como minimo un nombre y telefono", "OK");
                return;
            }

            ContactosVM.ListaContactos.Add(nuevoContacto);
            await Shell.Current.DisplayAlert("Exito", "Contacto añadido correctamente", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}
