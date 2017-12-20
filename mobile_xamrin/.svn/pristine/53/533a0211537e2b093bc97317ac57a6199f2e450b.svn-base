using System;
using System.Collections.Generic;
using FFImageLoading;
using FFImageLoading.Work;
using Foundation;
using UIKit;
using System.Threading.Tasks;
using MediaPlayer;

namespace VirtualEvent.iOS
{
	public class EnrolledEventDetailTableDataSource : UITableViewSource
	{
		//private IEventListService _IEventListService = null;
		EventDetail eventDetail;
		TimeSpan ts;
		DateTime utcDateTime, LocalDateTime;
		System.Timers.Timer currentTimer;
		UILabel lblTimeLeftDays;
		UIButton btnClickToView;
		int differenceInDays, differenceInHours, differenceInMinutes, differenceInSecounds;
		public EnrolledEventDetailTableDataSource(IEventListService IEventListService, EventDetail eventDetail)
		{
			//_IEventListService = IEventListService;
			this.eventDetail = eventDetail;

		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            if (indexPath.Row == 0)
            {
                var cell = tableView.DequeueReusableCell("EventTitleVC", indexPath);

var imgUrl = ApiRouteConstant.BaseUrlImages + eventDetail.MediaUrl;
                UIImageView profileImgView = cell.ViewWithTag(101) as UIImageView;
				var taskIMage = ImageService.Instance.LoadUrl(imgUrl)
											.ErrorPlaceholder("detail_placeholder", ImageSource.ApplicationBundle)
											.LoadingPlaceholder("detail_placeholder", ImageSource.CompiledResource);
                taskIMage.Into(profileImgView);


                var lblPresenterName = cell.ViewWithTag(102) as UILabel;
                if (lblPresenterName != null)
                {
                    lblPresenterName.Text = eventDetail.Presenter;
                    lblPresenterName.Font = UIFont.FromName("OpenSans", 13);
                }

                var lblTitle = cell.ViewWithTag(103) as UILabel;
                if (lblTitle != null)
                {
                    lblTitle.Text = eventDetail.Title;
                    lblTitle.Font = UIFont.FromName("Raleway-Bold", 24);
                }

                var lblDateOfEvent = cell.ViewWithTag(104) as UILabel;
                if (lblDateOfEvent != null)
                {
                    lblDateOfEvent.Text = "Date : " + eventDetail.DateOfEvent.ToString("MMMMM dd, yyyy");
                    lblDateOfEvent.Font = UIFont.FromName("OpenSans", 12);
                }

                var lblTimeOfEvent = cell.ViewWithTag(105) as UILabel;
                if (lblTimeOfEvent != null)
                {

                    lblTimeOfEvent.Text = "Time : " + eventDetail.TimeOfEvent;
                    lblTimeOfEvent.Font = UIFont.FromName("OpenSans", 12);
                }
                var lblVenue = cell.ViewWithTag(106) as UILabel;
                if (lblVenue != null)
                {
                    lblVenue.Text = eventDetail.Venue;
                    lblVenue.Font = UIFont.FromName("OpenSans", 12);
                }
                var lblDuration = cell.ViewWithTag(107) as UILabel;
                if (lblDuration != null)
                {
                    lblDuration.Text = "Duration : " + eventDetail.DurationHour + " Hours " + eventDetail.DurationMinute + " Minutes";
                    lblDuration.Font = UIFont.FromName("OpenSans", 12);
                }
                var lblEnrollmentPrice = cell.ViewWithTag(108) as UILabel;
                if (lblEnrollmentPrice != null)
                {
                    lblEnrollmentPrice.Text = eventDetail.EnrollmentPrice;
                    lblEnrollmentPrice.Font = UIFont.FromName("OpenSans-Bold", 15);
                }
                return cell;
            }
            else if (indexPath.Row == 1)
            {
                var cell = tableView.DequeueReusableCell("EventDetailVC", indexPath);
                var lblDescription = cell.ViewWithTag(201) as UILabel;
                if (lblDescription != null)
                {
                    lblDescription.Text = eventDetail.Description;
                    lblDescription.Font = UIFont.FromName("OpenSans", 14);
                }
                var lblPresenter = cell.ViewWithTag(202) as UILabel;
                if (lblPresenter != null)
                {
                    lblPresenter.Text = eventDetail.Presenter;
                    lblPresenter.Font = UIFont.FromName("OpenSans-Italic", 12);
                }
				return cell;
			}
			else if (indexPath.Row == 2)
			{
				var cell = tableView.DequeueReusableCell("TimmerVC", indexPath);

				lblTimeLeftDays = cell.ViewWithTag(301) as UILabel;
				lblTimeLeftDays.Font = UIFont.FromName("OpenSans-Semibold", 28);
				//if (lblDescription != null)
				//	lblDescription.Text = eventDetail.Description;
				 btnClickToView = cell.ViewWithTag(302) as UIButton;

				if (btnClickToView != null)
				{
					var redColoe = new UIColor((nfloat)(148 / 255.0), (nfloat)(26 / 255.0), (nfloat)(33 / 255.0), (nfloat)(1));
					btnClickToView.Layer.BorderColor = redColoe.CGColor;
					btnClickToView.Layer.BorderWidth = 1;
					btnClickToView.AccessibilityIdentifier = "btnClickToView";
					btnClickToView.Font = UIFont.FromName("OpenSans", 14);

					btnClickToView.SetTitle("CLICK HERE TO VIEW EVENT", UIControlState.Normal);

					btnClickToView.TouchUpInside -= OnLiveButtonTapped;
					btnClickToView.TouchUpInside += OnLiveButtonTapped;
				}
                StartEventTime();
				return cell;
			}
			else if (indexPath.Row == 3)
			{
				var cell = tableView.DequeueReusableCell("EventQuestionVC", indexPath);
				var lblQDate = cell.ViewWithTag(401) as UILabel;
                if (lblQDate != null)
                {
                    lblQDate.Text = "Date : " + eventDetail.Question.DateOfQuestion.ToString("MMMMM dd,yyyy");
                    lblQDate.Font = UIFont.FromName("OpenSans", 12);
                }
				var lblQuestion = cell.ViewWithTag(402) as UILabel;
                if (lblQuestion != null)
                {
					lblQuestion.Text = eventDetail.Question.Question;

                    lblQuestion.Font =UIFont.FromName("OpenSans", 14);
                }

				var lblApproved = cell.ViewWithTag(403) as UILabel;
				if (lblApproved != null)
				{
					QuestionStatus enumQuestionStatus = (QuestionStatus)eventDetail.Question.Status;
					lblApproved.Text = "Approval " + Convert.ToString((QuestionStatus)eventDetail.Question.Status);
                    lblApproved.Font =UIFont.FromName("OpenSans-Italic", 12);
                }
				return cell;
			}
			else
			{
				var cell = tableView.DequeueReusableCell("EventQuestionVC", indexPath);
				return cell;
			}
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{

			return 4;
		}
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			 tableView.DeselectRow(indexPath, true);
		}



		void OnLiveButtonTapped(object sender, EventArgs e)
		{
			UIApplication.SharedApplication.OpenUrl(new NSUrl(eventDetail.LiveStreamUrl));

			//UIApplication.SharedApplication.OpenUrl(new NSUrl(eventDetail.VideoUrl));

			//CommonUtils.RedirectToController(AppConstant.MediaPlayerController);
			//var navController = (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.NavController;
			//var storyboard = UIStoryboard.FromName(AppConstant.MainStoryboard, null);
			//var MediaPlayerViewCtr = new MediaPlayerViewCtr();
			//UIViewController viewController = storyboard.InstantiateViewController(AppConstant.MediaPlayerController);
			//MediaPlayerViewCtr.MediaUrl = eventDetail.L;
			//navController.PushViewController(viewController, true);
			//CommonUtils.AlertView("Click on Timer !");

			//var MediaPlayerViewCtr = new MediaPlayerViewCtr();
			//MediaPlayerViewCtr.MediaUrl = eventDetail.LiveStreamUrl;
			//MediaPlayerViewModel myTarget = new MediaPlayerViewModel();
			//myTarget.MediaUrl = eventDetail.LiveStreamUrl;
			//UIViewController viewController = storyboard.InstantiateViewController(AppConstant.MediaPlayerController);

			//navController.PushViewController(viewController, true);

		}



		public void StartEventTime()
		{
			utcDateTime = DateTime.SpecifyKind(eventDetail.DateOfEvent, DateTimeKind.Utc);
			LocalDateTime = utcDateTime.ToLocalTime();
			ts = LocalDateTime - DateTime.Now;
			if (ts.TotalSeconds > 0)
			{
				currentTimer = new System.Timers.Timer()
				{
					Interval = 1000,
					AutoReset = true,
					Enabled = true
				};
				currentTimer.Elapsed += delegate
				{
					InvokeOnMainThread(() =>
					{
						RunTimer(this);
					});
				};

				currentTimer.Start();
				//lblTimeLeftDays.Hidden = false;
				btnClickToView.Enabled = false;
			}
			else
			{
				lblTimeLeftDays.Text = "00:00";
				btnClickToView.Enabled = true;

			}
		}
	  void RunTimer(EnrolledEventDetailTableDataSource instance)
		{
			instance.ts = instance.LocalDateTime - DateTime.Now;
			if (ts.TotalSeconds > 0)
			{
				instance.differenceInDays = ts.Days;
				instance.differenceInHours = ts.Hours;
				instance.differenceInMinutes = ts.Minutes;
				instance.differenceInSecounds = ts.Seconds;

				var time = (instance.differenceInDays > 0 ? (instance.differenceInDays + " Days ") : "") + differenceInHours.ToString("00") + ":" + differenceInMinutes.ToString("00") + ":" + differenceInSecounds.ToString("00") + " Left";
				lblTimeLeftDays.Text = time;
				btnClickToView.Enabled = false;
			}
			else
			{
				currentTimer.Stop();
				lblTimeLeftDays.Text = "00:00";
				btnClickToView.Enabled = true;

			}


		}
	}
}
