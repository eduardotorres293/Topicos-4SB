using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practica3
{
    /// <summary>
    /// Clase que valida y corrige el formato de un RFC (Registro Federal de Contribuyentes) en México.
    /// Esta clase puede verificar si el RFC proporcionado es válido y también corregirlo transformándolo a mayúsculas.
    /// </summary>
    public class RFCValidator
    {
        /// <summary>
        /// Valida si un RFC es válido según los formatos de persona física o persona moral.
        /// </summary>
        /// <param name="texto">El RFC a validar.</param>
        /// <returns>
        /// Retorna <c>true</c> si el RFC es válido para persona física o moral, de acuerdo con los patrones establecidos.
        /// Retorna <c>false</c> si el RFC no cumple con los formatos válidos.
        /// </returns>
        public bool validarRFC(string texto)
        {
            // Verifica si el RFC está vacío o es nulo.
            if (string.IsNullOrWhiteSpace(texto))
            {
                return false;
            }

            // Expresión regular para validar RFC de persona física (formato: 4 letras, 6 dígitos y 3 caracteres alfanuméricos).
            string personaFisica = @"^[A-Z]{4}\d{6}[A-Z0-9]{3}$";

            // Expresión regular para validar RFC de persona moral (formato: 3 letras, 6 dígitos y 3 caracteres alfanuméricos).
            string personaMoral = @"^[A-Z]{3}\d{6}[A-Z0-9]{3}$";

            // Retorna verdadero si el texto coincide con alguno de los formatos válidos.
            return Regex.IsMatch(texto, personaFisica) || Regex.IsMatch(texto, personaMoral);
        }

        /// <summary>
        /// Corrige el RFC proporcionado asegurándose de que esté en mayúsculas.
        /// </summary>
        /// <param name="texto">El RFC a corregir.</param>
        /// <returns>
        /// Retorna el RFC corregido en mayúsculas. Si el RFC ya está en mayúsculas o es nulo, se retorna tal cual.
        /// </returns>
        public string CorregirRFC(string texto)
        {
            // Si el RFC es nulo o contiene solo espacios en blanco, no se realiza ninguna corrección.
            if (string.IsNullOrWhiteSpace(texto))
            {
                return texto;
            }

            // Convierte el RFC a mayúsculas antes de devolverlo.
            texto = texto.ToUpper();
            return texto;
        }

        /// <summary>
        /// Determina si el RFC corresponde a una persona física.
        /// </summary>
        /// <param name="texto">El RFC a verificar.</param>
        /// <returns>
        /// Retorna <c>true</c> si el RFC corresponde a una persona física (cuya estructura es válida según el patrón).
        /// Retorna <c>false</c> si no es un RFC de persona física.
        /// </returns>
        public bool esPersonaFisica(string texto)
        {
            // Expresión regular para validar RFC de persona física (formato: 4 letras, 6 dígitos y 3 caracteres alfanuméricos).
            string patronPersonaFisica = @"^[A-Z]{4}\d{6}[A-Z0-9]{3}$";

            // Si el RFC coincide con el patrón de persona física, retorna verdadero.
            if (Regex.IsMatch(texto, patronPersonaFisica) == true)
            {
                return true;
            }
            else
            {
                // Si no coincide, retorna falso.
                return false;
            }
        }
    }
}
