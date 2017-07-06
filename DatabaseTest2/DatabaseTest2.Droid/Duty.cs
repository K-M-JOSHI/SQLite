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

namespace DatabaseTest2.Droid
{
    [Table("Duties")]
    public class Duty
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Description { get; set; }

        [ForeignKey(typeof(Employee))]
        public int EmployeeId { get; set; }

        public override string ToString()
        {
            return $"[Duty: Id={Id}, Description={Description}]";
        }
    }
}