using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Practica5.ViewModel
{
    internal class ConfiguracionVM : BaseVM
    {
        private bool _notificacionesActivadas;
        public bool NotificacionesActivadas
        {
            get => _notificacionesActivadas;
            set => SetProperty(ref _notificacionesActivadas, value);
        }

        public ICommand CambiarTemaCommand { get; }

        public ConfiguracionVM()
        {
            CambiarTemaCommand = new Command(() => {
                // Lógica de cambio de tema aquí
            });
        }
    }
}
