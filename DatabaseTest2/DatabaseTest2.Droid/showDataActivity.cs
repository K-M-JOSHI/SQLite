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
using Java.Lang;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using SQLiteNetExtensions.Extensions;

namespace DatabaseTest2.Droid
{
    [Activity(Label = "showDataActivity")]
    public class showDataActivity : Activity
    {
        List<Employee> test = new List<Employee>();
        ListView data;
        EditText id;
        TextView name, lname, duties;
        Button show;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Demo

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.showData);
            id = FindViewById<EditText>(Resource.Id.empDataID);
            name = FindViewById<TextView>(Resource.Id.name);
            lname = FindViewById<TextView>(Resource.Id.lname);
            duties = FindViewById<TextView>(Resource.Id.duties);
            show = FindViewById<Button>(Resource.Id.showwButton);
            show.Click += Show_Click;
           
            // Create your application her
            // data = FindViewById<ListView>(Resource.Id.empDataList);
            // test = MainActivity.GetAllEmpData();
            // data.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, test.ToArray());
            // Create your application here
        }

        private void Show_Click(object sender, EventArgs e)
        {
            int idd = Integer.ParseInt(id.Text);
            SQLiteConnection db = new SQLiteConnection(new SQLitePlatformAndroid(), Constants.DbFilePath);
            var v = db.GetWithChildren<Employee>(Integer.ParseInt(id.Text));

            name.Text = v.Name;
            lname.Text = v.LastName;
            foreach (var a in v.Duties)
            {
                duties.Text += a.Description + " ";
                
            }
        }
    }
    }
