using Foundation;
using System;
using UIKit;
using SystemConfiguration;
using System.Threading.Tasks;

namespace VirtualEvent.iOS
{
	public partial class EnrolledDetailViewCtr : BaseViewController
	{
		private IEventListService _IEventListService = null;
		EventDetail eventDetail;

		public EnrolledDetailViewCtr(IntPtr handle) : base(handle)
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
			btnBack.AccessibilityIdentifier = "btnBack";

			btnBack.TouchUpInside += delegate
						{
							//SidebarController.ToggleMenu();
							var HomeCtr = Storyboard.InstantiateViewController(AppConstant.HomeController);
							this.NavigationController.PushViewController(HomeCtr, true);
							//this.NavigationController.PopViewController(true);
						};
			eventDetail = await GetEventDetail();
			SidebarController.CloseMenu(true);
			//#region Referesh Sidebar content
			////UIViewController menuController = Storyboard.InstantiateViewController(AppConstant.SideMenuController);
			////SidebarNavigation.SidebarController.ChangeMenuView(menuController);
			//#endregion
			//TableViewEventEnrolledDetail.EstimatedRowHeight = UITableView.AutomaticDimension;
			//TableViewEventEnrolledDetail.RowHeight = UITableView.AutomaticDimension;
			TableViewEventEnrolledDetail.Source = new EnrolledEventDetailTableDataSource(_IEventListService, eventDetail);
			TableViewEventEnrolledDetail.ReloadData();
			TableViewEventEnrolledDetail.Delegate = new EnrolledDetailTableDateDelegate();
			TableViewEventEnrolledDetail.TableFooterView = new UIView();;

		}



		async Task<EventDetail> GetEventDetail()
		{
			EventDetail result = null;
			NetworkReachabilityFlags flag;
			bool network = Reachability.IsNetworkAvailable(out flag);
			if (network)
			{
				CommonUtils.ShowProgress(View);
				var eventID = StorageUtils<EventList>.GetPreferences(AppConstant.EventDetail).EventId;
				var request = new EventDetailRequest
				{
					EventId = eventID
				};
				var Authkey = StorageUtils<LoginResponse>.GetPreferences(AppConstant.CurrentUser).Result.Token;
				var response = await _IEventListService.GetEventDetail(request, ServiceType.EventService, Authkey);
				if (response != null)
				{
					if (response.IsSuccess && response.Result != null)
					{
						result = response.Result;
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