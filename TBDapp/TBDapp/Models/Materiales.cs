using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace TBDapp.Models
{
    [Table("mat")]
    public class Materiales 
    {
        [PrimaryKey, AutoIncrement]
        public int id_material { get; set; }
        [MaxLength(50)]
        public string nombre_material { get; set; }
        [MaxLength(50)]
        public string precio_material { get; set; }
    }
}
