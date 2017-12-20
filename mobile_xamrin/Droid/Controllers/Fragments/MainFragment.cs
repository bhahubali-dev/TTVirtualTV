using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using Android.Support.V4.View;

using Android.Support.Design.Widget;


namespace VirtualEvent.Droid.Controllers.Fragments
{
    public class MainFragment : BaseFragment, Android.Support.V4.View.ViewPager.IOnPageChangeListener,
    TabHost.IOnTabChangeListener
    {
        #region Object declaration
        List<string> tabTitles ;
        List<BaseFragment> listFragment;
        private FragmentPagerAdapter adapter;
        ViewPager pager;
        
        TabLayout sliding_tabs;
        #endregion

        public override void InitilizeView(View view)
        {
            tabTitles = new List<string>();
            listFragment = new List<BaseFragment>();

			sliding_tabs = view.FindViewById<TabLayout>(Resource.Id.tabmy);

            listFragment.Add(new 
			                 EventsFragment());
            tabTitles.Add("Events");
			listFragment.Add(new EnrolledEventsFragment());
            tabTitles.Add("Enrolled");
           //tabTitles.Add(Resources.GetString(Resource.String.shift_plan));

            adapter = new FragmentPagerAdapter(Activity.SupportFragmentManager, this.Context, tabTitles, listFragment);
            pager = (ViewPager)view.FindViewById(Resource.Id.vpRequestAssignment);
            pager.Adapter = adapter;
            pager.AddOnPageChangeListener(this);
            sliding_tabs.SetupWithViewPager(pager);          
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
           
        }

        public void OnPageScrollStateChanged(int state)
        {

        }

        public void OnPageSelected(int position)
        {

        }

        public void OnTabChanged(string tabId)
        {
			int position = sliding_tabs.SelectedTabPosition;

			SetTabHeader(position);
        }

        public override int SetLayout()
		{
			//return Resource.Layout.Layou;
			return Resource.Layout.fragment_pager;
            //return Resource.Layout.request_assign_property
        }
    
	
		private void SetTabHeader(int position)
		{
			pager.CurrentItem = position;
			//position = i;
			//Console.WriteLine("OnPageSelected" + " " + position);
			//mTabHost.CurrentTab = position;
			//Typeface font = Typeface.CreateFromAsset(instance.Assets,
			//            "fonts/OpenSans-Semibold.ttf");
			int wantedTabIndex = 0;

			for (int i = 0; i < sliding_tabs.ChildCount; i++)
			{
				TextView tv = (TextView)(((LinearLayout)((LinearLayout)sliding_tabs.GetChildAt(0)).GetChildAt(wantedTabIndex)).GetChildAt(0));
				tv.SetTextColor(Context.Resources.GetColor(Resource.Color.colorWhite));

				//tv.SetTypeface(font, TypefaceStyle.Bold);
			}
			TextView mtv = (TextView)(((LinearLayout)((LinearLayout)sliding_tabs.GetChildAt(0)).GetChildAt(wantedTabIndex)).GetChildAt(0));
			mtv.SetTextColor(Context.Resources.GetColor(Resource.Color.colorMaroon));
		 }
	}


}