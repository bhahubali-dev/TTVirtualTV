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
using Android.Content.Res;

namespace VirtualEvent.Droid
{
    public abstract  class BaseFragment : Android.Support.V4.App.Fragment
    {
        protected Activity mActivity;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(SetLayout(), container, false);
            return view;
        }

        public override void OnAttach(Context context)
        {
            mActivity = (Activity)context;
            base.OnAttach(context);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            InitilizeView(view);
        }
       

        public abstract void InitilizeView(View view);

        public abstract int SetLayout();
    }
}