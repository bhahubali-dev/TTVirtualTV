using System;
namespace VirtualEvent.iOS
{
	public static class AppConstant
	{
		#region Storyboards

		public const string MainStoryboard = "Main";

		#endregion

		#region Storage PreferencesKeys

		public const string CurrentUser = "CurrentUser";
public const string EventDetail = "EventDetail";
public const string EnroledEventDetail = "EnroledEventDetail";

		#endregion

		#region Service Staff Controllers

		public const string HomeController = "HomeViewCtr";
		public const string LoginController = "LoginViewController";
		public const string ThankYouController = "ThankYouViewCtr";
		public const string SideMenuController = "SideMenuViewCtr";
		public const string EnrolledEventDetailController = "EnrolledDetailViewCtr";
		public const string EventDetailController = "EventDetailViewCtr";
		public const string NotificationController = "NotificationViewCtr";
		public const string ContactusController = "ContactUsViewController";
		public const string MediaPlayerController = "MediaPlayerViewCtr";
		#endregion
		#region Alert Messages

		public const string AlertTitle = "";
		public const string NetworkError = "Please check your internet connection.";
		public const string UnderDevelopment = "Opps! This feature is under development....";

		#endregion

		#region SideMenu

		public const string MenuName = "Home,Contact Us,Logout";
		public const string MenuName_Fonts = "\ue940,\ue937,\ue908";

		public const string SideMenuVC = "SideMenuVC";

		#endregion

		#region Common

		public const string IconFile = "icomoon";
		public const string BackButtonFont = "\ue92f";
		public const int BackButtonSize = 24;

		public const string ic_SideMenu = "\ue90a";
		public const int SideMenuButtonSize = 24;

		public const string ic_CheckBox = "\ue927";
		public const string ic_UncheckBox = "\ue941";

		public const string ic_Home = "\ue940";
		public const string ic_Dropdown = "\ue93b";

		#endregion

	}
}
