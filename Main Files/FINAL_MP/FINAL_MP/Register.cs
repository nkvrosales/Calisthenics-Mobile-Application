using Android;
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
    [Activity(Label = "Register")]

    public class RegisterApp : Activity
    {
        EditText editName, editUser, editGender, editPword, editCpword, editAge, editHeight, editWeight;
        RadioGroup gender;
        HttpWebResponse response;
        HttpWebRequest request;
        String fname = "", uname = "", selectedGender = "", pword = "", cpword = "", age = "", height = "", weight = "", res = "";
        int userIDint = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.register);

            editName = FindViewById<EditText>(Resource.Id.editFullname);
            editUser = FindViewById<EditText>(Resource.Id.editUsername);
            editAge = FindViewById<EditText>(Resource.Id.editAge);
            editHeight = FindViewById<EditText>(Resource.Id.editHeight);
            editWeight = FindViewById<EditText>(Resource.Id.editWeight);
            editPword = FindViewById<EditText>(Resource.Id.editPassword);
            editCpword = FindViewById<EditText>(Resource.Id.editConfirm);
            Button confirm = FindViewById<Button>(Resource.Id.butConfirm);
            Button btnBack = FindViewById<Button>(Resource.Id.butBack);

            confirm.Click += this.AddRecord;
            btnBack.Click += this.BackHome;

            // Retrieve the latest userID
            request = (HttpWebRequest)WebRequest.Create("http://192.168.1.13/mobile_app/get_latest_userID.php");
            response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string latestUserIDString = reader.ReadToEnd();
            if (int.TryParse(latestUserIDString, out int latestUserID))
            {
                userIDint = latestUserID;
            }
            else
            {
                
                userIDint = 0; // Set a default value, you can modify this as per your requirement
            }
        }

        public void AddRecord(object sender, EventArgs e)
        {
            userIDint = userIDint + 1;
            string userID = userIDint.ToString();
            fname = editName.Text;
            uname = editUser.Text;
            age = editAge.Text;
            height = editHeight.Text;
            weight = editWeight.Text;
            pword = editPword.Text;
            cpword = editCpword.Text;

            request = (HttpWebRequest)WebRequest.Create("http://192.168.1.13/mobile_app/user_acc.php?userID=" + userID + "&fname=" + fname + "&uname=" + uname + "&uage=" + age + "&uheight=" + height + "&uweight=" + weight + "&pword=" + pword + "&cpword=" + cpword);
            response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();
            Toast.MakeText(this, res, ToastLength.Long).Show();
        }

        public void BackHome(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }
    }
}
