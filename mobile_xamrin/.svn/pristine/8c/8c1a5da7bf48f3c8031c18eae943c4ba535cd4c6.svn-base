using Foundation;
using System;
using UIKit;
using System.Threading.Tasks;
using SystemConfiguration;
using VirtualEvent;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using VirtualEvent.BusinessLayer.Authentication;
using Google.SignIn;
using Xamarin.Auth;
using System.Json;

namespace VirtualEvent.iOS
{
	public partial class LoginViewController : BaseViewController, ISignInUIDelegate
	{
		
		UserSocialLoginRequest model;
		public LoginViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			btnFbLogin.Frame = new CoreGraphics.CGRect(1, 59, 132, 44);
			SidebarController.CloseMenu(true);
			txtPassword.Text = "123456";
			txtEmail.Text = "amar@mail.com";
			txtEmail.Font = UIFont.FromName("OpenSans", 14);
			txtPassword.Font = UIFont.FromName("OpenSans", 14);
			lblSignInWith.Font = UIFont.FromName("OpenSans-Bold", 14);

			var redColoe = new UIColor((nfloat)(148 / 255.0), (nfloat)(26 / 255.0), (nfloat)(33 / 255.0), (nfloat)(1));
			btnLogin.Layer.BorderColor = redColoe.CGColor;
			btnLogin.Layer.BorderWidth = 1;
			btnLogin.AccessibilityIdentifier = "btnLogin";
			btnLogin.Font = UIFont.FromName("OpenSans", 14);

			btnLogin.SetTitle("SIGN IN", UIControlState.Normal);
			var text = "Virtual Event";

			var attributedString = new NSMutableAttributedString(text);

			var nsKern = new NSString("NSKern");
			var spacing = NSObject.FromObject(3.2);
			var range = new NSRange(0, text.Length - 1);

			attributedString.AddAttribute(nsKern, spacing, range);
			lblLogo.AttributedText = attributedString;
			lblLogo.Font = UIFont.FromName("SFUIDisplay-Regular", 24);

			btnLogin.TouchUpInside += async delegate
						{


							if (txtEmail.Text.Trim() == "" && txtPassword.Text.Trim() == "")
							{
								CommonUtils.AlertView("Please fill email and password.");
							}
							else if (txtEmail.Text.Trim() == "")
								CommonUtils.AlertView("Please fill email.");
							else if (txtPassword.Text.Trim() == "")
								CommonUtils.AlertView("Please fill password.");
							else if (txtPassword.Text.Trim() != "")
							{
								bool valid = Regex.IsMatch(txtEmail.Text, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9_\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.ECMAScript);
								if (!valid)
									CommonUtils.AlertView("Please enter valid email.");
								else
									await UserLogin();

							}
						};

			btnFbLogin.TouchUpInside += delegate
				 {

					 // https://developers.facebook.com/apps/
					 var auth = new OAuth2Authenticator(
						 clientId: "822879767861537",
						 scope: "",
						 authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
						 redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

					 var ui = auth.GetUI();

					 auth.Completed += FacebookAuth_Completed;

					 PresentViewController((UIKit.UIViewController)ui, true, null);
				 };





			#region Gogle Login
			// TODO(developer) Configure the sign-in button look/feel
			SignIn.SharedInstance.UIDelegate = this;

			SignIn.SharedInstance.SignedIn += (sender, e) =>
			{
				// Perform any operations on signed in user here.
				if (e.User != null && e.Error == null)
				{
					//statusText.Text = string.Format("Signed in user: {0}", e.User.Profile.Name);
					ToggleAuthUI();
				}
			};

			SignIn.SharedInstance.Disconnected += (sender, e) =>
			{
				// Perform any operations when the user disconnects from app here.
				//statusText.Text = "Disconnected user";
				ToggleAuthUI();
			};

			// Automatically sign in the user.
			SignIn.SharedInstance.SignInUserSilently();
			ToggleAuthUI();

			//statusText.Text = "Google Sign in\niOS Demo";
			#endregion

		}



		//partial void didTapSignOut(NSObject sender)
		//{
		//	SignIn.SharedInstance.SignOutUser();
		//	ToggleAuthUI();
		//}

		//partial void didTapDisconnect(NSObject sender)
		//{
		//	SignIn.SharedInstance.DisconnectUser();
		//}

		public void ToggleAuthUI()
		{
			if (SignIn.SharedInstance.CurrentUser == null || SignIn.SharedInstance.CurrentUser.Authentication == null)
			{
				// Not signed in
				//statusText.Text = "Google Sign in\niOS Demo";
				//signInButton.Hidden = false;
				//signOutButton.Hidden = true;
				//disconnectButton.Hidden = true;
			}
			else
			{
				// Signed in
				//signInButton.Hidden = true;
				//signOutButton.Hidden = false;
				//disconnectButton.Hidden = false;
			}
		}


		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}




		public async void FacebookAuth_Completed(object sender, AuthenticatorCompletedEventArgs e)
		{
			if (e.IsAuthenticated)
			{
				var request = new OAuth2Request(
					"GET",
					new Uri("https://graph.facebook.com/me?fields=name,picture,cover,first_name,gender,last_name,email"),
					null,
					e.Account);

				var fbResponse = await request.GetResponseAsync();

				var fbUser = JsonValue.Parse(fbResponse.GetResponseText());

				var name = fbUser["name"];
				var id = fbUser["id"];
				var FirstName = fbUser["first_name"];
				var LastName = fbUser["last_name"];
				//var Email = fbUser["Email"];
				var UserID = fbUser["gender"];
				var picture = fbUser["picture"]["data"]["url"];
				var cover = fbUser["cover"]["source"];
				DismissViewController(true, null);
				model = new UserSocialLoginRequest
				{
					FirstName = FirstName,
					LastName = LastName,
					Email = "",
					SocialId = UserID,
					LoginType = (int)LoginTypes.Facebook,
					DeviceType = (int)EnumDeviceType.IOS,
					DeviceToken = "ABC"// DeviceToken
				};

				await UserSocialLogin(model);

				//NameLabel.Text += name;
				//IdLabel.Text += id;
				//PictureImage.Image = UIImage.LoadFromData(NSData.FromUrl(new NSUrl(picture)));
				//CoverImage.Image = UIImage.LoadFromData(NSData.FromUrl(new NSUrl(cover)));
			}
			else
				DismissViewController(true, null);


		}


		#region UserLogin


		protected async Task<bool> UserLogin()
		{
			var token = await GetAuthKey();
			ILoginService _ILoginService = new LoginService();

			LoginRequest model = new LoginRequest
			{

				EmailId = txtEmail.Text.Trim(),
				Password = txtPassword.Text.Trim(),
				DeviceType = EnumDeviceType.IOS.ToString(),
				DeviceToken = "ABC"// DeviceToken
			};

			NetworkReachabilityFlags flag;
			bool network = Reachability.IsNetworkAvailable(out flag);
			if (network)
			{
				CommonUtils.ShowProgress(View);
				var response = await _ILoginService.LoginUser(model, ServiceType.UserService, token);
				if (response != null)
				{
					if (response.IsSuccess)
					{
						StorageUtils<LoginResponse>.SavePreferences(AppConstant.CurrentUser, response);
						var plist = NSUserDefaults.StandardUserDefaults;
						plist.SetBool(true, "IsLogged");

						CommonUtils.HideProgress();
						CommonUtils.RedirectToController(AppConstant.HomeController);
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

		public async Task<string> GetAuthKey()
		{
			ILoginService _ILoginService = new LoginService();

			AuthkeyRequest model = new AuthkeyRequest
			{
				DeviceType = (int)EnumDeviceType.IOS,
				DeviceToken = DeviceToken
			};
			NetworkReachabilityFlags flag;
			bool network = Reachability.IsNetworkAvailable(out flag);
			if (network)
			{
				CommonUtils.ShowProgress(View);
				var response = await _ILoginService.GetAuthkey(model, ServiceType.SessionService);
				if (response != null)
				{
					if (response.IsSuccess)
					{
						//StorageUtils<RespUserActivation>.SavePreferences(AppConstant.CurrentUser, response.Result);
						CommonUtils.HideProgress();
						//CommonUtils.RedirectToController(AppConstant.HomeController);
						return response.Result.Token;
					}

					else
					{
						CommonUtils.AlertView(response.Message);
						CommonUtils.HideProgress();
						return response.Result.Token;
					}
				}
				else
				{
					CommonUtils.HideProgress();
					CommonUtils.AlertView(AppConstant.NetworkError);
					return response.Result.Token;
				}
			}
			else
			{
				CommonUtils.AlertView(AppConstant.NetworkError);
				return null;
			}

		}


		protected async Task<bool> UserSocialLogin(UserSocialLoginRequest model)
		{
			var token = await GetAuthKey();
			ILoginService _ILoginService = new LoginService();

			NetworkReachabilityFlags flag;
			bool network = Reachability.IsNetworkAvailable(out flag);
			if (network)
			{
				CommonUtils.ShowProgress(View);
				var response = await _ILoginService.SocialLoginUser(model, ServiceType.UserService, token);
				if (response != null)
				{
					if (response.IsSuccess)
					{
						StorageUtils<LoginResponse>.SavePreferences(AppConstant.CurrentUser, response);
						var plist = NSUserDefaults.StandardUserDefaults;
						plist.SetBool(true, "IsLogged");

						CommonUtils.HideProgress();
						CommonUtils.RedirectToController(AppConstant.HomeController);
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

		#endregion
	}
}
