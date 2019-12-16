using Android.App;
using Android.Content;
using Android.Support.V7.App;

namespace FreeWeatherApp.Droid
{
    [Activity(
        Theme = "@style/MainTheme.Splash",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));

            Finish();
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed()
        {
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            //await Task.Delay(8000);
        }
    }
}