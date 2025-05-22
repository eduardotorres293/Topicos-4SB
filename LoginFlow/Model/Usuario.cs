using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LoginFlow.Model
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, NotNull]
        public string Nombre { get; set; }

        [Unique, NotNull]
        public string Correo { get; set; }

        [NotNull]
        public string Password { get; set; }
    }
}
