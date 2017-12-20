using Foundation;
using UIKit;
using SidebarNavigation;
using Facebook.CoreKit;
using Google.SignIn;

namespace VirtualEvent.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		string appId = "822879767861537";
		string appName = "Prem Rawat";
		protected string _deviceToken = string.Empty;

		public string DeviceToken { get { return _deviceToken; } }
		public override UIWindow Window
		{
			get;
			set;
		}

		public RootViewController RootViewController { get { return Window.RootViewController as RootViewController; } }

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method
			Window = new UIWindow(UIScreen.MainScreen.Bounds);

			// set our root view controller with the sidebar menu as the apps root view controller
			Window.RootViewController = new RootViewController();

			Window.MakeKeyAndVisible();

			#region Check for a Notification

			// check for a notification
			if (launchOptions != null)
			{

				// check for a local notification
				if (launchOptions.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
				{

					UILocalNotification localNotification = launchOptions[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
					if (localNotification != null)
					{

						new UIAlertView(localNotification.AlertAction, localNotification.AlertBody, null, "OK", null).Show();
						// reset our badge
						UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
					}
				}

				// check for a remote notification
				if (launchOptions.ContainsKey(UIApplication.LaunchOptionsRemoteNotificationKey))
				{

					NSDictionary remoteNotification = launchOptions[UIApplication.LaunchOptionsRemoteNotificationKey] as NSDictionary;
					if (remoteNotification != null)
					{
						//new UIAlertView(remoteNotification.AlertAction, remoteNotification.AlertBody, null, "OK", null).Show();
					}
				}
			}

			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
			{
				var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
											   UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
										   );

				application.RegisterUserNotificationSettings(notificationSettings);
				application.RegisterForRemoteNotifications();
			}
			else
			{
				//==== register for remote notifications and get the device token
				// set what kind of notification types we want
				UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge;
				// register for remote notifications
				UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
			}

			var googleServiceDictionary = NSDictionary.FromFile("GoogleService-Info.plist");
			SignIn.SharedInstance.ClientID = googleServiceDictionary["CLIENT_ID"].ToString();
			#endregion

			//Profile.EnableUpdatesOnAccessTokenChange(true);
			//Settings.AppID = appId;
			//Settings.DisplayName = appName;
			//return ApplicationDelegate.SharedInstance.FinishedLaunching(application, launchOptions);
			return true;
		}


		// For iOS 9 or newer
		public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
		{
			var openUrlOptions = new UIApplicationOpenUrlOptions(options);
			return SignIn.SharedInstance.HandleUrl(url, openUrlOptions.SourceApplication, openUrlOptions.Annotation);
		}

		// For iOS 8 and older
		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			return SignIn.SharedInstance.HandleUrl(url, sourceApplication, annotation);
		}

		//public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
		//{
		//	var openUrlOptions = new UIApplicationOpenUrlOptions(options);
		//	return SignIn.SharedInstance.HandleUrl(url, openUrlOptions.SourceApplication, openUrlOptions.Annotation);
		//}

		//// For iOS 8 and older
		//public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		//{
		//	//return SignIn.SharedInstance.HandleUrl(url, sourceApplication, annotation);
		//	return ApplicationDelegate.SharedInstance.OpenUrl(application, url, sourceApplication, annotation);
		//	//var FBsignin = ApplicationDelegate.SharedInstance.OpenUrl(application, url, sourceApplication, annotation);


		//	//var googleSignin = SignIn.SharedInstance.HandleUrl(url, sourceApplication, annotation);

		//	//return googleSignin || FBsignin;
		//}

	

		public override void OnResignActivation(UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground(UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground(UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated(UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate(UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}

		public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
		{
			_deviceToken = deviceToken.Description;
			if (!string.IsNullOrWhiteSpace(_deviceToken))
			{
				_deviceToken = _deviceToken.Trim('<').Trim('>');
			}

			// Get previous device token
			var oldDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey("DeviceToken");

			// Has the token changed?
			if (string.IsNullOrEmpty(oldDeviceToken) || !oldDeviceToken.Equals(_deviceToken))
			{
				//TODO: Put your own logic here to notify your server that the device token has changed/been created!
			}

			// Save new device token 
			NSUserDefaults.StandardUserDefaults.SetString(DeviceToken, "DeviceToken");
		}

		public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
		{
			new UIAlertView("Error registering push notifications", error.LocalizedDescription, null, "OK", null).Show();
		}
	}
}

