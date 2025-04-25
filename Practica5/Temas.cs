using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Practica5.Resources.Styles;


namespace Practica5
{
    public static class Temas
    {
        public static void AsignarTema(bool darkMode)
        {
            ResourceDictionary newTheme = darkMode
                ? new DarkTheme()
                : new LightTheme();

            if (Application.Current.Resources.TryGetValue("ActiveTheme", out var activeThemeObj)
                && activeThemeObj is ResourceDictionary activeTheme)
            {
                activeTheme.MergedDictionaries.Clear();
                activeTheme.MergedDictionaries.Add(newTheme);
            }
        }
    }
}
