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
using System.IO;

namespace DatabaseTest2.Droid
{
    class Constants
    {
        public static readonly string DbFilePath =
        Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                "moneyback.db"
        );
    }
}