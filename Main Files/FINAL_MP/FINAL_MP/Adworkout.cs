using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Timers;

namespace FINAL_MP
{
    [Activity(Label = "Beginner")]
    public class Adworkout : Activity
    {
        TextView tvTimer;
        Button btnStartTimer;
        Timer timer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.advance); 

            Button giveUpButton = FindViewById<Button>(Resource.Id.button2);
            Button doneButton = FindViewById<Button>(Resource.Id.button1);
            Button btnStartTimer = FindViewById<Button>(Resource.Id.button3);
            tvTimer = FindViewById<TextView>(Resource.Id.textView6);

            giveUpButton.Click += GiveUp;
            btnStartTimer.Click += RestTimer;

           
            giveUpButton.Click += GiveUp;
            doneButton.Click += GiveUp;
        }

        public void RestTimer(object sender, EventArgs e)
        {
            TimerActivity atimer = new TimerActivity(tvTimer, btnStartTimer);
            atimer.PlayCountdown();

        }

        public void GiveUp(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(WorkoutLevel));
            StartActivity(i);
        }
    }
}
