using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Widget;
using Android.Media;
using VirtualEvent.Droid.Controllers.Fragments;
using VirtualEvent.Droid.Controllers.Common;

namespace VirtualEvent.Droid.Controllers.Activities
{
	[Activity(Label = "DrawerActivity",MainLauncher = true, Theme = "@style/MyTheme")]
public class DrawerActivity : AppCompatActivity
{
        SupportToolbar toolbar;
        DrawerLayout drawerLayout;
        MyActionBarDrawerToggle mDrawerToggle;
        protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

            // Create your application here
			SetContentView(Resource.Layout.activity_base);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
           FragmentTransaction fragment = this.FragmentManager.BeginTransaction();
            //fragment.Add(Resource.Id.fragment_menu, new MenuFragments());
            //toolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
			//toolbar.SetNavigationIcon(Resource.Drawable.back_arrow);
           SetSupportActionBar(toolbar);
            fragment.Commit();
          
            //mDrawerToggle = new MyActionBarDrawerToggle(this, drawerLayout, Resource.String.drawer_open, Resource.String.drawer_close);
          
            drawerLayout.SetDrawerListener(mDrawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            mDrawerToggle.SyncState();

        }
    }
}