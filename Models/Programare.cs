using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Android.App;
using SQLite;
using SQLiteNetExtensions.Attributes;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace ProiectMAUIHairsalon.Models
{
    public class Programare
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250),Unique]
        public string Descriere{ get; set; }
        public DateTime Data { get; set; }

        public TimeSpan Timp { get; set; }

        [ForeignKey(typeof(Salon))]
        public int SalonID { get; set; }
    }
}
