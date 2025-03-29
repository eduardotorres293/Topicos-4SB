using System;
using System.Collections.Generic;
using System.Linq; // Esta libreria se utiliza en el caso 3 para verificar 
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica3
{
    /// <summary>
    /// Clase para la validación de entradas de texto. Contiene varios métodos para verificar si el texto ingresado cumple con criterios específicos.
    /// </summary>
    public class InputValidator
    {
        /// <summary>
        /// Verifica si el texto contiene solo números, utilizando expresiones regulares (Regex).
        /// </summary>
        /// <param name="texto">El texto a verificar.</param>
        /// <returns>Retorna <c>true</c> si el texto contiene solo números, de lo contrario <c>false</c>.</returns>
        // CASO 1: Verificación mediante Regex
        public bool EsSoloNumeros(string texto)
        {
            // Verifica que el texto no esté vacío y que coincida con el patrón de solo números.
            return !string.IsNullOrWhiteSpace(texto) && Regex.IsMatch(texto, @"^\d+$");
        }

        /// <summary>
        /// Verifica si el texto contiene solo letras, utilizando expresiones regulares (Regex).
        /// </summary>
        /// <param name="texto">El texto a verificar.</param>
        /// <returns>Retorna <c>true</c> si el texto contiene solo letras, de lo contrario <c>false</c>.</returns>
        public bool EsSoloLetras(string texto)
        {
            // Verifica que el texto no esté vacío y que coincida con el patrón de solo letras (mayúsculas y minúsculas).
            return !string.IsNullOrWhiteSpace(texto) && Regex.IsMatch(texto, @"^[A-Za-z]+$");
        }

        // CASO 2: Verificación mediante KeyChar (comentado, no se está usando en este momento).
        // Estas funciones verificarían la entrada de teclado en tiempo real.
        //public bool EsSoloNumeros(KeyPressEventArgs e, string texto)
        //{
        //    // Verifica si la tecla presionada es un número. Si no lo es, cancela la acción (e.Handled = true).
        //    if (e.KeyChar < 48 || e.KeyChar > 57)
        //    {
        //        e.Handled = true;
        //        return false;
        //    }
        //    return true;
        //}
        //
        //public bool EsSoloLetras(KeyPressEventArgs e, string texto)
        //{
        //    // Verifica si la tecla presionada es una letra (mayúscula o minúscula). Si no lo es, cancela la acción.
        //    if ((e.KeyChar < 65 || e.KeyChar > 90) && (e.KeyChar < 97 || e.KeyChar > 122))
        //    {
        //        e.Handled = true;
        //        return false;
        //    }
        //    return true;
        //}

        // CASO 3: Verificación mediante métodos con LINQ.
        // Esta es otra forma de validar la entrada, usando el método All para verificar si todos los caracteres son números o letras.

        //public bool EsSoloNumeros(string texto)
        //{
        //    // Verifica si el texto contiene solo dígitos, usando LINQ.
        //    if (string.IsNullOrWhiteSpace(texto))
        //    {
        //        return false;
        //    }
        //    return texto.All(char.IsDigit);
        //}

        //public bool EsSoloLetras(string texto)
        //{
        //    // Verifica si el texto contiene solo letras, usando LINQ.
        //    if (string.IsNullOrWhiteSpace(texto))
        //    {
        //        return false;
        //    }
        //    return texto.All(char.IsLetter);
        //}

        // CASO 4: Verificación mediante ASCII sin interfaces gráficas.
        // Estas funciones validan el texto sin usar expresiones regulares ni LINQ, verificando el código ASCII de cada carácter.

        // public bool EsSoloNumeros(string texto)
        //{
        //    // Verifica que todos los caracteres en el texto sean dígitos, comparando su código ASCII.
        //    if (string.IsNullOrWhiteSpace(texto))
        //    {
        //        return false;
        //    }
        //
        //    for (int i = 0; i < texto.Length; i++)
        //    {
        //        if (texto[i] < 48 || texto[i] > 57)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        //
        //public bool EsSoloLetras(string texto)
        //{
        //    // Verifica que todos los caracteres en el texto sean letras, comparando su código ASCII.
        //    if (string.IsNullOrWhiteSpace(texto))
        //        return false;
        //
        //    for (int i = 0; i < texto.Length; i++)
        //    {
        //        if ((texto[i] < 65 || texto[i] > 90) && (texto[i] < 97 || texto[i] > 122))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}
