
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Calligraphy;
using Com.Nostra13.Universalimageloader.Core;
using VirtualEvent.Droid.Helper;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace VirtualEvent.Droid
{
	[Activity(Label = "Virtual Event", Theme = "@style/AppTheme_Base", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class NotificationActivity : AppCompatActivity, Android.Views.View.IOnClickListener
	{
		SupportToolbar toolbar;

		private INotificationService _INotificationService = null;
		List<Notification> listItem;
		private NotificationAdatper notificatonAdatper;

		private CustomProgress _objProgress;
		private RecyclerView mainRcyle;

		private int eventId = 0;
		int differenceInDays, differenceInHours, differenceInMinutes, differenceInSeconds;

		TimeSpan ts;
		System.Timers.Timer currentTimer;

		protected override void AttachBaseContext(Context newBase)
		{
			//SimpleStorage.SetContext(newBase);
			base.AttachBaseContext(CalligraphyContextWrapper.Wrap(newBase));
		}

		protected override async void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_notification);
		_INotificationService = new NotificationService();
			InitilizeView();

		}




		void setUIData()
		{
			

		}



		private async void InitilizeView()
		{
			toolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);

			TextView txtvwMenu = (TextView)FindViewById(Resource.Id.txtvwMenu);
			txtvwMenu.Text = "";

			TextView txtvwTitle = (TextView)FindViewById(Resource.Id.txtvwTitle);
			txtvwTitle.Text = "Notifications";

			FindViewById(Resource.Id.relNotification).Visibility = ViewStates.Gone;

			txtvwMenu.SetOnClickListener(this);

			mainRcyle = (RecyclerView)FindViewById(Resource.Id.recylrvw_notification);
			listItem = new List<Notification>();
			notificatonAdatper = new NotificationAdatper(listItem, this);

			LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);
			linearLayoutManager.Orientation = LinearLayoutManager.Vertical;
			mainRcyle.SetLayoutManager(linearLayoutManager);
			mainRcyle.SetAdapter(notificatonAdatper);

			await GetNotificationList();
		}

		async Task<List<Notification>> GetNotificationList()
{
	List<Notification> result = null;
	if (AppUtils.IsNetwork())
	{
		
		var request = new NotificationRequest
		{

			PageNo = 1
		};
	_objProgress = new CustomProgress(this);
		var Authkey = StorageUtils<String>.GetPreferencesValue(DroidConstant.CurrentUser);
		var response = await _INotificationService.GetEventList(request, ServiceType.NotificationService, Authkey);
		_objProgress.DismissDialog();
		if (response != null)
		{
			if (response.IsSuccess && response.Result != null)
			{
				result = response.Result;

                if(result.Count == 0 && request.PageNo == 1)
				{
				AppUtils.ShowToast(this, response.Message);
				}else {
							notificatonAdatper.UpdateList(result);
						}
			}
			
			else
			{
				AppUtils.ShowToast(this, response.Message);
			}
			
		}
		else
		{
			AppUtils.ShowToast(this, response.Message);

		}
		
	}
	else
	{
		AppUtils.ShowToast(this, Resources.GetString(Resource.String.network_error));
		_objProgress.DismissDialog();
	}
	return result;
		}

		public void OnClick(View v)
		{
			switch (v.Id)
			{
				case Resource.Id.txtvwMenu:
                    OnBackPressed();
					break;

			}
		}


	}

}

