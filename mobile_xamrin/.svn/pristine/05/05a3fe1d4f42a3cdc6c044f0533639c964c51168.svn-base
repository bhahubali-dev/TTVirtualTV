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

using Android.Support.V7.App;


namespace VirtualEvent.Droid
{
          
    [Activity(Label = "Cleazz", Theme = "@style/Theme.AppCompact")]
    public abstract class BaseActivity : AppCompatActivity
    {
        //protected override void AttachBaseContext(Context newBase)
        //{
        //    //SimpleStorage.SetContext(newBase);
        //    //base.AttachBaseContext(CalligraphyContextWrapper.Wrap(newBase));
        //}

        public abstract void InitilizeView();

        public abstract int SetLayout();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SimpleStorage.SetContext(ApplicationContext);
            SetContentView(SetLayout());
            InitilizeView();
        }

        public void LoadFragement( Android.Support.V4.App.Fragment fragment)
        {           
            var fragmentManager = this.SupportFragmentManager;
            var ft = fragmentManager.BeginTransaction();
            //ft.Replace(Resource.Id.content_frame, fragment);
            ft.AddToBackStack(fragment.Class.SimpleName);
            ft.Commit();
        }

    }
}