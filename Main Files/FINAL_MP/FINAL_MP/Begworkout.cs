using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.IO;
using System.Net;



namespace FINAL_MP
{
    [Activity(Label = "Beginner")]
    public class BeginnerActivity : Activity
    {
        TextView tvTimer;
        Button btnStartTimer;
        String userID = "";
        HttpWebResponse response;
        HttpWebRequest request;
        int beginnerUP = 0, intermediateUP = 0, advancedUP = 0, maxBeginnerUP=0, userInfoIDInt = 0;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.beginner);



            Button giveUpButton = FindViewById<Button>(Resource.Id.button2);
            btnStartTimer = FindViewById<Button>(Resource.Id.button3);
            tvTimer = FindViewById<TextView>(Resource.Id.textView6);



            giveUpButton.Click += GiveUp;
            btnStartTimer.Click += RestTimer;



            userID = Intent.GetStringExtra("UserID") ?? "No userID";
            

            request = (HttpWebRequest)WebRequest.Create("http://192.168.1.13/mobile_app/get_latest_userInfoID.php");
            response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string latestUserIDString = reader.ReadToEnd();
            if (int.TryParse(latestUserIDString, out int latestUserID))
            {
                userInfoIDInt = latestUserID;
            }
            else
            {
                // Error handling if parsing fails
                // Set a default value or show an error message
                userInfoIDInt = 0; // Set a default value, you can modify this as per your requirement
            }

            // Make a request to retrieve the max value of beginnerUP
            string retrieveUrl = "http://192.168.1.13/mobile_app/retrieve_max_beginnerUP.php?userID="+ userID;
            maxBeginnerUP = SendRequestToInt(retrieveUrl);
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



        public void BeginnerFin(object sender, EventArgs e)
        {
            
            string userInfoID = "";



            userInfoIDInt = userInfoIDInt + 1;
            userInfoID = userInfoIDInt.ToString();



            if (beginnerUP != 0)
            {
                



                beginnerUP = maxBeginnerUP + 5;



                // Make a request to update the database
                string updateUrl = "http://192.168.1.13/mobile_app/update_userinfo.php?userInfoID=" + userInfoID + "&userID=" + userID + "&beginnerUP=" + beginnerUP + "&intermediateUP=" + intermediateUP + "&advancedUP=" + advancedUP;
                string updateResponse = SendRequestToString(updateUrl);



                Toast.MakeText(this, updateResponse, ToastLength.Long).Show();
            }
            else
            {
                beginnerUP = beginnerUP + 5;
                // Make a request to insert new data into the database
                string insertUrl = "http://192.168.1.13/mobile_app/insert_userinfo.php?userInfoID=" + userInfoID + "&userID=" + userID + "&beginnerUP=" + beginnerUP + "&intermediateUP=" + intermediateUP + "&advancedUP=" + advancedUP;
                string insertResponse = SendRequestToString(insertUrl);



                Toast.MakeText(this, insertResponse, ToastLength.Long).Show();
            }



            Intent i = new Intent(this, typeof(HomeActivity));
            StartActivity(i);
        }



        private int SendRequestToInt(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();
            int result = 0;
            int.TryParse(responseString, out result);
            return result;
        }



        private string SendRequestToString(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();
            return responseString;
        }
    }
}