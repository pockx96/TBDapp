using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TBDapp.Models
{
    [Table("usuario")]
    public class Usuarios
    {
        [PrimaryKey, AutoIncrement]
        public int id_usuario { get; set; }
        [MaxLength(50)]
        public string nombre_usuario { get; set; }
        [MaxLength(50)]
        public string pass_usuario { get; set; }
    }
}
