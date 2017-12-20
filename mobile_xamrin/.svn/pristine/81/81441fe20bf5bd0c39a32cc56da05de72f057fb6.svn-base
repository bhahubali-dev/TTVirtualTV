using System;
using MediaPlayer;
using UIKit;
namespace VirtualEvent.iOS
{
	public class EnrolledDetailTableDateDelegate : UITableViewDelegate
	{
        MPMoviePlayerController moviePlayer;
		private EnrolledDetailViewCtr Controller;
		public EnrolledDetailTableDateDelegate()
		{
		}
		public EnrolledDetailTableDateDelegate(EnrolledDetailViewCtr controller)
		{
			this.Controller = controller;
		}

		public override nfloat EstimatedHeight(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
							//return UITableView.AutomaticDimension;

			
			if (indexPath.Row == 0)
			{
				return 423;
			}
			else if (indexPath.Row == 1)
			{
				//return 100;
				return UITableView.AutomaticDimension;
			}
			else if (indexPath.Row == 2)
			{
                //return 150;
				return UITableView.AutomaticDimension;
			}
			else if (indexPath.Row == 3)
			{
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
			}
			else if (indexPath.Row == 1)
			{
				return UITableView.AutomaticDimension;
			}
			else if (indexPath.Row == 2)
			{
				//return 150;
				return UITableView.AutomaticDimension;
			}
			else if (indexPath.Row == 3)
			{
				//return 350;
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
			//if (indexPath.Row == 2)
			//{
			//	/*moviePlayer = new MPMoviePlayerController(NSUrl.FromFilename(@"https://www.youtube.com/watch?v=CUciBrtqFGM"));

			//	View.AddSubview(moviePlayer.View);
			//	moviePlayer.SetFullscreen(true, true);
			//	moviePlayer.ShouldAutoplay = true;
			//	moviePlayer.Play();*/

			//	CommonUtils.AlertView("Click on Timer  Delegate!");
			//}
		}

	}

}
