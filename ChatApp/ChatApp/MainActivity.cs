using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

using Android.Text;
using Android.Views;
using ChatApp.ActivityScript;

namespace ChatApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var btnLogin = FindViewById<Button>(Resource.Id.btn_login);
            btnLogin.Click += (sender, args) =>
            {

                StartActivity(typeof(ChatActivity));
            };
        }
    }
}

