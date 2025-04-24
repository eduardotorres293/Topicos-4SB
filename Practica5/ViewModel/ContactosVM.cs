using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica5.Model;

namespace Practica5.ViewModel
{
    internal class ContactosVM : BaseVM
    {
        public static ObservableCollection<Contacto> ListaContactos { get; } = new ObservableCollection<Contacto>
        {
            new Contacto { Nombre = "Ana", Telefono = "123456", Correo = "ana@email.com", Direccion = "Calle 1" },
            new Contacto { Nombre = "Luis", Telefono = "654321", Correo = "luis@email.com", Direccion = "Calle 2" }
        };

        public ObservableCollection<Contacto> Contactos => ListaContactos;
    }
}
