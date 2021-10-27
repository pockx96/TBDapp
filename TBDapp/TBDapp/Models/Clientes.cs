using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TBDapp.Models
{
    [Table ("client")]
    public class Clientes
    {
        [PrimaryKey,AutoIncrement]
        public int id_cliente { get; set; }
        [MaxLength (50)]
        public string nombre_cliente { get; set; }
    }
}
