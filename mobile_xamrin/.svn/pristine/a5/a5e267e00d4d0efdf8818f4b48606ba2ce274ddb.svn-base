using Foundation;
using System;
using UIKit;

namespace VirtualEvent.iOS
{
	public partial class ContactUsViewController : BaseViewController
	{
		public ContactUsViewController(IntPtr handle) : base(handle)
		{
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			btnBack.AccessibilityIdentifier = "btnBack";

			btnBack.TouchUpInside += delegate
						{
				//SidebarController.ToggleMenu()
				var HomeCtr = Storyboard.InstantiateViewController(AppConstant.HomeController);
							this.NavigationController.PushViewController(HomeCtr, true);
						};
			SidebarController.CloseMenu(true);
		}

	}
}