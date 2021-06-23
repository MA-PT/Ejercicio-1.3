using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteApp.Model
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public String Nombre { get; set; }

        [MaxLength(250)]
        public String Apellidos { get; set; }

        public int Edad { get; set; }

        [MaxLength(100)]
        public String Correo { get; set; }

        [MaxLength(300)]
        public String Direccion { get; set; }

        public DateTime Fechanac { get; set; }
    }
}
