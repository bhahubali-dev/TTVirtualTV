
using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Calligraphy;
using PerpetualEngine.Storage;
using VirtualEvent.Droid.Controllers.Activities;
using VirtualEvent.Droid.Helper;
using Xamarin.Facebook;

namespace VirtualEvent.Droid
{
	[Activity(Label = "Virtual Event", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class SplashActivity : AppCompatActivity
	{
		protected override void AttachBaseContext(Context newBase)
		{
			base.AttachBaseContext(CalligraphyContextWrapper.Wrap(newBase));
		}


		protected override  void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SimpleStorage.SetContext(ApplicationContext);
			SetContentView(Resource.Layout.activity_splash);
			FacebookSdk.SdkInitialize(this.ApplicationContext);
			RunTimer();
		}

		async void RunTimer()
		{
			await Task.Delay(2000);
			// Create your application here
			string token = StorageUtils<String>.GetPreferencesValue(DroidConstant.CurrentUser);
			//currentTimer.Dispose();
			if (token != null && token.Length > 0)
			{
				StartActivity(typeof(MainActivity));
			} else
			{
				StartActivity(typeof(LoginActivity));
			}
			Finish();
		}
	}
}
