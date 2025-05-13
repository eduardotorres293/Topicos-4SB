using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
