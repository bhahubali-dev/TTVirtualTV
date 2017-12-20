using System;
using System.Linq;
using Android.Content;
using Android.Widget;
using Android.Telephony;
using static Android.Provider.Settings;
using System.Threading.Tasks;

using Android.Net;

using Java.IO;
using Android.Util;


using System.IO;
using Android.App;

using System.Net;
using Android.Net.Wifi;
using Android.Webkit;
using Android.Content.PM;
using Java.Security;

namespace VirtualEvent.Droid.Helper
{
    class AppUtils
    {
        public static bool IsNet = true;
        public static bool IsWifiEnable = true;
        public static bool IsDataOn = true;
        public static bool IsAirplanDisable = true;
        public static string GetUniqueId(Context currentContext)
        {
            string devcieId;
            var telephonyManager = (TelephonyManager)currentContext.GetSystemService(Context.TelephonyService);
            devcieId = telephonyManager.DeviceId;
            if (telephonyManager.DeviceId == null)
            {
                devcieId = Secure.GetString(currentContext.ContentResolver, Secure.AndroidId);
            }
            return devcieId;
        }

        public static void ShowToast(Context context, string msg)
        {
            Toast.MakeText(context, msg, ToastLength.Long).Show();
        }

		public static void LoadImage(string url, ImageView imgvw) {
		}

        //public static void ShowOkAlert(Context context,string Message)
        //{
        //    AlertDialog.Builder alert = new AlertDialog.Builder(context);
        //    alert.SetMessage(Message);
        //    alert.SetPositiveButton("Ok", (senderAlert, args) => {
        //    });
        //    Dialog dialog = alert.Create();
        //    dialog.Show();

        //}

        //Download from url------------------------------------------
        public static async void DownLoadSource(string url, Java.IO.File _appDirectory, Java.IO.File newFile, string filePath, Context context,string FileName,int notificationId)
        {

            // ShowToast(context,  context.Resources.GetString(Resource.String.downloading) + Newsrc);

            var NotificationId = notificationId;

            string localPath;
            try
            {
                System.Uri uri = new System.Uri(url);
                WebClient webClient = new WebClient();
                string localFileName;
                webClient.DownloadDataAsync(uri);
              
               

                Log.Debug("tag", "File to download = " + newFile.ToString());
                MimeTypeMap mime = MimeTypeMap.Singleton;
                String ext = newFile.Name.Substring(newFile.Name.IndexOf(".") + 1);
                String type = mime.GetMimeTypeFromExtension(ext);

                Intent openFile = new Intent(Intent.ActionView, Android.Net.Uri.FromFile(newFile));
                openFile.SetDataAndType(Android.Net.Uri.FromFile(newFile), type);
                openFile.AddFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop | ActivityFlags.NewTask);


                PendingIntent p = PendingIntent.GetActivity(context, 0, openFile, 0);

                var notification = new Android.Support.V4.App.NotificationCompat.Builder(context)
                  .SetSmallIcon(Android.Resource.Drawable.StatNotifySync)
                  .SetContentTitle(FileName)
                  .SetContentText(" Downloading")
                  
                  .SetOngoing(false);
                notification.SetProgress(0, 0, true);
                NotificationManager notificationmanager = (NotificationManager)Android.App.Application.Context.GetSystemService(Service.NotificationService);
                // Build Notification with Notification Manager
               
                notificationmanager.Notify((int)NotificationId, notification.Build());


                webClient.DownloadDataCompleted += (s, e) =>
                {
                    try
                    {
                        if (!_appDirectory.Exists())
                            _appDirectory.Mkdirs();
                        var bytes = e.Result; // get the downloaded data
                        {
                            notification.SetContentText(" Downloaded");
                            notification.SetContentTitle(FileName);
                            notification.SetContentIntent(p);
                            notification.SetProgress(0, 0, false);
                            notification.SetAutoCancel(true);// Notification.Flags = NotificationFlags.AutoCancel;
							//System.IO.File.WriteAllBytes(filePath, bytes);
						    notificationmanager.Notify((int)NotificationId, notification.Build());
                            // writes to local storage 
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                };
            }
            catch (System.Exception ex)
            {

            }

        }

        public static void generateKeyHash(Context context)
        {
            try
            {
                PackageInfo info = context.PackageManager.GetPackageInfo(
                        context.PackageName, PackageInfoFlags.Signatures);
                foreach (Android.Content.PM.Signature signature in info.Signatures)
                {
                    MessageDigest md = MessageDigest.GetInstance("SHA");
                    md.Update(signature.ToByteArray());
                    Log.Error("KeyHash:",
                            Base64.EncodeToString(md.Digest(), Base64.Default));
                }
            }
            catch (Exception e)
            {
            }
        }



        //Download from url------------------------------------------
        public static async void OpenDownloadedItem(string filePath, Java.IO.File _appDirectory, Context context)
        {

            // ShowToast(context,  context.Resources.GetString(Resource.String.downloading) + Newsrc);            
            string localPath;
            try
            {
                MimeTypeMap mime = MimeTypeMap.Singleton;
                String ext = _appDirectory.Name.Substring(_appDirectory.Name.IndexOf(".") + 1);
                String type = mime.GetMimeTypeFromExtension(ext);
                Intent openFile = new Intent(Intent.ActionView, Android.Net.Uri.FromFile(_appDirectory));
                openFile.SetDataAndType(Android.Net.Uri.FromFile(_appDirectory), type);
                openFile.AddFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop | ActivityFlags.NewTask);
                context.StartActivity(openFile);

            }
            catch (System.Exception ex)
            {

            }

        }


        //check connectivity if all internet is available
        public bool IsNetworkAvailabe()
        {
            return (IsMobileDateOn() && IsWifiOn());// (IsSimSupport() && IsMobileDateOn() && IsWifiOn());
        }

        public bool IsSimSupport()
        {
            TelephonyManager tm = (TelephonyManager)Android.App.Application.Context.GetSystemService(Context.TelecomService);  //gets the current TelephonyManager
            return !(tm.SimState == SimState.Absent);

        }
        public bool IsMobileDateOn()
        {
            var cm = (ConnectivityManager)Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
            bool mobileDataEnabled = false; // Assume disabled
            try
            {
                Java.Lang.Class cmClass = Java.Lang.Class.ForName(cm.Class.Name);

                Java.Lang.Reflect.Method method = cmClass.GetDeclaredMethod("getMobileDataEnabled");
                method.Accessible = (true); // Make the method callable
                                            // get the setting for "mobile data"
                mobileDataEnabled = (bool)method.Invoke(cm);
            }
            catch (Java.Lang.Exception ex)
            { }

            return mobileDataEnabled;
        }

        public bool IsWifiOn()
        {
            WifiManager wifi = (WifiManager)Android.App.Application.Context.GetSystemService(Context.WifiService);
            return wifi.IsWifiEnabled;
        }

        public static void LogOut(Context context)
        {
            //Intent intent = new Intent(context, typeof(LoginActivity));
            //intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask); //Intent.FLAG_ACTIVITY_CLEAR_TOP (Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_NEW_TASK);
            //context.StartActivity(intent);
        }


        public static bool IsNetwork()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            bool isOnline = (activeConnection != null) && activeConnection.IsConnected;
            IsNet = isOnline;
            return isOnline;
        }
        public static bool IsAirplaneModeOn(Context context)
        {
            var isAirplaneModeOn = Android.Provider.Settings.Global.GetInt(context.ContentResolver,
                     Android.Provider.Settings.Global.AirplaneModeOn);

            return isAirplaneModeOn != 0;
        }

        //public async Task<bool> Upload(string[] fileList)
        //{
        //    if (fileList == null)
        //    {
        //        return false;
        //    }
        //    var s3Client = S3Utils.S3Client;
        //    try
        //    {
        //        foreach (var files in fileList)
        //        {
        //            Java.IO.File image = new Java.IO.File(files);
        //            if (image.Name != null)
        //            {
        //                try
        //                {
        //                    await s3Client.PutObjectAsync(new PutObjectRequest()
        //                    {
        //                        BucketName = Constant.BucketName.ToLowerInvariant(),
        //                        FilePath = image.AbsolutePath,

        //                        Key = image.Name
        //                    });
        //                    image.Delete();
        //                }
        //                catch (Exception ex)
        //                {
        //                    Log.Error("Tag", "Image Upload Exception: {0}.", ex.StackTrace);
        //                }
        //            }
        //        }
        //        return true;
        //    }
        //    catch (AmazonS3Exception s3Exception)
        //    {
        //        Log.Error("Tag", "Image Upload Exception: {0}.", s3Exception.StackTrace);
        //        return false;
        //    }
        //}

        //public async Task<bool> UploadStream(Stream stream, string imageName)
        //{
        //    if (stream == null)
        //    {
        //        return false;
        //    }
        //    var s3Client = S3Utils.S3Client;
        //    try
        //    {

        //        try
        //        {
        //            await s3Client.PutObjectAsync(new PutObjectRequest()
        //            {
        //                BucketName = Constant.BucketName.ToLowerInvariant(),
        //                // FilePath = image.AbsolutePath,
        //                InputStream = stream,
        //                Key = imageName
        //            });
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            Log.Error("Tag", "Image Upload Exception: {0}.", ex.StackTrace);
        //            return false;
        //        }



        //    }
        //    catch (AmazonS3Exception s3Exception)
        //    {
        //        Log.Error("Tag", "Image Upload Exception: {0}.", s3Exception.StackTrace);
        //        return false;
        //    }
        //}

        //public static async Task<bool> Logout(Context currentContext)
        //{
        //    StorageUtils<RespUserActivation>.SavePreferences(DroidConstant.CurrentUser, new RespUserActivation());

        //    BaseRequest RequestModel = new BaseRequest
        //    {
        //        Id = StorageUtils<RespUserActivation>.GetPreferences(DroidConstant.CurrentUser).UserId,
        //        DeviceType = (int)EnumDeviceType.Android,
        //        DeviceToken = "abc",//((TelephonyManager)GetSystemService(Android.Content.Context.TelephonyService)).DeviceId,
        //    };


        //    Intent intent = new Intent(currentContext, typeof(LoginActivity));
        //    intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask); //Intent.FLAG_ACTIVITY_CLEAR_TOP (Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_NEW_TASK);
        //    currentContext.StartActivity(intent);

        //    if (IsNetwork())
        //    {
        //        ILoginService _ILoginService = new LoginService();
        //        ApiResponse<object> response = new ApiResponse<object>();
        //        response = await _ILoginService.LogoutUser(RequestModel);
        //        if (response != null && response.Result != null)
        //        {
        //            if (response.IsSuccess)
        //            {

        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }

        //    }
        //    else
        //    {
        //        //OfflineLogout(currentContext, currentUserId);
        //    }

        //    return true;
        //}


        public static string DeviceToken()
        {
            string deviceToken = "abc";
            return deviceToken;
        }
        public static string Path()
        {
			return "";//System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), Constant.LacalDBName);
        }

    }

    public static class ObjectTypeHelper
    {
        public static T Cast<T>(this Java.Lang.Object obj) where T : class
        {
            var propertyInfo = obj.GetType().GetProperty("Instance");
            return propertyInfo == null ? null : propertyInfo.GetValue(obj, null) as T;
        }


    }

    public class JavaObjectWrapper<T> : Java.Lang.Object
    {
        public T Obj { get; set; }
    }


}