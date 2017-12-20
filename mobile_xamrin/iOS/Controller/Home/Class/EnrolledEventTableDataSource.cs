using System;
using System.Collections.Generic;
using FFImageLoading;
using FFImageLoading.Work;
using Foundation;
using UIKit;

namespace VirtualEvent.iOS
{
	public class EnrolledEventTableDataSource : UITableViewSource
	{
		//private IEventListService _IEventListService = null;
		private static List<EventList> _listItem = null;

		public EnrolledEventTableDataSource(IEventListService IEventListService, List<EventList> firstPage)
		{
			//_IEventListService = IEventListService;
			_listItem = firstPage;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell("EnrolledEventVC", indexPath);
			var data = _listItem[indexPath.Row];
			var lblEventTitle = cell.ViewWithTag(101) as UILabel;
			if (lblEventTitle != null)
			{
				lblEventTitle.Text = data.Title;
				lblEventTitle.Font = UIFont.FromName("Raleway-SemiBold", 15);
			}

			var lblEventvenue = cell.ViewWithTag(102) as UILabel;
			if (lblEventvenue != null)
			{
				lblEventvenue.Text = data.Description;
				lblEventvenue.Font = UIFont.FromName("OpenSans", 11);
			}
			var lblEventDate = cell.ViewWithTag(103) as UILabel;
			if (lblEventDate != null)
			{
				lblEventDate.Text = "Date : " + data.DateOfEvent.ToString("d");
				lblEventDate.Font = UIFont.FromName("OpenSans", 12);
			}
			var lblEnrollment = cell.ViewWithTag(107) as UILabel;
			if (lblEnrollment != null)
			{
				lblEnrollment.Font = UIFont.FromName("OpenSans", 12);
				lblEnrollment.Text = "Enrollment : " + data.EnrolmentDate.ToString("MMMM dd ,yyyy");
			}

			var imgUrl = ApiRouteConstant.BaseUrlImages + data.MediaUrl;
			UIImageView profileImgView = cell.ViewWithTag(104) as UIImageView;
			var taskIMage = ImageService.Instance.LoadUrl(imgUrl)
				.ErrorPlaceholder("list_placeholder", ImageSource.ApplicationBundle)
				.LoadingPlaceholder("list_placeholder", ImageSource.CompiledResource);
			taskIMage.Into(profileImgView);


			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			if (_listItem != null)
			{

				return _listItem.Count;
			}
			else
				return 0;
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
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{


			tableView.DeselectRow(indexPath, true);
			var item = _listItem[indexPath.Row];
			if (item != null)
			{
				EventList model = new EventList()
				{
					EventId = item.EventId
				};
				StorageUtils<EventList>.SavePreferences(AppConstant.EventDetail, model);
				CommonUtils.RedirectToController(AppConstant.EnrolledEventDetailController);
			}
		}
	}
}
