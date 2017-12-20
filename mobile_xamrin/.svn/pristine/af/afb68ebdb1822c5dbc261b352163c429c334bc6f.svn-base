using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SupportActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using VirtualEvent.Droid.Controllers.Activities;

namespace VirtualEvent.Droid.Controllers.Common
{
    internal class MyActionBarDrawerToggle: SupportActionBarDrawerToggle
    {
        private  MainActivity drawerActivity;
        private DrawerLayout drawerLayout;
        private int drawer_close;
        private int drawer_open;

        public MyActionBarDrawerToggle(MainActivity drawerActivity, DrawerLayout drawerLayout, int drawer_open, int drawer_close) :  base(drawerActivity, drawerLayout, drawer_open, drawer_close) {
        
            this.drawerActivity = drawerActivity;
            this.drawerLayout = drawerLayout;
            this.drawer_open = drawer_open;
            this.drawer_close = drawer_close;
        }
        
        public override void OnDrawerOpened(View drawerView)
        {
            base.OnDrawerOpened(drawerView);
            drawerActivity.SupportActionBar.SetTitle( drawer_open);
        }
        public override void OnDrawerClosed(View drawerView)
        {
            base.OnDrawerClosed(drawerView);
            drawerActivity.SupportActionBar.SetTitle(drawer_close);
        }
        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            base.OnDrawerSlide(drawerView, slideOffset);
        }
       
    }
}
