using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Practica5.ViewModel
{
    internal class MainPageVM : BaseVM
    {
        public ICommand IrListaContactosCommand { get; }
        public ICommand IrCrearContactoCommand { get; }
        public ICommand IrConfiguracionCommand { get; }

        public MainPageVM()
        {
            IrListaContactosCommand = new Command(async () => await Shell.Current.GoToAsync("ContactosPage"));
            IrCrearContactoCommand = new Command(async () => await Shell.Current.GoToAsync("CrearContactoPage"));
            IrConfiguracionCommand = new Command(async () => await Shell.Current.GoToAsync("ConfiguracionPage"));
        }
    }
}
