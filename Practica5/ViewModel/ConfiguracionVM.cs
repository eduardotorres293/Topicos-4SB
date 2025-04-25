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
            get => Preferences.Get(nameof(NotificacionesActivadas), false);
            set
            {
                if (SetProperty(ref _notificacionesActivadas, value))
                {
                    Preferences.Set(nameof(NotificacionesActivadas), value);
                }
            }
        }

        public ICommand CambiarTemaCommand { get; }

        public ConfiguracionVM()
        {
            CambiarTemaCommand = new Command(CambiarTema);
        }
        private void CambiarTema()
        {
            var temaActual = Application.Current.UserAppTheme;

            Application.Current.UserAppTheme =
                temaActual == AppTheme.Dark ? AppTheme.Light : AppTheme.Dark;
        }
    }
}
