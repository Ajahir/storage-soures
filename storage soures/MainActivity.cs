using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace storage_soures
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button log,get,key,all;
        private EditText edit,pass;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReferences();
            UIClickEvents();
        }

        private void UIReferences()
        {
            log = FindViewById<Button>(Resource.Id.button1);
            get = FindViewById<Button>(Resource.Id.button2);
            key = FindViewById<Button>(Resource.Id.button3);
            all = FindViewById<Button>(Resource.Id.button4);
            edit = FindViewById<EditText>(Resource.Id.editText1);
            pass = FindViewById<EditText>(Resource.Id.editText2);
           
        }

        private void UIClickEvents()
        {
            log.Click += Log_Click;
            get.Click += Get_Click;
            key.Click += Key_Click;
            all.Click += All_Click;
        }

        private void All_Click(object sender, EventArgs e)
        {
           SecureStorage.RemoveAll();
        }

        private void Key_Click(object sender, EventArgs e)
        {
            SecureStorage.Remove("username");
            SecureStorage.Remove("password");
        }

        private void Get_Click(object sender, EventArgs e)
        {
            _ = GetDetails();
        }

        private async Task GetDetails()
        {
            edit.Text = await SecureStorage.GetAsync("username");
            pass.Text = await SecureStorage.GetAsync("password");

        }

        private void Log_Click(object sender, EventArgs e)
        {
            SecureStorage.SetAsync("username",edit.Text);
            SecureStorage.SetAsync("password",pass.Text);
            edit.Text = String.Empty;
            pass.Text = String.Empty;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}