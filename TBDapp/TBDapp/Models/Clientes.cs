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
        [MaxLength(50)]
        public string Telefono_cliente { get; set; }
        [MaxLength(50)]
        public string Auto_cliente { get; set; }
        [MaxLength(50)]
        public string Servicio_cliente { get; set; }
        [MaxLength(50)]
        public string Fecha_entrada_cliente { get; set; }
        [MaxLength(50)]
        public string Fecha_salida_cliente { get; set; }
    }
}
