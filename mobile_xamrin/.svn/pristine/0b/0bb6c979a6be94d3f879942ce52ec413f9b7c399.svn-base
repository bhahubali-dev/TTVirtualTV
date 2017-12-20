
using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Calligraphy;
using Com.Nostra13.Universalimageloader.Core;
using VirtualEvent.Droid.Helper;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace VirtualEvent.Droid
{
	[Activity(Label = "Virtual Event", Theme = "@style/AppTheme_Base", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class EventDetailActivity : AppCompatActivity, Android.Views.View.IOnClickListener
	{
		SupportToolbar toolbar;
		private EventListService _IEventListService;
		private EventDetail eventDetail;
		private ImageLoader imageLoader;
		private CustomProgress _objProgress;
		private TextView txtHeading, txtPresenterName, txtDate, txtTime, txtDuration,
		txtPrice, txtParagraph, txtPresentedBy, txtLeftDays, txtViewEvent, txtVenue,
		txtQuesPara, txtQuesDate, txtApproval;
		private ImageView detailImage;
		private LinearLayout lnrEnrolledLyt, lnrQustnLyt, lnrViewEvent;
		DisplayImageOptions options;

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
			SetContentView(Resource.Layout.activity_event_detail);
			eventId = Intent.GetIntExtra("eventId", 0);
			_IEventListService = new EventListService();
			eventDetail = new EventDetail();
			imageLoader = ImageLoader.Instance;
			options = new DisplayImageOptions.Builder()
		.CacheInMemory(true)
		.CacheOnDisk(true)
		.Build();
			imageLoader.Init(ImageLoaderConfiguration.CreateDefault(this));
			InitilizeView();
			eventDetail = await GetEventDetail();
			if (eventDetail != null)
				setUIData();
		}




		void setUIData()
		{
			txtHeading.Text = (eventDetail.Title);
			txtDate.Text = eventDetail.DateOfEvent.ToLocalTime().ToString(DroidConstant.DATE);
			txtTime.Text = eventDetail.DateOfEvent.ToLocalTime().ToString(DroidConstant.TIME);
			//txtTime.Text = eventDetail.TimeOfEvent.ToString();
			txtPrice.Text = "$" + eventDetail.EnrollmentPrice;
			txtParagraph.Text = eventDetail.Description;
			txtDuration.Text = eventDetail.DurationHour + " Hour " + eventDetail.DurationMinute + " Min";
			txtPresenterName.Text = eventDetail.Presenter;
			txtPresentedBy.Text = "Presenter By " + eventDetail.Presenter;
			txtVenue.Text = eventDetail.Venue;

			if (!string.IsNullOrEmpty(eventDetail.MediaUrl))
			{
				imageLoader.DisplayImage(eventDetail.MediaUrl, detailImage,options);
			}
			else
			{
				detailImage.SetImageResource(Resource.Drawable.detail_placeholder);
			}


			if (eventDetail.IsEnrolled)
			{
				lnrEnrolledLyt.Visibility = Android.Views.ViewStates.Visible;


				startEventTime();


				if (!(string.IsNullOrEmpty(eventDetail.Question.Question)))
				{
					lnrQustnLyt.Visibility = Android.Views.ViewStates.Visible;
					txtQuesPara.Text = eventDetail.Question.Question;
					txtQuesDate.Text = eventDetail.Question.DateOfQuestion.ToLocalTime().ToString(DroidConstant.DATE_FORMAT);
					txtApproval.Text = "Approval: "+ Convert.ToString((QuestionStatus)eventDetail.Question.Status);

					//if (eventDetail.Question.Status == 1)
					//{
					//	txtApproval.Text = "Approved";
					//}
					//else if (eventDetail.Question.Status == 2)
					//{
					//	txtApproval.Text = "Pending";
					//}
					//else if (eventDetail.Question.Status == 3)
					//{
					//	txtApproval.Text = "Rejected";
					//}
					//else if (eventDetail.Question.Status == 4)
					//{
					//	txtApproval.Text = "Deleted";
					//}
				}
			}

		}



		private void InitilizeView()
		{
			toolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);

			TextView txtvwMenu = (TextView)FindViewById(Resource.Id.txtvwMenu);
			txtvwMenu.Text = "";

			//FindViewById(Resource.Id.txtvwTitle).Visibility = ViewStates.Gone;
			FindViewById(Resource.Id.relNotification).Visibility = ViewStates.Gone;

			txtvwMenu.SetOnClickListener(this);

			txtHeading = (TextView)FindViewById(Resource.Id.txtHeading);
			txtPresenterName = (TextView)FindViewById(Resource.Id.txtName);
			txtDate = (TextView)FindViewById(Resource.Id.txtDate);
			txtTime = (TextView)FindViewById(Resource.Id.txtTime);
			txtDuration = (TextView)FindViewById(Resource.Id.txtDuration);
			txtPrice = (TextView)FindViewById(Resource.Id.txtPrice);
			txtParagraph = (TextView)FindViewById(Resource.Id.txtParagraph);
			txtPresentedBy = (TextView)FindViewById(Resource.Id.txtPresentedBy);
			txtLeftDays = (TextView)FindViewById(Resource.Id.txtLeftDays);
			txtQuesPara = (TextView)FindViewById(Resource.Id.txtQuesPara);
			txtApproval = (TextView)FindViewById(Resource.Id.txtApproval);

			txtViewEvent = (TextView)FindViewById(Resource.Id.txtViewEvent);
			detailImage = (ImageView)FindViewById(Resource.Id.detail_image);
			lnrEnrolledLyt = (LinearLayout)FindViewById(Resource.Id.lnrEnrolledLyt);
			lnrQustnLyt = (LinearLayout)FindViewById(Resource.Id.lnrQustnLyt);
			txtQuesDate = (TextView)FindViewById(Resource.Id.txtQuesDate);
			lnrViewEvent = (LinearLayout)FindViewById(Resource.Id.lnrViewEvent);
			txtVenue = (TextView)FindViewById(Resource.Id.txtVenue);

			SetClickListener();
		}


		private void startEventTime()
		{
			//eventDetail.DateOfEvent=eventDetail.DateOfEvent.AddDays(-1).AddHours(-9).AddMinutes(-15);
			ts = eventDetail.DateOfEvent - DateTime.UtcNow;
			if (ts.TotalSeconds > 0)
			{
				currentTimer = new System.Timers.Timer()
				{
					Interval = 1000,
					AutoReset = true,
					Enabled = true
				};

				//start timer and enable timer ui
				currentTimer.Elapsed += delegate
				{
					this.RunOnUiThread(() => RunTimer());
				};
				currentTimer.Start();
			}
			else
			{
				lnrViewEvent.Visibility = Android.Views.ViewStates.Gone;
				txtViewEvent.Visibility = Android.Views.ViewStates.Visible;
			}
		}

		void SetClickListener()
		{
			txtViewEvent.SetOnClickListener(this);
			//txtvwLogin.Click +=  async delegate {
			//};
		}
		async void RunTimer()
		{
			ts = eventDetail.DateOfEvent - DateTime.UtcNow;
			if (ts.TotalSeconds > 0)
			{
				// Difference in days.
				differenceInDays = ts.Days;

				// Difference in Hours.
				differenceInHours = ts.Hours;

				// Difference in Minutes.
				differenceInMinutes = ts.Minutes;

				// Difference in Seconds.
				differenceInSeconds = ts.Seconds;
				string time = (differenceInDays > 0 ? (differenceInDays + " Days ") : "") + differenceInHours.ToString("00") + ":"
						   + differenceInMinutes.ToString("00") + ":" + differenceInSeconds.ToString("00") + " Left";
				txtLeftDays.Text = time;

			}
			else
			{
				currentTimer.Stop();
				lnrViewEvent.Visibility = Android.Views.ViewStates.Gone;
				txtViewEvent.Visibility = Android.Views.ViewStates.Visible;
			}

		}

		#region GetPropertyEvent List
		/// <summary>
		/// Fetch Event 
		/// </summary>
		/// <returns>List</returns>
		async Task<EventDetail> GetEventDetail()
		{

			EventDetail result = null;
			if (AppUtils.IsNetwork())
			{
				var request = new EventDetailRequest
				{
					EventId = eventId
				};
				_objProgress = new CustomProgress(this);
				var Authkey = StorageUtils<String>.GetPreferencesValue(DroidConstant.CurrentUser);
				var response = await _IEventListService.GetEventDetail(request, ServiceType.EventService, Authkey);
				_objProgress.DismissDialog();
				if (response != null)
				{
					if (response.IsSuccess && response.Result != null)
					{
						result = response.Result;


					}
					else
					{
						AppUtils.ShowToast(this, response.Message);
					}
				}
				else
				{
					AppUtils.ShowToast(this, Resources.GetString(Resource.String.network_error));

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
				case Resource.Id.txtViewEvent:
					var activity2 = new Intent(this, typeof(JWPlayerActivity));
					activity2.PutExtra ("videoUrl", eventDetail.VideoUrl);
					StartActivity(activity2);
					break;

			}
		}
		#endregion
		public enum QuestionStatus
		{
			Approved = 1,
			Pending = 2,
			Rejected = 3,
			Deleted = 4
		}
	}

}

