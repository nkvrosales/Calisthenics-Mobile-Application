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
    [Activity(Label = "Workout Level")]

    public class WorkoutLevel : Activity
    {
        String userID;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.workoutlevel);


            ImageButton imageButton1 = FindViewById<ImageButton>(Resource.Id.imageButton1);
            ImageButton imageButton2 = FindViewById<ImageButton>(Resource.Id.imageButton2);
            ImageButton imageButton3 = FindViewById<ImageButton>(Resource.Id.imageButton3);
            Button backtohome = FindViewById<Button>(Resource.Id.button1);

            imageButton1.Click += this.beginner_workout;
            imageButton2.Click += this.intermediate_workout;
            imageButton3.Click += this.advance_workout;
            backtohome.Click += this.BacktoHome;

            userID = Intent.GetStringExtra("UserID" ?? "No userID");
            
        }



        public void beginner_workout(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(BeginnerActivity));
            i.PutExtra("UserID", userID);
            StartActivity(i);
        }
        public void intermediate_workout(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Intworkout));
            i.PutExtra("UserID", userID);
            StartActivity(i);
        }
        public void advance_workout(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Adworkout));
            i.PutExtra("UserID", userID);
            StartActivity(i);
        }
        public void BacktoHome(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(HomeActivity));
            StartActivity(i);
        }

    }
}