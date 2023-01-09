using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMAUIHairsalon.Models
{
    public class Salon
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NumeSalon { get; set; }
        public string Adresa { get; set; }
        public string DetaliiSalon { get { return NumeSalon + " " + Adresa; } }
        [OneToMany]
        public List<Programare> Programari { get; set; }
    }
}
