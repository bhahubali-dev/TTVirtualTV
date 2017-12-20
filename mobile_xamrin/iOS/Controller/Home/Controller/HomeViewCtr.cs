using Foundation;
using System;
using UIKit;
using SidebarNavigation;
using CoreGraphics;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemConfiguration;

namespace VirtualEvent.iOS
{
	public partial class HomeViewCtr : BaseViewController
	{
		private IEventListService _IEventListService = null;
		List<EventList> listItem;
		List<EventList> listItemEnrolled;

		public HomeViewCtr(IntPtr handle) : base(handle)
		{
			_IEventListService = new EventListService();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
           
        }


		public async override void ViewWillAppear(bool animated)
		{

			base.ViewWillAppear(animated);
            var text = "Virtual Event";

            var attributedString = new NSMutableAttributedString(text);

            var nsKern = new NSString("NSKern");
            var spacing = NSObject.FromObject(3.2);
            var range = new NSRange(0, text.Length - 1);

            attributedString.AddAttribute(nsKern, spacing, range);
            HomeLabel.AttributedText = attributedString;
            btnEventList.Font = UIFont.FromName("OpenSans", 14);
            BtnEnrolled.Font = UIFont.FromName("OpenSans", 14);
            btnSideMenu.Font = UIFont.FromName("OpenSans", 14);



            btnSideMenu.AccessibilityIdentifier = "btnSideMenu";
			btnSideMenu.TouchUpInside += delegate
			{
				SidebarController.ToggleMenu();
			};
			listItem = await GetEventList();
			//listItemEnrolled = await GetEnrolledEventList();
			var bgColoe = new UIColor((nfloat)(234 / 255.0), (nfloat)(232 / 255.0), (nfloat)(232 / 255.0), (nfloat)(1));
			var redTextColor = new UIColor((nfloat)(148 / 255.0), (nfloat)(26 / 255.0), (nfloat)(33 / 255.0), (nfloat)(1));
			var GreyTextColor = new UIColor((nfloat)(85 / 255.0), (nfloat)(85 / 255.0), (nfloat)(85 / 255.0), (nfloat)(1));
			btnEventList.BackgroundColor = UIColor.White;
			btnEventList.SetTitleColor(redTextColor, UIControlState.Normal);

			BtnEnrolled.BackgroundColor = bgColoe;
			BtnEnrolled.SetTitleColor(GreyTextColor, UIControlState.Normal);
			SidebarController.CloseMenu(true);
			#region Referesh Sidebar content
			//UIViewController menuController = Storyboard.InstantiateViewController(AppConstant.SideMenuController);
			//SidebarNavigation.SidebarController.ChangeMenuView(menuController);
			#endregion

			TableEventView.EstimatedRowHeight = 150;
			//TableEventView.RowHeight = UITableView.AutomaticDimension;
			//TableEventView.SetNeedsLayout();
			//TableEventView.LayoutIfNeeded();
			TableEventView.Source = new EventTableDataSource(_IEventListService, listItem);
			TableEventView.ReloadData();
			TableEventView.Hidden = false;
			TableViewEnrolled.Hidden = true;

			btnEventList.AccessibilityIdentifier = "btnEventList";

			btnEventList.TouchUpInside += async delegate
								   {
									   listItem = await GetEventList();
									   btnEventList.BackgroundColor = UIColor.White;
									   btnEventList.SetTitleColor(redTextColor, UIControlState.Normal);

									   BtnEnrolled.BackgroundColor = bgColoe;
									   BtnEnrolled.SetTitleColor(GreyTextColor, UIControlState.Normal);
									   //btnEventList.SetTitle("", UIControlState.Application);

									   TableEventView.Hidden = false;
									   TableViewEnrolled.Hidden = true;

									   TableEventView.EstimatedRowHeight = 150;
									   //TableEventView.RowHeight = UITableView.AutomaticDimension;
									   //TableEventView.SetNeedsLayout();
									   //TableEventView.LayoutIfNeeded();
									   TableEventView.Source = new EventTableDataSource(_IEventListService, listItem);
									   TableEventView.ReloadData();
								   };

			BtnEnrolled.AccessibilityIdentifier = "BtnEnrolled";

			BtnEnrolled.TouchUpInside += async delegate
						{
							listItemEnrolled = await GetEnrolledEventList();
							BtnEnrolled.BackgroundColor = UIColor.White;
							BtnEnrolled.SetTitleColor(redTextColor, UIControlState.Normal);

							btnEventList.BackgroundColor = bgColoe;
							btnEventList.SetTitleColor(GreyTextColor, UIControlState.Normal);
							TableEventView.Hidden = true;
							TableViewEnrolled.Hidden = false;

							//TableViewEnrolled.EstimatedRowHeight = 150;
							//TableViewEnrolled.RowHeight = UITableView.AutomaticDimension;
							//TableViewEnrolled.SetNeedsLayout();
							//TableViewEnrolled.LayoutIfNeeded();
							TableViewEnrolled.Source = new EnrolledEventTableDataSource(_IEventListService, listItemEnrolled);
							TableViewEnrolled.ReloadData();
							CommonUtils.HideProgress();
						};
		}


		partial void BtnNotification_TouchUpInside(UIButton sender)
		{
			NotificationViewCtr Notification = Storyboard.InstantiateViewController("NotificationViewCtr") as NotificationViewCtr;
			this.NavigationController.PushViewController(Notification, true);
		}





		#region GetPropertyEvent List
		/// <summary>
		/// Fetch Event 
		/// </summary>
		/// <returns>List</returns>
		async Task<List<EventList>> GetEventList()
		{
			List<EventList> result = null;
			NetworkReachabilityFlags flag;
			bool network = Reachability.IsNetworkAvailable(out flag);
			if (network)
			{
				CommonUtils.ShowProgress(View);
				var request = new EventRequest
				{

					PageNo = 1
				};
				var Authkey = StorageUtils<LoginResponse>.GetPreferences(AppConstant.CurrentUser).Result.Token;
				var response = await _IEventListService.GetEventList(request, ServiceType.EventService, Authkey);
				if (response != null)
				{
					if (response.IsSuccess && response.Result != null)
					{
						result = response.Result;
						CommonUtils.HideProgress();
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
			CommonUtils.HideProgress();
			return result;
		}


		/// <summary>
		/// Fetch Event 
		/// </summary>
		/// <returns>List</returns>
		async Task<List<EventList>> GetEnrolledEventList()
		{
			List<EventList> result = null;
			NetworkReachabilityFlags flag;
			bool network = Reachability.IsNetworkAvailable(out flag);
			if (network)
			{
				CommonUtils.ShowProgress(View);
				var request = new EventRequest
				{

					PageNo = 1
				};
				var Authkey = StorageUtils<LoginResponse>.GetPreferences(AppConstant.CurrentUser).Result.Token;
				var response = await _IEventListService.GetEnrolledEventsList(request, ServiceType.EventService, Authkey);
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
					CommonUtils.HideProgress();
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
			CommonUtils.HideProgress();
			return result;
		}
		#endregion
	}
}