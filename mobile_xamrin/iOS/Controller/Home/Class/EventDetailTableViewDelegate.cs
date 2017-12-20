using System;
using UIKit;
namespace VirtualEvent.iOS
{
	public class EventDetailTableViewDelegate : UITableViewDelegate
	{

		private EventDetailViewCtr Controller;
		public EventDetailTableViewDelegate()
		{
		}
		public EventDetailTableViewDelegate(EventDetailViewCtr controller)
		{
			this.Controller = controller;
		}

		public override nfloat EstimatedHeight(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			//return UITableView.AutomaticDimension;


			if (indexPath.Row == 0)
			{
				return 423;
				//return UITableView.AutomaticDimension;
			}
			else if (indexPath.Row == 1)
			{
				//return 100;
				return UITableView.AutomaticDimension;
			}
			else
			{
				return 0;
			}

		}
		public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			//return UITableView.AutomaticDimension;

			if (indexPath.Row == 0)
			{
				return 423;
				return UITableView.AutomaticDimension;
			}
			else if (indexPath.Row == 1)
			{
				return UITableView.AutomaticDimension;
			}
			else
			{
				return 0;
			}
		}

		public override void RowDeselected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			//base.RowDeselected(tableView, indexPath);
			tableView.DeselectRow(indexPath, true);
		}

		public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			// RowDeselected(tableView, indexPath);
			tableView.DeselectRow(indexPath, true);

		}
	}

}