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
using Android;

namespace VirtualEvent.Droid.Helper
{
	class DroidConstant
	{
		public const string CurrentUser = "CurrentUser";
		public const string DeviceToken = "DeviceToken";

		public static readonly string[] PermissionsLocation =
	{
	  Manifest.Permission.AccessCoarseLocation,
	  Manifest.Permission.AccessFineLocation
	};

		public static readonly string[] PermissionStorage =
   {
	  Manifest.Permission.WriteExternalStorage
	};
		public static readonly string[] PermissionCamera =
   {
	  Manifest.Permission.Camera
	};
		public static readonly string[] Permissions =
		{
	  Manifest.Permission.Camera,Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage,Manifest.Permission.AccessCoarseLocation,
	  Manifest.Permission.AccessFineLocation
	};

		public const string DATE_FORMAT = "MMM dd, yyyy  HH:mm tt";
		public const string DATE = "MMM dd, yyyy";
		public const string TIME = "HH:mm tt";
	}
}
