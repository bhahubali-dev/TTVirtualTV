using System;
using UIKit;

namespace VirtualEvent.iOS
{
	public partial class BaseViewController : UIViewController
	{
		// provide access to the sidebar controller to all inheriting controllers
		protected SidebarNavigation.SidebarController SidebarController
		{
			get
			{
				return (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.SidebarController;
			}
		}

		// provide access to the sidebar controller to all inheriting controllers
		protected NavController NavController
		{
			get
			{
				return (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.NavController;
			}
		}

		public override UIStoryboard Storyboard
		{
			get
			{
				return (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.Storyboard;
				//return base.Storyboard;
			}
		}
protected string DeviceToken
		{
			get
			{
				return (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.DeviceToken;
			}
		}


		public BaseViewController(IntPtr handle) : base(handle)
		{

		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			//_selectedProperty = StorageUtils<TimeTrackingRequest>.GetPreferences(AppConstant.SelectedProperty   }


		}

	}
}
