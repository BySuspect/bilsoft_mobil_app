using Android.App;
using Android.Support.V7.App;

namespace bilsoft_mobil_app.Droid
{
    [Activity(Icon = "@drawable/bilsoft_logo", Theme = "@style/MyScreen", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }
}