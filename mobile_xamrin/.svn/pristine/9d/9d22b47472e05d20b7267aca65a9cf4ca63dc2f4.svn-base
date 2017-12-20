using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using VirtualEvent.Droid.Controllers.Common;
using VirtualEvent.Droid.Controllers.Fragments;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Calligraphy;
using Android.Content;
using Android.Util;
using Android.Gms.Common;
using Android.Views;

namespace VirtualEvent.Droid.Controllers.Activities
{      
	[Activity(Label = "@string/ApplicationName",  Icon = "@mipmap/icon", Theme = "@style/AppTheme_Base", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Exported=true)]
	public class MainActivity : AppCompatActivity, Android.Views.View.IOnClickListener
	{
		SupportToolbar toolbar;
		DrawerLayout drawerLayout;
		MyActionBarDrawerToggle mDrawerToggle;
        protected override void AttachBaseContext(Context newBase)
        {
            //SimpleStorage.SetContext(newBase);
            base.AttachBaseContext(CalligraphyContextWrapper.Wrap(newBase));
        }
        protected override void OnCreate(Bundle savedInstanceState)
			{
				base.OnCreate(savedInstanceState);

				// Set our view from the "main" layout resource
				SetContentView(Resource.Layout.activity_base);
            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug("TAG", "Key: {0} Value: {1}", key, value);
                }
            }
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
				toolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);	
			TextView txtvwMenu = (TextView)FindViewById(Resource.Id.txtvwMenu);
			RelativeLayout relNotificaton = (RelativeLayout)FindViewById(Resource.Id.relNotification);
		
			relNotificaton.SetOnClickListener(this);
			txtvwMenu.SetOnClickListener(this);
				
				
				var fragmentManager = this.SupportFragmentManager;
				var ft = fragmentManager.BeginTransaction();
				ft.Replace(Resource.Id.content_frame, new MainFragment());
				ft.Add(Resource.Id.fragment_menu, new MenuFragments());
				ft.Commit();

            	SetSupportActionBar(toolbar);
				//mDrawerToggle = new MyActionBarDrawerToggle(this, drawerLayout, Resource.String.drawer_open, Resource.String.drawer_close);
				//drawerLayout.SetDrawerListener(mDrawerToggle);
            	//mDrawerToggle.SyncState();
            
        }
        

		public void OnClick(View v)
		{
		switch (v.Id)
			{
				case Resource.Id.txtvwMenu:
					drawerLayout.OpenDrawer((int)GravityFlags.Start);
					break;

				case Resource.Id.relNotification:
					StartActivity(typeof(NotificationActivity));
					break;

			}	
		}

		internal void CloseDrawer()
		{
			drawerLayout.CloseDrawers();
		}
	}
}