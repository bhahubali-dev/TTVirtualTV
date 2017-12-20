using System;
using Foundation;
using UIKit;

namespace VirtualEvent.iOS
{


	public partial class RootViewController : UIViewController
	{
		// the sidebar controller for the app
		public SidebarNavigation.SidebarController SidebarController { get; private set; }

		public NavController NavController { get; private set; }

public LoginResponse CurrentUser
		{
			get
			{
				return StorageUtils<LoginResponse>.GetPreferences(AppConstant.CurrentUser) as LoginResponse;
			}
		}

		public override UIStoryboard Storyboard
		{
			get
			{
				return UIStoryboard.FromName("Main", null);
			}

		}
		public string DeviceToken
		{
			get
			{
				return NSUserDefaults.StandardUserDefaults.StringForKey("PushDeviceToken");
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			NavController = new NavController();
			// create a slideout navigation controller with the top navigation controller and the menu view controller
			//SidebarController = new SidebarController(this, new ContentController(), new SideMenuController());

			//NavController = new NavController();

			//NavController.PushViewController(new IntroPage().CreateViewController(), false);
			//SidebarController = new SidebarNavigation.SidebarController(this, NavController, new SideMenuViewCtr());
			//SidebarController.MenuWidth = 220;
			//SidebarController.ReopenOnRotate = false;

			UIViewController initiateController = null;
			var plist = NSUserDefaults.StandardUserDefaults;
			var username = plist.BoolForKey("IsLogged");
			if (username)
			{
				initiateController = Storyboard.InstantiateViewController(AppConstant.HomeController);
				NavController.PushViewController(initiateController, true);

			}
			else
			{
				initiateController = Storyboard.InstantiateViewController(AppConstant.LoginController);
				NavController.PushViewController(initiateController, true);
			}


			UIViewController menuController = UIStoryboard.FromName(AppConstant.MainStoryboard, null).InstantiateViewController(AppConstant.SideMenuController);
			NavController.SetNavigationBarHidden(true, true);
			SidebarController = new SidebarNavigation.SidebarController(this, NavController, menuController);
			SidebarController.MenuLocation = SidebarNavigation.SidebarController.MenuLocations.Left;
			SidebarController.MenuWidth = 300;
			SidebarController.ReopenOnRotate = true;



		}
	}
}
