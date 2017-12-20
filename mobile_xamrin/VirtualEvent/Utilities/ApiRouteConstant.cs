using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualEvent
{
	public static class ApiRouteConstant
	{
		#region EndPoint
		//public const string BaseUrl = "http://staging10.techaheadcorp.com/VirtualEvent/api/"; // dev server
		public const string BaseUrl = "http://138.91.253.129/virtualevent.app/api/"; // live-server url
		#endregion

		#region Login
		public const string GenerateToken = "GenerateTempToken";
		public const string UserLogin = "Login";
        public const string SocialUserLogin = "SocialLogin";
        public const string Logout = "Logout";

		public const string Events = "Events";
		public const string PurchasedEvents = "PurchasedEvents";
		public const string EventDetail = "EventDetail";

		public const string Notifications = "Notifications";
		#endregion


	}

}
