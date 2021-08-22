using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLiteProyecto.Models
{
    [Table("EMPLEADOS")]
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
