using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Timers;
using Android.Widget;


namespace FINAL_MP
{
    internal class TimerActivity
    {
        TextView tvTimer;
        private MyCountDownTimer countDownTimer;
        Button btnStart;
        Timer timer;
        private int speed;


        // Constructor that can be used in other classes
        public TimerActivity(TextView timerTextView, Button startButton)
        {
            tvTimer = timerTextView;
            btnStart = startButton;

        }

        public void PlayCountdown()
        {

            countDownTimer = new MyCountDownTimer(30000, 1000);
            countDownTimer.TimerTick += CountDownTimer_Tick;
            countDownTimer.TimerFinish += CountDownTimer_Finish;
            countDownTimer.Start();


        }

        public void StartButton_Click(object sender, EventArgs e)
        {
            countDownTimer.Start();
        }

        public void CountDownTimer_Tick(object sender, MyCountDownTimer.TimerTickEventArgs e)
        {
            // Update the TextView with the remaining time
            tvTimer.Text = (e.MillisUntilFinished / 1000).ToString();
        }

        private void CountDownTimer_Finish(object sender, EventArgs e)
        {
            // Set the TextView text to "0" when the countdown is finished
            tvTimer.Text = "0";
            string res = "Rest time is Over.";
            //Toast.MakeText(this,int.Parse(res), ToastLength.Short).Show();


        }
    }



    public class MyCountDownTimer : CountDownTimer
    {
        public event EventHandler<TimerTickEventArgs> TimerTick;
        public event EventHandler TimerFinish;

        public MyCountDownTimer(long millisInFuture, long countDownInterval) : base(millisInFuture, countDownInterval)
        {
        }

        public override void OnTick(long millisUntilFinished)
        {
            TimerTick?.Invoke(this, new TimerTickEventArgs(millisUntilFinished));
        }

        public override void OnFinish()
        {
            TimerFinish?.Invoke(this, EventArgs.Empty);
        }

        public class TimerTickEventArgs : EventArgs
        {
            public long MillisUntilFinished { get; }

            public TimerTickEventArgs(long millisUntilFinished)
            {
                MillisUntilFinished = millisUntilFinished;
            }
        }
    }
}


