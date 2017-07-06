using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using SQLite;

namespace DatabaseTest2.Droid
{
    [Table("Employees")]
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        [OneToMany]
        public List<Duty> Duties { get; set; }

        public override string ToString()
        {
           
            return $"[Employee: Id={Id}, Name={Name}, LastName={LastName}, Duty1 ={Duties.ElementAt(0)}, Duty2 ={ Duties.ElementAt(1)}, Duty3 ={Duties.ElementAt(2)}]";
        }
    }
}