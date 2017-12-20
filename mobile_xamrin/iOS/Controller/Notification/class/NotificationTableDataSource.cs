using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace VirtualEvent.iOS
{
   public class NotificationTableDataSource : UITableViewSource
	{
		
     // private INotificationService _INotificationService = null;

		private static List<Notification> _listItem = null;

		public NotificationTableDataSource(INotificationService INotificationService, List<Notification> firstPage)
		{
			if (firstPage != null)
			{
				//_INotificationService = INotificationService;
				_listItem = firstPage;
			}
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell("NotificationCell", indexPath);
			var data = _listItem[indexPath.Row];
			var lblQustion = cell.ViewWithTag(101) as UILabel;
            if (lblQustion != null)
            {
                lblQustion.Text = data.Question;
                lblQustion.Font= UIFont.FromName("Raleway-SemiBold", 15);
            }
           var lblEventTitle = cell.ViewWithTag(102) as UILabel;
            if (lblEventTitle != null)
            {
                lblEventTitle.Text = data.EventTitle;
                lblEventTitle.Font= UIFont.FromName("OpenSans", 12);

            }



			var lblEventDate = cell.ViewWithTag(103) as UILabel;
            if (lblEventDate != null)
            {
                lblEventDate.Text = "Date : " + data.DateOfEvent.ToString("d");
                lblEventDate.Font= UIFont.FromName("OpenSans", 12);
            }

			var lblEventTime = cell.ViewWithTag(104) as UILabel;
            if (lblEventTime != null)
            {
                lblEventTime.Text = "Time : " + data.TimeOfEvent;
                lblEventTime.Font= UIFont.FromName("OpenSans", 12);

            }




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


		//public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		//{

		//    //this.tableView = tableView;
		//    //this.indexPath = indexPath;

		//    UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);

		//    if (cell == null)
		//    { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

		//    tableView.SeparatorColor = UIColor.White;


		//    return cell;
		//}

		//public override nint RowsInSection(UITableView tableview, nint section)
		//{
		//    return 10;
		//}
		//public override nint NumberOfSections(UITableView tableView)
		//{
		//	return 1;
		//}
		//public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		//{
		//	return 89.0f;
		//}
	}
}