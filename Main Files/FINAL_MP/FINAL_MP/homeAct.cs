using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Xml;

namespace FINAL_MP
{
    [Activity(Label = "Home")]

    public class HomeActivity : Activity
    {
        String userID;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.home);

            Button start= FindViewById<Button>(Resource.Id.btnStart);
            Button reports = FindViewById<Button>(Resource.Id.btnReports);
            Button logout = FindViewById<Button>(Resource.Id.btnLogout);

            userID = Intent.GetStringExtra("UserID" ?? "No userID");
            




            start.Click += this.StartApp;
            reports.Click += this.ReportApp;
            logout.Click += this.Logout;
        }

        public void StartApp(object sender, EventArgs e)
        {
            
            Intent i = new Intent(this, typeof(WorkoutLevel));
            i.PutExtra("UserID", userID);
            //i.GetExtra("Name", uname);
            StartActivity(i);
        }

        public void ReportApp(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(UserProfileActivity));
            StartActivity(i);
        }

        public void Logout(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }
    }

}