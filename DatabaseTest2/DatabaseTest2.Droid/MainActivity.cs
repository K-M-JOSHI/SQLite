using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite.Net.Platform.XamarinAndroid;
using SQLite.Net;
using static Android.Renderscripts.ProgramVertexFixedFunction;
using SQLiteNetExtensions.Extensions;
using System.Linq;
using System.Collections.Generic;

namespace DatabaseTest2.Droid
{
	[Activity (Label = "DatabaseTest2.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
        EditText name, lname, description,empId,dutyId1,dutyId2,dutyId3;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var db = new SQLiteConnection(new SQLitePlatformAndroid(), Constants.DbFilePath);
            db.CreateTable<Employee>();
            db.CreateTable<Duty>();
            
            // Get our button from the layout resource,
            // and attach an event to it
            Button empbutton = FindViewById<Button>(Resource.Id.addempButton);
            Button dutybutton = FindViewById<Button>(Resource.Id.adddutyButton);
            Button assignbutton = FindViewById<Button>(Resource.Id.assignButton);
            Button saveempbutton = FindViewById<Button>(Resource.Id.saveempButton);
            Button savedutybutton = FindViewById<Button>(Resource.Id.savedutyButton);
            Button saveassignbutton = FindViewById<Button>(Resource.Id.saveassignButton);
            Button showbutton = FindViewById<Button>(Resource.Id.showButton);

            LinearLayout emp = FindViewById<LinearLayout>(Resource.Id.empfield);
            LinearLayout duty = FindViewById<LinearLayout>(Resource.Id.dutyfield);
            LinearLayout assign = FindViewById<LinearLayout>(Resource.Id.assignfield);

            EditText name = FindViewById<EditText>(Resource.Id.name);
            EditText lname = FindViewById<EditText>(Resource.Id.lname);
            EditText description = FindViewById<EditText>(Resource.Id.description);
            EditText empId = FindViewById<EditText>(Resource.Id.empId);
            EditText dutyId1 = FindViewById<EditText>(Resource.Id.duty1ID);
            EditText dutyId2 = FindViewById<EditText>(Resource.Id.duty2ID);
            EditText dutyId3 = FindViewById<EditText>(Resource.Id.duty3ID);

            empbutton.Click += delegate {

                duty.Visibility = ViewStates.Gone;
                assign.Visibility = ViewStates.Gone;
                emp.Visibility = ViewStates.Visible;

            };
            saveempbutton.Click += delegate {

                var employee = new Employee
                {
                    Name = name.Text + "",
                    LastName = lname.Text + ""
                };
                db.Insert(employee);
            };
            dutybutton.Click += delegate {

                emp.Visibility = ViewStates.Gone;
                assign.Visibility = ViewStates.Gone;
                duty.Visibility = ViewStates.Visible;

            };
            savedutybutton.Click += delegate {

                var duty1 = new Duty()
                {
                    Description = description.Text + ""
                };
                db.Insert(duty1);
            };
            assignbutton.Click += delegate {

                emp.Visibility = ViewStates.Gone;
                duty.Visibility = ViewStates.Gone;
                assign.Visibility = ViewStates.Visible;

            };
            saveassignbutton.Click += delegate {

                Duty duty1, duty2, duty3;
                Employee employee = db.Get<Employee>(empId.Text);
                List<Duty> l= new List<Duty>();

                if (dutyId1.Text != "") {

                    duty1 = db.Get<Duty>(Java.Lang.Integer.ParseInt(dutyId1.Text));
                    if (duty1 != null)
                        l.Add(duty1);
                    
                }
                if (dutyId2.Text != "" ) {
                    duty2 = db.Get<Duty>(Java.Lang.Integer.ParseInt(dutyId2.Text));
                    l.Add(duty2);
                }
                if (dutyId3.Text != "") {
                    duty3 = db.Get<Duty>(Java.Lang.Integer.ParseInt(dutyId3.Text));
                    l.Add(duty3);
                }
                employee.Duties = l;
                db.UpdateWithChildren(employee);
            };
            showbutton.Click += delegate {

                StartActivity(new Intent(this, typeof(showDataActivity)));
            };

        }
         

        
    }
}


