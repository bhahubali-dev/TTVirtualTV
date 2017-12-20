using Foundation;
using System;
using UIKit;
using SystemConfiguration;
using System.Threading.Tasks;
using Facebook.CoreKit;
using Facebook.LoginKit;


namespace VirtualEvent.iOS
{
	public partial class SideMenuViewCtr : BaseViewController
	{
		public SideMenuViewCtr(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			btnLogout.AccessibilityIdentifier = "btnLogout";

			btnLogout.TouchUpInside += async delegate
						{
							await UserLogOut();
						};
          //  var text = "Virtual Event";

            //var attributedString = new NSMutableAttributedString(text);

            //var nsKern = new NSString("NSKern");
            //var spacing = NSObject.FromObject(3.2);
            //var range = new NSRange(0, text.Length - 1);

            btnHome.Font= UIFont.FromName("OpenSans", 16);
            btnContactUs.Font = UIFont.FromName("OpenSans", 16);
            btnLogout.Font = UIFont.FromName("OpenSans", 16);
		}

		partial void btnHome_UpInside(UIButton sender)
		{
			SidebarController.CloseMenu(true);
			CommonUtils.RedirectToController(AppConstant.HomeController);
		}

		partial void btnContactUs_UpInside(UIButton sender)
		{
			//CommonUtils.AlertView(AppConstant.UnderDevelopment);
			SidebarController.CloseMenu(true);
			CommonUtils.RedirectToController(AppConstant.ContactusController);
		}

		//partial void btnLogout_UpInside(UIButton sender)
		//{
			
		//	//CommonUtils.AlertView(AppConstant.UnderDevelopment);

		//}


		protected async Task<bool> UserLogOut()
		{
			//LoginManager.Instance.LogOut();

			ILoginService _ILoginService = new LoginService();

			NetworkReachabilityFlags flag;
			bool network = Reachability.IsNetworkAvailable(out flag);
			if (network)
			{
				CommonUtils.ShowProgress(View);
				var Authkey = StorageUtils<LoginResponse>.GetPreferences(AppConstant.CurrentUser).Result.Token;
				var response = await _ILoginService.LogoutUser(ServiceType.UserService, Authkey);
				if (response != null)
				{
					if (response.IsSuccess)
					{
						var plist = NSUserDefaults.StandardUserDefaults;
						plist.SetBool(false, "IsLogged");
						CommonUtils.HideProgress();
						SidebarController.CloseMenu(true);
						new LoginManager().LogOut();
						CommonUtils.RedirectToController(AppConstant.LoginController);
						return true;
					}
					else
					{
						CommonUtils.AlertView(response.Message);
						CommonUtils.HideProgress();
						return true;
					}
				}
				else
				{
					CommonUtils.HideProgress();
					CommonUtils.AlertView(AppConstant.NetworkError);
					return true;
				}
			}
			else
			{
				CommonUtils.AlertView(AppConstant.NetworkError);
				return true;

			}

		}
	}
}