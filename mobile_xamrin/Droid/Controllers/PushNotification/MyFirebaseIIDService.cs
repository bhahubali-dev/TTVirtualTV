using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Firebase.Iid;
using VirtualEvent.Droid.Helper;

namespace VirtualEvent.Droid.Controllers.PushNotification
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "MyFirebaseIIDService Refreshed token: " + refreshedToken);
			StorageUtils<String>.SavePreferences(DroidConstant.DeviceToken, refreshedToken);
            SendRegistrationToServer(refreshedToken);
            
           
        }
        void SendRegistrationToServer(string token)
        {
            // Add custom implementation, as needed.
        }
    }
    
}