

using System.Collections.Generic;

using Android.Content;

using Android.Runtime;
using Android.Support.V4.App;

using Java.Lang;

namespace VirtualEvent.Droid
{
   
    public class FragmentPagerAdapter : FragmentStatePagerAdapter
    {
        List<BaseFragment> listFragement;
        private const int PAGE_COUNT = 2;
        private List<string> tabTitles;
        private Context context;      
        public FragmentPagerAdapter(Android.Support.V4.App.FragmentManager fm, Context context, List<string> _tabTitles, List<BaseFragment> _listFragement ) : base(fm)//List<PropertyResponse> _propertyTab, List<PropertyResponse> _personalTab,
        {
            this.context = context;
            tabTitles = _tabTitles;
            listFragement = _listFragement;           
        }

        public override int Count
        {
            get
            {
                return tabTitles.Count;
            }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {          
            return listFragement[position];
        }
        public override ICharSequence GetPageTitleFormatted(int position)
        {

            var titles = CharSequence.ArrayFromStringArray(tabTitles.ToArray());
            
            return titles[position];
            
        }
        //public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        //{
        //    return tabTitles[position];
        //}
    }
}
