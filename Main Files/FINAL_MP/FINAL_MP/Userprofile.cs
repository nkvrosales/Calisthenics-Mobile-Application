using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Xml;

namespace FINAL_MP
{
    [Activity(Label = "Profile")]
    public class UserProfileActivity : AppCompatActivity
    {

        private ProgressBar _BeginnerprogressBar, _IntermediateprogressBar, _AdvanceprogressBar;
        EditText editText;
        TextView editTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.userprofile);

            //editText = FindViewById<EditText>(Resource.Id.textEdit);
            //editTextView = FindViewById<TextView>(Resource.Id.textEdit);

            

            _BeginnerprogressBar = FindViewById<ProgressBar>(Resource.Id.progressBeginner);
            _IntermediateprogressBar = FindViewById<ProgressBar>(Resource.Id.progressIntermediate);
            _AdvanceprogressBar = FindViewById<ProgressBar>(Resource.Id.progressAdvanced);

            int Bprogress = 100; // Set the value of progress dynamically (e.g., based on user input or calculation)
            int Iprogress = 10;
            int Aprogress = 67;
            // Set the progress value to the ProgressBar
            _BeginnerprogressBar.Progress = Bprogress;
            _IntermediateprogressBar.Progress = Iprogress;
            _AdvanceprogressBar.Progress = Aprogress;
            Button saveButton = FindViewById<Button>(Resource.Id.Save);
            saveButton.Click += SaveButton_Click;
          
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            EditText heightEditText = FindViewById<EditText>(Resource.Id.editHeight);
            EditText weightEditText = FindViewById<EditText>(Resource.Id.editWeight);
            EditText ageEditText = FindViewById<EditText>(Resource.Id.editAge);

            string height = heightEditText.Text;
            string weight = weightEditText.Text;
            string age = ageEditText.Text;
            

            //SaveUserProfile(height, weight, age);

            Toast.MakeText(this, "User profile saved!", ToastLength.Short).Show();
        }
       

    }
}