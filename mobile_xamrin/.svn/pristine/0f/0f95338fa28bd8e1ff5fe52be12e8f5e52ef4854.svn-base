using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Plus;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using VirtualEvent.Droid;
using VirtualEvent.Droid.Controllers.Activities;
using VirtualEvent.Droid.Helper;
using Xamarin.Facebook.Login;
using Uri = Android.Net.Uri;

namespace VirtualEvent.Droid.Controllers.Fragments
{
	public class MenuFragments : BaseFragment, Android.Views.View.IOnClickListener
{
		TextView txtHome,txtContactUs,txtLogout;

		LinearLayout mMainLayout;

		public override void InitilizeView(View view)
		{
			txtHome = (TextView)view.FindViewById(Resource.Id.txt_home);
			txtContactUs = (TextView)view.FindViewById(Resource.Id.txt_contact_us);
			txtLogout = (TextView)view.FindViewById(Resource.Id.txt_logout);
			mMainLayout = (LinearLayout)view.FindViewById(Resource.Id.main_layout);
			txtContactUs.SetOnClickListener(this);
			txtLogout.SetOnClickListener(this);
			mMainLayout.SetOnClickListener(this);
			txtHome.SetOnClickListener(this);
			//mMainLayout.SetOnTouchListener(this);
		}

		//public override void OnCreate(Bundle savedInstanceState)
  //  {
  //      base.OnCreate(savedInstanceState);

  //      // Create your fragment here
  //  }

  //  public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
  //  {
		//	// Use this to return your custom view for this Fragment
		//	// return inflater.Inflate(Resource.Layout.YourFragment, container, false);

		//	//  return base.OnCreateView(inflater, container, savedInstanceState);
		//	//var rootView = inflater.Inflate(Resource.Layout.drawerItem, container, false);
		//	//return rootView;
		//	return null;
		//}

		public override int SetLayout()
		{
			return Resource.Layout.drawer_item;
		}

		public void Logout() { 
			AlertDialog.Builder alert = new AlertDialog.Builder(Activity);
		alert.SetMessage(Resources.GetString(Resource.String.msgLogOut));

                    alert.SetPositiveButton(Resource.String.popup_ok, async(senderAlert, args) =>
                    {

						await UserLogOut();

                    });
                    alert.SetNegativeButton(Resource.String.popup_cancel, (senderAlert, args) =>
                    {
                    });

                    alert.Show();
		}

		void ContactUs()
		{

			string[] email = { "virtualeventtt@gmail.com"};
			Intent intent = new Intent(Intent.ActionSend);


			intent.SetType("plain/text");
			intent.PutExtra(Intent.ExtraEmail ,email);
           		Activity.StartActivity(intent);
		}

		public void OnClick(View v)
		{
			switch (v.Id)
			{
				case Resource.Id.txt_logout:
					Logout();
					break;
				case Resource.Id.txt_contact_us:
					ContactUs();
					break;
				case Resource.Id.txt_home:
                case Resource.Id.main_layout:
					((MainActivity)(Activity)).CloseDrawer();
					break;

			}
		}

		CustomProgress _objProgress;
		protected async Task<bool> UserLogOut()
		{

			ILoginService _ILoginService = new LoginService();

			if (AppUtils.IsNetwork())
			{
				_objProgress = new CustomProgress(Activity);
				var Authkey = StorageUtils<String>.GetPreferencesValue(DroidConstant.CurrentUser);
				var response = await _ILoginService.LogoutUser(ServiceType.UserService, Authkey);
				_objProgress.DismissDialog();
				if (response != null)
				{
					if (response.IsSuccess)
					{
						StorageUtils<String>.SavePreferences(DroidConstant.CurrentUser, "");
						LoginManager.Instance.LogOut();
						new GoogleApiClient.Builder(Activity)
										   .AddApi(PlusClass.API)
										   .AddScope(new Scope(Scopes.Profile))
										   .Build().Disconnect();
						Activity.StartActivity(typeof(LoginActivity));
						Activity.Finish();

						return true;
					}
					else
					{
						AppUtils.ShowToast(Activity, response.Message);

						return true;
					}
				}
				else
				{
					AppUtils.ShowToast(Activity, response.Message);
					return true;
				}
			}
			else
			{
				AppUtils.ShowToast(Activity, Resources.GetString(Resource.String.network_error));
				_objProgress.DismissDialog();
				return true;
			}
		}	
	}
}