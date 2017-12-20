
using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Calligraphy;
using PerpetualEngine.Storage;
using VirtualEvent.Droid.Controllers.Activities;
using VirtualEvent.Droid.Helper;
using Xamarin.Facebook;
using Newtonsoft.Json;
using System.Net;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Login.Widget;
using Android.Gms.Common.Apis;
using Android.Gms.Common;
using Android.Gms.Plus;


using System.Collections.Generic;
using VirtualEvent.BusinessLayer.Authentication;
using Android.Util;

namespace VirtualEvent.Droid
{
	[Activity(Label = "Virtual Event",  Theme = "@style/Theme.AppCompat.Light.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class LoginActivity : AppCompatActivity, IFacebookCallback , 
        GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
    {
        const int RC_SIGN_IN = 9001;

        const string KEY_IS_RESOLVING = "is_resolving";
        const string KEY_SHOULD_RESOLVE = "should_resolve";
        LoginButton button;
        GoogleApiClient mGoogleApiClient;

        bool mIsResolving = false;

        bool mShouldResolve = false;
        private ICallbackManager mCallBackManager;
        private MyProfileTracker mProfileTracker;

        TextView txtvwLogin,txtvwGoogleLogin;

		TextView txtvwFacebookLogin;

		EditText edttxtPswd;
		EditText edttxtEmail;

		LoginService _ILoginService;
		CustomProgress _objProgress;

		//public override void InitilizeView()
		//{

		//}

		//public override int SetLayout()
		//{
		//	return Resource.Layout.activity_login;
		//}
		protected override void AttachBaseContext(Context newBase)
		{
			//SimpleStorage.SetContext(newBase);
			base.AttachBaseContext(CalligraphyContextWrapper.Wrap(newBase));
		}
		protected override void OnCreate(Bundle savedInstanceState)
		{

			base.OnCreate(savedInstanceState);
			SimpleStorage.SetContext(ApplicationContext);
			// Create your application here
			string token = StorageUtils<String>.GetPreferencesValue(DroidConstant.CurrentUser);
			if (token != null && token.Length > 0)
			{
				StartActivity(typeof(MainActivity));
				Finish();
			}

            FacebookSdk.SdkInitialize(this.ApplicationContext);
            SetContentView(Resource.Layout.activity_login);
            //#region PushNotification
            //if (Intent.Extras != null)
            //{
            //    foreach (var key in Intent.Extras.KeySet())
            //    {
            //        var value = Intent.Extras.GetString(key);
            //        Log.Debug("TAG", "Key: {0} Value: {1}", key, value);
            //    }
            //}
           
            //#endregion
            _ILoginService = new LoginService();
			InitilizeView();
            AppUtils.generateKeyHash(this);

       

            mProfileTracker = new MyProfileTracker();
            mProfileTracker.mOnProfileChanged += mProfileTracker_mOnProfileChanged;
            mProfileTracker.StartTracking();
             button = FindViewById<LoginButton>(Resource.Id.login_button);

            button.SetReadPermissions(new List<string> { "public_profile", "user_friends", "email" });

            mCallBackManager = CallbackManagerFactory.Create();

            button.RegisterCallback(mCallBackManager, this);


            mGoogleApiClient = new GoogleApiClient.Builder(this)
                .AddConnectionCallbacks(this)
                .AddOnConnectionFailedListener(this)
                .AddApi(PlusClass.API)
                .AddScope(new Scope(Scopes.Profile))
                .Build();

        }
      
        private void InitilizeView()
		{
			edttxtPswd = (EditText)FindViewById(Resource.Id.edttxt_pswd);
			edttxtEmail = (EditText)FindViewById(Resource.Id.edttxt_email);
			txtvwLogin = (TextView)FindViewById(Resource.Id.txtvw_lgn);
			txtvwGoogleLogin = (TextView)FindViewById(Resource.Id.txtvw_google_login);
			txtvwFacebookLogin = (TextView)FindViewById(Resource.Id.txtvw_facebook_login);
            
			SetClickListener();
		}

		void SetClickListener()
		{
			txtvwLogin.Click += async delegate
			{
				if (validateInputs())
				{
					_objProgress = new CustomProgress(this);
					String auth = await GetAuthKey();
					await UserLogin(auth);
				}
			};


            txtvwFacebookLogin.Click += delegate {

                button.PerformClick();



            };
            txtvwGoogleLogin.Click += delegate
            {
              
                mShouldResolve = true;
                mGoogleApiClient.Connect();

            };
  
		}



        public void OnCompleted(Org.Json.JSONObject json, GraphResponse response)
        {
            string data = json.ToString();
            FacebookResult result = JsonConvert.DeserializeObject<FacebookResult>(data);
            
        }

        void client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        async void mProfileTracker_mOnProfileChanged(object sender, OnProfileChangedEventArgs e)
        {
            if (e.mProfile != null)
            {
                try
                {
                   
                    _objProgress = new CustomProgress(this);
                    String auth = await GetAuthKey();
					await UserSocialLogin(auth, e.mProfile.Name.ToString(), e.mProfile.Name.ToString(), e.mProfile.Id, (int)LoginTypes.Facebook);
                    //  mTxtLastName.Text = e.mProfile.LastName;



                }

                catch (Exception ex)
                {
                    Toast.MakeText(this, ex.ToString(), ToastLength.Short);
                }
            }

            else
            {
                //the user must have logged out

            }
        }

        public void OnCancel()
        {
            //throw new NotImplementedException();
        }

        public void OnError(FacebookException error)
        {
            //throw new NotImplementedException();
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            LoginResult loginResult = result as LoginResult;
            Console.WriteLine(AccessToken.CurrentAccessToken.UserId);
        }
 

        protected override void OnActivityResult(int requestCode, Android.App.Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
           
            if (requestCode == RC_SIGN_IN)
            {
                if (resultCode != Android.App.Result.Ok)
                {
                    mShouldResolve = false;
                }

                mIsResolving = false;
                mGoogleApiClient.Connect();
               
              
            }
            else
            {
                mCallBackManager.OnActivityResult(requestCode, (int)resultCode, data);
            }
        }
     
        
        protected override void OnDestroy()
        {
            mProfileTracker.StopTracking();
            base.OnDestroy();
        }


        public bool IsValidEmail(String target)
		{
			if (target == null)
			{
				return false;
			}
			else
			{
				return Android.Util.Patterns.EmailAddress.Matcher(target).Matches();
			}
		}

		bool validateInputs()
		{
			if (!IsValidEmail(edttxtEmail.Text.Trim()))
			{
				AppUtils.ShowToast(this, "Please enter valid email address !!");
				return false;
			}
			if (!(edttxtPswd.Text.Trim().Length > 4))
			{
				AppUtils.ShowToast(this, "Please enter valid password !!");
				return false;
			}

			return true;
		}

        #region UserLogin
        protected async Task<bool> UserLogin(String authToken)
        {
            LoginRequest model = new LoginRequest
            {
                EmailId = edttxtEmail.Text.Trim(),
                Password = edttxtPswd.Text.Trim(),
				DeviceType = ((int)EnumDeviceType.Android).ToString(),
				DeviceToken = StorageUtils<String>.GetPreferencesValue(DroidConstant.DeviceToken)
            };

            if (AppUtils.IsNetwork())
            {
                var response = await _ILoginService.LoginUser(model, ServiceType.UserService, authToken);
                if (response != null)
                {
                    if (response.IsSuccess)
                    {
                        //StorageUtils<String>.GetPreferences(DroidConstant.CurrentUser)
                        string token = response.Result.Token;
                        StorageUtils<String>.SavePreferences(DroidConstant.CurrentUser, token);
                        _objProgress.DismissDialog();
                        StartActivity(typeof(MainActivity));
                        Finish();
                        return true;
                    }
                    else
                    {
                        AppUtils.ShowToast(this, response.Message);
                        _objProgress.DismissDialog();
                        return true;
                    }
                }
                else
                {
                    _objProgress.DismissDialog();
                    AppUtils.ShowToast(this, Resources.GetString(Resource.String.network_error));
                    return true;
                }
            }
            else
            {
                _objProgress.DismissDialog();
                AppUtils.ShowToast(this, Resources.GetString(Resource.String.network_error));
                return true;
            }
        }

        protected async Task<bool> UserSocialLogin(string authToken, string firstName, string lastName, string socialId,int loginType)
		{

            UserSocialLoginRequest model = new UserSocialLoginRequest
            {
                Email = "",
                FirstName = firstName,
                LastName = lastName,
                LoginType = loginType,
                SocialId = socialId,
				DeviceType = (int)EnumDeviceType.Android,
				DeviceToken = StorageUtils<String>.GetPreferencesValue(DroidConstant.DeviceToken)
			};

			if (AppUtils.IsNetwork())
			{
				var response = await _ILoginService.SocialLoginUser(model, ServiceType.UserService, authToken);
				if (response != null)
				{
					if (response.IsSuccess)
					{
						//StorageUtils<String>.GetPreferences(DroidConstant.CurrentUser)
						string token = response.Result.Token;
						StorageUtils<String>.SavePreferences(DroidConstant.CurrentUser, token);
						_objProgress.DismissDialog();
						StartActivity(typeof(MainActivity));
						Finish();
						return true;
					}
					else
					{
						AppUtils.ShowToast(this, response.Message);
						_objProgress.DismissDialog();
						return true;
					}
				}
				else
				{
					_objProgress.DismissDialog();
					AppUtils.ShowToast(this, Resources.GetString(Resource.String.network_error));
					return true;
				}
			}
			else
			{
				_objProgress.DismissDialog();
				AppUtils.ShowToast(this, Resources.GetString(Resource.String.network_error));
				return true;
			}
		}

		public async Task<string> GetAuthKey()
		{
			AuthkeyRequest model = new AuthkeyRequest
			{
				DeviceType = (int)EnumDeviceType.Android,
				DeviceToken = ""
			};

			if (AppUtils.IsNetwork())
			{
				var response = await _ILoginService.GetAuthkey(model, ServiceType.SessionService);
				if (response != null)
				{
					if (response.IsSuccess)
					{
						//StorageUtils<RespUserActivation>.SavePreferences(AppConstant.CurrentUser, response.Result);

						//CommonUtils.RedirectToController(AppConstant.HomeController);
						return response.Result.Token;
					}
					else
					{
						AppUtils.ShowToast(this, response.Message);
						_objProgress.DismissDialog();
						return response.Result.Token;
					}
				}
				else
				{
					_objProgress.DismissDialog();
					AppUtils.ShowToast(this, Resources.GetString(Resource.String.network_error));
					return response.Result.Token;
				}
			}
			else
			{
				_objProgress.DismissDialog();
				AppUtils.ShowToast(this, Resources.GetString(Resource.String.network_error));
				return null;
			}
	}
        #endregion
        #region google
        protected override void OnStart()
        {
            base.OnStart();
            //mGoogleApiClient.Connect();
        }

        protected override void OnStop()
        {
            base.OnStop();
            mGoogleApiClient.Disconnect();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutBoolean(KEY_IS_RESOLVING, mIsResolving);
            outState.PutBoolean(KEY_SHOULD_RESOLVE, mIsResolving);
        }



        public async void OnConnected(Bundle connectionHint)
        {

            //  Log.Debug(TAG, "onConnected:" + connectionHint);
            // GetName();
            //UpdateUI(true);
          
            if (PlusClass.PeopleApi.GetCurrentPerson(mGoogleApiClient) != null)
            {
                var person = PlusClass.PeopleApi.GetCurrentPerson(mGoogleApiClient);
                
                _objProgress = new CustomProgress(this);
                String auth = await GetAuthKey();
				await UserSocialLogin(auth,person.Name.ToString(),person.Name.ToString(),person.Id, (int)LoginTypes.Google);
            }
        }

        public void OnConnectionSuspended(int cause)
        {
           // Log.Warn(TAG, "onConnectionSuspended:" + cause);
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
           // Log.Debug(TAG, "onConnectionFailed:" + result);

            if (!mIsResolving && mShouldResolve)
            {
                if (result.HasResolution)
                {
                    try
                    {
                        result.StartResolutionForResult(this, RC_SIGN_IN);
                        mIsResolving = true;
                    }
                    catch (IntentSender.SendIntentException e)
                    {
                    //    Log.Error(TAG, "Could not resolve ConnectionResult.", e);
                        mIsResolving = false;
                        mGoogleApiClient.Connect();
                    }
                }
                else
                {
                    ShowErrorDialog(result);
                }
            }
            else
            {
                //UpdateUI(false);
            }
        }

        class DialogInterfaceOnCancelListener : Java.Lang.Object, IDialogInterfaceOnCancelListener
        {
            public Action<IDialogInterface> OnCancelImpl { get; set; }

            public void OnCancel(IDialogInterface dialog)
            {
                OnCancelImpl(dialog);
            }
        }

        void ShowErrorDialog(ConnectionResult connectionResult)
        {
            int errorCode = connectionResult.ErrorCode;

            if (GooglePlayServicesUtil.IsUserRecoverableError(errorCode))
            {
                var listener = new DialogInterfaceOnCancelListener();
                listener.OnCancelImpl = (dialog) => {
                    mShouldResolve = false;
                   // UpdateUI(false);
                };
                GooglePlayServicesUtil.GetErrorDialog(errorCode, this, RC_SIGN_IN, listener).Show();
            }
            else
            {
                var errorstring = string.Format(GetString(Resource.String.play_services_error_fmt), errorCode);
                Toast.MakeText(this, errorstring, ToastLength.Short).Show();

                mShouldResolve = false;
              //  UpdateUI(false);
            }
        }
        #endregion


    }

    public class MyProfileTracker : ProfileTracker
    {
        public event EventHandler<OnProfileChangedEventArgs> mOnProfileChanged;

        protected override void OnCurrentProfileChanged(Profile oldProfile, Profile newProfile)
        {
            if (mOnProfileChanged != null)
            {
                mOnProfileChanged.Invoke(this, new OnProfileChangedEventArgs(newProfile));
            }
        }



    }

    public class OnProfileChangedEventArgs : EventArgs
    {
        public Profile mProfile;

        public OnProfileChangedEventArgs(Profile profile) { mProfile = profile; }
    }

}

