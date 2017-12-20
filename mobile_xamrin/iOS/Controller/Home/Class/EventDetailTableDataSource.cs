using System;
using System.Collections.Generic;
using FFImageLoading;
using FFImageLoading.Work;
using Foundation;
using UIKit;
namespace VirtualEvent.iOS
{
	public class EventDetailTableDataSource : UITableViewSource
	{
		EventDetail eventDetail;
	//	IEventListService _IEventListService;

		public EventDetailTableDataSource(IEventListService _IEventListService, EventDetail eventDetail)
		{
			//this._IEventListService = _IEventListService;
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
                    lblDescription.Font= UIFont.FromName("OpenSans", 14);
                }
				var lblPresenter = cell.ViewWithTag(202) as UILabel;
                if (lblPresenter != null)
                {
                    lblPresenter.Text = "Presented by " + eventDetail.Presenter;
                    lblPresenter.Font = UIFont.FromName("OpenSans-Italic", 12);
                }

				return cell;
			}
			else
			{
				var cell = tableView.DequeueReusableCell("EventDetailVC", indexPath);

				return cell;
			}

		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return 2;
		}
		public override void RowDeselected(UITableView tableView, NSIndexPath indexPath)
		{
			//base.RowDeselected(tableView, indexPath);
			tableView.DeselectRow(indexPath, false);
		}
		public override NSIndexPath WillDeselectRow(UITableView tableView, NSIndexPath indexPath)
		{
			return base.WillDeselectRow(tableView, indexPath);
		}
	}
}