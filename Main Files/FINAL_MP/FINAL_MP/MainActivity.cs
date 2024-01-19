using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Android.Content;
using System.IO;
using System.Net;
using static Android.Service.Voice.VoiceInteractionSession;

namespace FINAL_MP
{
    [Activity(Label = "Login", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnlogin, btnRegister;
        EditText edit1, edit2;
        String pword = "", uname = "", res = "", userID = "";
        HttpWebResponse response;
        HttpWebRequest request;
        TextView tvRegister;
        
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            btnlogin = FindViewById<Button>(Resource.Id.Login);
            edit1 = FindViewById<EditText>(Resource.Id.editText1);
            edit2 = FindViewById<EditText>(Resource.Id.editText2);
            tvRegister = FindViewById<TextView>(Resource.Id.Register);

            tvRegister.Click += RegisterButton_Click;
            btnlogin.Click += Login;

 
        }



        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(RegisterApp));
            StartActivity(i);
        }

        public void Login(object sender, EventArgs e)
        {
            uname = edit1.Text;
            pword = edit2.Text;
            request = (HttpWebRequest)WebRequest.Create("http://192.168.1.13/mobile_app/userlogin.php?uname=" + uname + "&pword=" + pword);
            response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();
            

            if (res.Contains("Failed!"))
            {
                Toast.MakeText(this, res, ToastLength.Long).Show();
               
                
            }
            else
            {
                Intent i = new Intent(this, typeof(HomeActivity));
                i.PutExtra("UserID", res); //baka gamitin sa ibang activity
                StartActivity(i);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
