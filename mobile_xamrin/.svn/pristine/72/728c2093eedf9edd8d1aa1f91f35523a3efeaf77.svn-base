using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemConfiguration;

namespace VirtualEvent.iOS
{
	public partial class NotificationViewCtr : BaseViewController
	{
		private INotificationService _INotificationService = null;
		List<Notification> listItem;


		public NotificationViewCtr(IntPtr handle) : base(handle)
		{
			_INotificationService = new NotificationService();

		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            lblNotification.Font = UIFont.FromName("OpenSans", 14);
        }

		public override async void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			base.ViewWillAppear(animated);
			btnSideMenu.AccessibilityIdentifier = "btnSideMenu";

			btnSideMenu.TouchUpInside += delegate
			{
				var Notification = Storyboard.InstantiateViewController(AppConstant.HomeController);
				this.NavigationController.PushViewController(Notification, true);
			};
			listItem = await GetNotificationList();
			//var bgColoe = new UIColor((nfloat)(234 / 255.0), (nfloat)(232 / 255.0), (nfloat)(232 / 255.0), (nfloat)(1));
			//var redTextColor = new UIColor((nfloat)(148 / 255.0), (nfloat)(26 / 255.0), (nfloat)(33 / 255.0), (nfloat)(1));
			//var GreyTextColor = new UIColor((nfloat)(85 / 255.0), (nfloat)(85 / 255.0), (nfloat)(85 / 255.0), (nfloat)(1));

			SidebarController.CloseMenu(true);

			TableViewNotify.Source = new NotificationTableDataSource(_INotificationService, listItem);
			TableViewNotify.ReloadData();
		}

		async Task<List<Notification>> GetNotificationList()
		{
			List<Notification> result = null;
			NetworkReachabilityFlags flag;
			bool network = Reachability.IsNetworkAvailable(out flag);
			if (network)
			{
				CommonUtils.ShowProgress(View);
				var request = new NotificationRequest
				{

					PageNo = 1
				};
				var Authkey = StorageUtils<LoginResponse>.GetPreferences(AppConstant.CurrentUser).Result.Token;
				var response = await _INotificationService.GetEventList(request, ServiceType.NotificationService, Authkey);
				if (response != null)
				{
					if (response.IsSuccess && response.Result != null)
					{
						result = response.Result;

						if (result.Count == 0)
							CommonUtils.AlertView(response.Message);
					}
					else
					{
						CommonUtils.AlertView(response.Message);
					}
				}
				else
				{
					CommonUtils.AlertView(AppConstant.NetworkError);

				}
				CommonUtils.HideProgress();
			}
			else
			{
				CommonUtils.AlertView(AppConstant.NetworkError);
			}
			return result;
		}
	}
}